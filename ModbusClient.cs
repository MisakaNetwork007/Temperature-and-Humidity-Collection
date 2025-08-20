using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Temperature_and_Humidity_Collection
{
    public enum ModbusMode
    {
        RTU,
        TCP
    }

    public enum ModbusFunctionCode : byte
    {
        ReadCoils = 0x01,
        ReadDiscreteInputs = 0x02,
        ReadHoldingRegisters = 0x03,
        ReadInputRegisters = 0x04,
        WriteSingleCoil = 0x05,
        WriteSingleRegister = 0x06,
        WriteMultipleCoils = 0x0F,
        WriteMultipleRegisters = 0x10
    }

    public class ModbusException : Exception
    {
        public byte ExceptionCode { get; }

        public ModbusException(byte exceptionCode, string message) : base(message)
        {
            ExceptionCode = exceptionCode;
        }
    }

    public class ModbusClient : IDisposable
    {
        #region 字段和属性
        private ModbusMode _mode;
        private SerialPort _serialPort;
        private TcpClient _tcpClient;
        private NetworkStream _networkStream;
        private string _ipAddress;
        private int _port;
        private string _comPort;
        private int _baudRate;
        private byte _slaveId;
        private int _timeout = 1000;

        public bool IsConnected
        {
            get
            {
                return _mode == ModbusMode.RTU ?
                    (_serialPort != null && _serialPort.IsOpen) :
                    (_tcpClient != null && _tcpClient.Connected);
            }
        }
        #endregion

        #region 构造函数
        public ModbusClient(ModbusMode mode, byte slaveId, string ipAddress = "127.0.0.1", int port = 502, string comPort = "COM1", int baudRate = 9600)
        {
            _mode = mode;
            _slaveId = slaveId;
            _ipAddress = ipAddress;
            _port = port;
            _comPort = comPort;
            _baudRate = baudRate;
        }
        #endregion

        #region 连接管理
        public void Connect()
        {
            if (_mode == ModbusMode.RTU)
            {
                if (_serialPort != null && _serialPort.IsOpen)
                    return;

                _serialPort = new SerialPort(_comPort, _baudRate, Parity.None, 8, StopBits.One)
                {
                    ReadTimeout = _timeout,
                    WriteTimeout = _timeout
                };
                _serialPort.Open();
            }
            else
            {
                if (_tcpClient != null && _tcpClient.Connected)
                    return;

                _tcpClient = new TcpClient();
                _tcpClient.Connect(_ipAddress, _port);
                _networkStream = _tcpClient.GetStream();
                _networkStream.ReadTimeout = _timeout;
            }
        }

        public void Disconnect()
        {
            if (_mode == ModbusMode.RTU)
            {
                if (_serialPort != null && _serialPort.IsOpen)
                {
                    _serialPort.Close();
                    _serialPort.Dispose();
                }
                _serialPort = null;
            }
            else
            {
                if (_networkStream != null)
                {
                    _networkStream.Close();
                    _networkStream.Dispose();
                }
                if (_tcpClient != null && _tcpClient.Connected)
                {
                    _tcpClient.Close();
                }
                _tcpClient = null;
                _networkStream = null;
            }
        }
        #endregion

        #region 核心通信方法
        private byte[] SendReceive(byte[] request)
        {
            if (!IsConnected)
                throw new InvalidOperationException("Modbus client is not connected");

            byte[] response = null;

            if (_mode == ModbusMode.RTU)
            {
                // 添加从站地址
                var requ = new byte[request.Length + 1];
                requ[0] = _slaveId;
                Array.Copy(request, 0, requ, 1, request.Length);
                
                // 添加CRC校验
                ushort crc = ModbusCrc16.ComputeCrcFast(requ);
                var frame = new byte[requ.Length + 2];
                Array.Copy(requ, frame, requ.Length);
                frame[frame.Length - 2] = (byte)(crc & 0xFF);
                frame[frame.Length - 1] = (byte)(crc >> 8);

                _serialPort.DiscardInBuffer();
                _serialPort.DiscardOutBuffer();
                _serialPort.Write(frame, 0, frame.Length);

                // 读取响应
                Thread.Sleep(CalculateDelay(frame.Length));
                int bytesToRead = _serialPort.BytesToRead;
                if (bytesToRead == 0)
                    throw new TimeoutException("No response received from device");

                response = new byte[bytesToRead];
                _serialPort.Read(response, 0, bytesToRead);

                if (response[0] != _slaveId) 
                    throw new ModbusException(0xFF, "从站地址不对应");

                // 验证CRC
                ushort receivedCrc = (ushort)(response[bytesToRead - 1] << 8 | response[bytesToRead - 2]);
                ushort calculatedCrc = ModbusCrc16.ComputeCrcFast(response.Take(bytesToRead - 2).ToArray());
                if (receivedCrc != calculatedCrc)
                    throw new ModbusException(0xFF, "CRC校验失败");

                //去除从站地址与CRC
                var resp = new byte[response.Length - 3];
                Array.Copy(response, 1, resp, 0, resp.Length);
                response = resp;
            }
            else // TCP模式
            {
                // 添加MBAP头
                var tcpFrame = new byte[7 + request.Length];
                tcpFrame[0] = 0x00; // 事务ID高字节
                tcpFrame[1] = 0x01; // 事务ID低字节
                tcpFrame[2] = 0x00; // 协议ID高字节
                tcpFrame[3] = 0x00; // 协议ID低字节
                tcpFrame[4] = (byte)((request.Length + 1) >> 8); // 长度高字节
                tcpFrame[5] = (byte)((request.Length + 1) & 0xFF); // 长度低字节
                tcpFrame[6] = _slaveId; // 单元标识符
                Array.Copy(request, 0, tcpFrame, 7, request.Length);

                _networkStream.Write(tcpFrame, 0, tcpFrame.Length);

                // 读取MBAP头
                var mbapHeader = new byte[7];
                int bytesRead = ReadFullBuffer(mbapHeader, 7);
                if (bytesRead != 7)
                    throw new TimeoutException("Incomplete MBAP header received");

                // 读取PDU
                int pduLength = (mbapHeader[4] << 8) | mbapHeader[5];
                var pdu = new byte[pduLength - 1]; // 减去单元标识符
                bytesRead = ReadFullBuffer(pdu, pdu.Length);
                if (bytesRead != pdu.Length)
                    throw new TimeoutException("Incomplete PDU received");

                response = pdu;
            }

            // 检查异常响应
            if ((response[0] & 0x80) != 0)
            {
                byte functionCode = (byte)(response[0] & 0x7F);
                byte exceptionCode = response[1];
                throw new ModbusException(exceptionCode, $"Modbus异常 (功能码: 0x{functionCode:X2}, 异常码: 0x{exceptionCode:X2})");
            }

            return response;
        }

        private int ReadFullBuffer(byte[] buffer, int length)
        {
            int totalRead = 0;
            while (totalRead < length)
            {
                int read = _mode == ModbusMode.RTU ?
                    _serialPort.Read(buffer, totalRead, length - totalRead) :
                    _networkStream.Read(buffer, totalRead, length - totalRead);

                if (read == 0)
                    throw new TimeoutException("读取操作超时");

                totalRead += read;
            }
            return totalRead;
        }

        private int CalculateDelay(int frameLength)
        {
            // 计算RTU模式下需要的字符间延迟
            if (_mode == ModbusMode.RTU)
            {
                // 每个字符传输时间 (ms) = (11 bits/char) / (波特率/1000) * 1000
                double charTime = 11.0 / (_baudRate / 1000.0) * 1000;
                // 帧间延迟至少需要3.5个字符时间
                return (int)Math.Ceiling(3.5 * charTime);
            }
            return 0;
        }
        #endregion

        #region 公共Modbus方法
        /// <summary>
        /// 读取线圈
        /// </summary>
        /// <param name="startAddress"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public bool[] ReadCoils(ushort startAddress, ushort count)
        {
            //发送报文：从站地址(1byte) + 功能码(1byte) + 开始线圈地址(2byte) + 线圈数量(2byte) + CRC(2byte)
            var request = new byte[5];
            request[0] = (byte)ModbusFunctionCode.ReadCoils;
            request[1] = (byte)(startAddress >> 8);
            request[2] = (byte)(startAddress & 0xFF);
            request[3] = (byte)(count >> 8);
            request[4] = (byte)(count & 0xFF);

            var response = SendReceive(request);

            //接收报文：从站地址(1byte) + 功能码(1byte) + 字节计数(1byte) + 数据(nbyte) + CRC(2byte)
            //int byteCount = response[1];
            var values = new bool[count];
            for (int i = 0; i < count; i++)
            {
                int byteIndex = 2 + i / 8;
                int bitIndex = i % 8;
                values[i] = (response[byteIndex] & (1 << bitIndex)) != 0;
            }

            return values;
        }

        /// <summary>
        /// 读取离散输入
        /// </summary>
        /// <param name="startAddress"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public bool[] ReadDiscreteInputs(ushort startAddress, ushort count)
        {
            //发送报文：从站地址(1byte) + 功能码(1byte) + 开始输入线圈地址(2byte) + 线圈数量(2byte) + CRC(2byte)
            var request = new byte[5];
            request[0] = (byte)ModbusFunctionCode.ReadDiscreteInputs;
            request[1] = (byte)(startAddress >> 8);
            request[2] = (byte)(startAddress & 0xFF);
            request[3] = (byte)(count >> 8);
            request[4] = (byte)(count & 0xFF);

            var response = SendReceive(request);

            //接收报文：从站地址(1byte) + 功能码(1byte) + 字节数(1byte) + 数据(nbyte) + CRC(2byte)
            var values = new bool[count];
            for (int i = 0; i < count; i++)
            {
                int byteIndex = 2 + i / 8;
                int bitIndex = i % 8;
                values[i] = (response[byteIndex] & (1 << bitIndex)) != 0;
            }

            return values;
        }

        /// <summary>
        /// 读取保持寄存器
        /// </summary>
        /// <param name="startAddress"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        /// <exception cref="ModbusException"></exception>
        public ushort[] ReadHoldingRegisters(ushort startAddress, ushort count)
        {
            //发送报文：从站地址(1byte) + 功能码(1byte) + 保持寄存器起始地址(2byte) + 保持寄存器数量(2byte) + CRC(2byte)
            var request = new byte[5];
            request[0] = (byte)ModbusFunctionCode.ReadHoldingRegisters;
            request[1] = (byte)(startAddress >> 8);
            request[2] = (byte)(startAddress & 0xFF);
            request[3] = (byte)(count >> 8);
            request[4] = (byte)(count & 0xFF);

            var response = SendReceive(request);

            //接收报文：从站地址(1byte) + 功能码(1byte) + 字节数(1byte) + 数据(nbyte) + CRC(2byte)
            int byteCount = response[1];
            if (byteCount != count * 2)
                throw new ModbusException(0xFF, "返回数据长度不正确");

            var values = new ushort[count];
            for (int i = 0; i < count; i++)
            {
                values[i] = (ushort)((response[2 + i * 2] << 8) | response[3 + i * 2]);
            }

            return values;
        }

        /// <summary>
        /// 读取输入寄存器
        /// </summary>
        /// <param name="startAddress"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public ushort[] ReadInputRegisters(ushort startAddress, ushort count)
        {
            //发送报文：从站地址(1byte) + 功能码(1byte) + 开始输入寄存器地址(2byte) + 输入寄存器数量(2byte) + CRC(2byte)
            var request = new byte[5];
            request[0] = (byte)ModbusFunctionCode.ReadInputRegisters;
            request[1] = (byte)(startAddress >> 8);
            request[2] = (byte)(startAddress & 0xFF);
            request[3] = (byte)(count >> 8);
            request[4] = (byte)(count & 0xFF);

            var response = SendReceive(request);

            //接收报文：从站地址(1byte) + 功能码(1byte) + 字节数(1byte) + 数据(nbyte) + CRC(2byte)
            int byteCount = response[1];
            if (byteCount != count * 2)
                throw new ModbusException(0xFF, "返回数据长度不正确");

            var values = new ushort[count];
            for (int i = 0; i < count; i++)
            {
                values[i] = (ushort)((response[2 + i * 2] << 8) | response[3 + i * 2]);
            }

            return values;
        }

        /// <summary>
        /// 写单个线圈
        /// </summary>
        /// <param name="address"></param>
        /// <param name="value"></param>
        public void WriteSingleCoil(ushort address, bool value)
        {
            //发送报文：从站地址(1byte) + 功能码(1byte) + 线圈地址(2byte) + 写入值(2byte) + CRC(2byte)
            var request = new byte[5];
            request[0] = (byte)ModbusFunctionCode.WriteSingleCoil;
            request[1] = (byte)(address >> 8);
            request[2] = (byte)(address & 0xFF);
            request[3] = (byte)(value ? 0xFF : 0x00);
            request[4] = (byte)0x00;

            var response = SendReceive(request);

            //接收报文：从站地址(1byte) + 功能码(1byte) + 线圈地址(2byte) + 写入值(2byte) + CRC(2byte)
            // 验证响应
            if (response.Length != 5 ||
                response[0] != request[0] || response[1] != request[1] ||
                response[2] != request[2] || response[3] != request[3] ||
                response[4] != request[4] )
            {
                throw new ModbusException(0xFF, "写入线圈响应不匹配");
            }
        }

        /// <summary>
        /// 写单个保持寄存器
        /// </summary>
        /// <param name="address"></param>
        /// <param name="value"></param>
        /// <exception cref="ModbusException"></exception>
        public void WriteSingleRegister(ushort address, ushort value)
        {
            //发送报文：从站地址(1byte) + 功能码(1byte) + 保持寄存器地址(2byte) + 写入值(2byte) + CRC(2byte)
            var request = new byte[5];
            request[0] = (byte)ModbusFunctionCode.WriteSingleRegister;
            request[1] = (byte)(address >> 8);
            request[2] = (byte)(address & 0xFF);
            request[3] = (byte)(value >> 8);
            request[4] = (byte)(value & 0xFF);

            var response = SendReceive(request);

            //接收报文：从站地址(1byte) + 功能码(1byte) + 保持寄存器地址(2byte) + 写入值(2byte) + CRC(2byte)
            // 验证响应
            if (response.Length != 5 ||
                response[0] != request[0] || response[1] != request[1] ||
                response[2] != request[2] || response[3] != request[3] ||
                response[4] != request[4] )
            {
                throw new ModbusException(0xFF, "写入寄存器响应不匹配");
            }
        }

        /// <summary>
        /// 写多个线圈
        /// </summary>
        /// <param name="startAddress"></param>
        /// <param name="values"></param>
        public void WriteMultipleCoils(ushort startAddress, bool[] values)
        {
            //发送报文：从站地址(1byte) + 功能码(1byte) + 线圈起始地址(2byte) + 线圈数量(2byte) + 字节数(1byte) + 写入值(nbyte) + CRC(2byte)
            int byteCount = values.Length / 8;
            byteCount = byteCount > 0 ? byteCount : 1;
            var request = new byte[6 + byteCount];
            request[0] = (byte)ModbusFunctionCode.WriteMultipleCoils;
            request[1] = (byte)(startAddress >> 8);
            request[2] = (byte)(startAddress & 0xFF);
            request[3] = (byte)(values.Length >> 8);
            request[4] = (byte)(values.Length & 0xFF);
            request[5] = (byte)byteCount;

            for (int i = 0; i < byteCount; i++)
            {
                for (int j = 0; j < values.Length; j++)
                {
                    int bitIndex = j % 8;
                    int bitValue = values[j] ? 1 : 0;
                    request[6 + i] += (byte)(bitValue << bitIndex);
                }
            }

            var response = SendReceive(request);
            //接收报文：从站地址(1byte) + 功能码(1byte) + 线圈起始地址(2byte) + 线圈数量(2byte) + CRC(2byte)
            // 验证响应
            if (response.Length != 5 ||
                response[0] != request[0] || response[1] != request[1] ||
                response[2] != request[2] || response[3] != request[3] ||
                response[4] != request[4] )
            {
                throw new ModbusException(0xFF, "写入多个线圈响应不匹配");
            }
        }

        /// <summary>
        /// 写多个保持寄存器
        /// </summary>
        /// <param name="startAddress"></param>
        /// <param name="values"></param>
        /// <exception cref="ModbusException"></exception>
        public void WriteMultipleRegisters(ushort startAddress, ushort[] values)
        {
            //发送报文：从站地址(1byte) + 功能码(1byte) + 保持寄存器起始地址(2byte) + 保持寄存器数量(2byte) + 字节数(1byte) + 写入值(nbyte) + CRC(2byte)
            int byteCount = values.Length * 2;
            var request = new byte[6 + byteCount];
            request[0] = (byte)ModbusFunctionCode.WriteMultipleRegisters;
            request[1] = (byte)(startAddress >> 8);
            request[2] = (byte)(startAddress & 0xFF);
            request[3] = (byte)(values.Length >> 8);
            request[4] = (byte)(values.Length & 0xFF);
            request[5] = (byte)byteCount;

            for (int i = 0; i < values.Length; i++)
            {
                request[6 + i * 2] = (byte)(values[i] >> 8);
                request[7 + i * 2] = (byte)(values[i] & 0xFF);
            }

            var response = SendReceive(request);
            //接收报文：从站地址(1byte) + 功能码(1byte) + 保持寄存器起始地址(2byte) + 保持寄存器数量(2byte) + CRC(2byte)

            // 验证响应
            if (response.Length != 5 ||
                response[0] != request[0] || response[1] != request[1] ||
                response[2] != request[2] || response[3] != request[3] ||
                response[4] != request[4] )
            {
                throw new ModbusException(0xFF, "写入多个寄存器响应不匹配");
            }
        }
        #endregion

        #region IDisposable实现
        public void Dispose()
        {
            Disconnect();
        }
        #endregion
    }

    public static class ModbusCrc16
    {
        // 预计算的 CRC 表（256个值）
        private static readonly ushort[] CrcTable = new ushort[256];

        // 静态构造函数初始化查表
        static ModbusCrc16()
        {
            const ushort polynomial = 0xA001;

            for (ushort i = 0; i < 256; i++)
            {
                ushort value = i;

                for (int j = 0; j < 8; j++)
                {
                    if ((value & 1) == 1)
                    {
                        value = (ushort)((value >> 1) ^ polynomial);
                    }
                    else
                    {
                        value >>= 1;
                    }
                }

                CrcTable[i] = value;
            }
        }

        /// <summary>
        /// 计算 Modbus CRC16（高效查表法）
        /// </summary>
        public static ushort ComputeCrcFast(byte[] data)
        {
            ushort crc = 0xFFFF;

            foreach (byte b in data)
            {
                byte index = (byte)(crc ^ b);
                crc = (ushort)((crc >> 8) ^ CrcTable[index]);
            }

            return crc;
        }
    }
}
