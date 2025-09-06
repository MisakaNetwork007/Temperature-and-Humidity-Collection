using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Temperature_and_Humidity_Collection.Data;
using Temperature_and_Humidity_Collection.Models;
using Timer = System.Windows.Forms.Timer;

namespace Temperature_and_Humidity_Collection.UserControls
{
    public partial class NowDataControl : UserControl
    {
        private Timer _minuteTimer;
        public NowDataControl()
        {
            InitializeComponent();
            InitializeTimer();
        }

        private void NowDataControl_Load(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(ReadData));
            //thread.IsBackground = true;
            thread.Start();
        }

        private void InitializeTimer()
        {
            // 创建定时器，每分钟检查一次
            _minuteTimer = new Timer();
            _minuteTimer.Interval = 60000; // 60秒
            _minuteTimer.Tick += MinuteTimer_Tick;
            _minuteTimer.Start();
        }

        private void MinuteTimer_Tick(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TemperatureTextBox1.Text) || string.IsNullOrEmpty(TemperatureTextBox2.Text)
                || string.IsNullOrEmpty(TemperatureTextBox3.Text) || string.IsNullOrEmpty(TemperatureTextBox4.Text)
                || string.IsNullOrEmpty(HumidityTextBox1.Text) || string.IsNullOrEmpty(HumidityTextBox2.Text)
                || string.IsNullOrEmpty(HumidityTextBox3.Text) || string.IsNullOrEmpty(HumidityTextBox4.Text)
                ) return;
            using(var context = new MyDbContext())
            {
                float[] temperatureData = new float[]
                {
                    float.Parse(TemperatureTextBox1.Text), float.Parse(TemperatureTextBox2.Text),
                    float.Parse(TemperatureTextBox3.Text), float.Parse(TemperatureTextBox4.Text)
                };

                float[] humidityData = new float[]
                {
                    float.Parse(HumidityTextBox1.Text), float.Parse(HumidityTextBox2.Text),
                    float.Parse(HumidityTextBox3.Text), float.Parse(HumidityTextBox4.Text)
                };
                for (int i = 0; i < 4; i++)
                {
                    var data = new DataTable()
                    {
                        SlaveAddress = (i+1).ToString(),
                        Temperature = temperatureData[i],
                        Humidity = humidityData[i],
                        Datetime = DateTime.Now
                    };
                    context.DataTables.Add(data);
                }
                context.SaveChanges();
            }
        }

        private void ReadData()
        {
            ModbusClient m = new(ModbusMode.RTU, 1, comPort: "COM31");

            float[] temporaryValue1 = new float[2];
            float[] temporaryValue2 = new float[2];
            float[] temporaryValue3 = new float[2];
            float[] temporaryValue4 = new float[2];
            try
            {
                m.Connect();
                while (StaticData.uiSyncContext != null)
                {
                    Thread.Sleep(1000);
                    m.SetSlaveId(1);
                    var d1 = m.ReadInputRegisters(0, 4);
                    m.SetSlaveId(2);
                    var d2 = m.ReadInputRegisters(0, 4);
                    m.SetSlaveId(3);
                    var d3 = m.ReadInputRegisters(0, 4);
                    m.SetSlaveId(4);
                    var d4 = m.ReadInputRegisters(0, 4);
                    var data1 = GetData(d1);
                    var data2 = GetData(d2);
                    var data3 = GetData(d3);
                    var data4 = GetData(d4);
                    if (data1.Length != 0 && !temporaryValue1.SequenceEqual(data1))
                    {
                        temporaryValue1 = data1;
                        StaticData.uiSyncContext.Post(_ =>
                        {
                            TemperatureTextBox1.Text = data1[0].ToString("F3");
                            HumidityTextBox1.Text = data1[1].ToString("F3");
                        }, null);
                    }
                    if (data2.Length != 0 && !temporaryValue2.SequenceEqual(data2))
                    {
                        temporaryValue2 = data2;
                        StaticData.uiSyncContext.Post(_ =>
                        {
                            TemperatureTextBox2.Text = data2[0].ToString("F3");
                            HumidityTextBox2.Text = data2[1].ToString("F3");
                        }, null);
                    }
                    if (data3.Length != 0 && !temporaryValue3.SequenceEqual(data3))
                    {
                        temporaryValue3 = data3;
                        StaticData.uiSyncContext.Post(_ =>
                        {
                            TemperatureTextBox3.Text = data3[0].ToString("F3");
                            HumidityTextBox3.Text = data3[1].ToString("F3");
                        }, null);
                    }
                    if (data4.Length != 0 && !temporaryValue4.SequenceEqual(data4))
                    {
                        temporaryValue4 = data4;
                        StaticData.uiSyncContext.Post(_ =>
                        {
                            TemperatureTextBox4.Text = data4[0].ToString("F3");
                            HumidityTextBox4.Text = data4[1].ToString("F3");
                        }, null);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                m.Dispose();
                _minuteTimer.Stop();
                _minuteTimer.Dispose();
            }

        }


        private float[] GetData(ushort[] registers)
        {
            if (registers.Length % 2 != 0)
            {
                return new float[0];
            }
            else
            {
                float[] reslut = new float[registers.Length / 2];
                for (int i = 0; i < registers.Length; i += 2)
                {
                    var r = new ushort[2];
                    r[0] = registers[i];
                    r[1] = registers[i + 1];
                    reslut[i / 2] = ModbusClient.ConvertRegistersToFloat(r, ByteOrder.BigEndian);
                }
                return reslut;
            }
        }

    }
}
