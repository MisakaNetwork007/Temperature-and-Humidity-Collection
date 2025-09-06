using ScottPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Temperature_and_Humidity_Collection.Data;

namespace Temperature_and_Humidity_Collection.UserControls
{
    public partial class HistoricalTrendControl : UserControl
    {
        private int _slaveId;
        private int _typeId;
        private int _num;

        public HistoricalTrendControl()
        {
            InitializeComponent();
            InitControl();
        }

        private void InitControl()
        {
            _slaveId = 1;
            _typeId = 0;
            _num = 10;

            FormsPlot.Plot.Font.Set("Microsoft YaHei UI");
            FormsPlot.Plot.XLabel("条");

            RefreshPlot(_slaveId, _typeId, _num);
        }

        /// <summary>
        /// 刷新Plot
        /// </summary>
        /// <param name="typeId">0：温度，1：湿度</param>
        /// <param name="num"></param>
        private void RefreshPlot(int slaveId, int typeId, int num)
        {
            FormsPlot.Plot.Clear();
            switch (typeId)
            {
                case 0:
                    FormsPlot.Plot.YLabel("温度（℃）");
                    FormsPlot.Plot.Axes.SetLimitsY(0, 50);
                    break;
                case 1:
                    FormsPlot.Plot.YLabel("湿度（%）");
                    FormsPlot.Plot.Axes.SetLimitsY(0, 100);
                    break;
            }

            FormsPlot.Plot.Axes.SetLimitsX(0, num);

            using (var context = new MyDbContext())
            {
                var datas = context.DataTables
                    .Where(p => p.SlaveAddress == slaveId.ToString())
                    .OrderByDescending(p => p.Id)
                    .Take(num)
                    .ToList();
                var data = datas.Select(y =>
                {
                    switch (typeId)
                    {
                        case 0:
                            return (double)y.Temperature;
                        case 1:
                            return (double)y.Humidity;
                        default:
                            return 0;
                    }
                }).ToArray();

                double[] x = Enumerable.Range(1, 100).Select(i => (double)i).ToArray();

                FormsPlot.Plot.Add.Scatter(x, data);
                FormsPlot.Refresh();
            }
        }

        private void SelectT_Click(object sender, EventArgs e)
        {
            _typeId = 0;
            RefreshPlot(_slaveId, _typeId, _num);
        }

        private void SelectH_Click(object sender, EventArgs e)
        {
            _typeId = 1;
            RefreshPlot(_slaveId, _typeId, _num);
        }

        private void Select10_Click(object sender, EventArgs e)
        {
            _num = 10;
            RefreshPlot(_slaveId, _typeId, _num);
        }

        private void Select20_Click(object sender, EventArgs e)
        {
            _num = 20;
            RefreshPlot(_slaveId, _typeId, _num);
        }

        private void Select50_Click(object sender, EventArgs e)
        {
            _num = 50;
            RefreshPlot(_slaveId, _typeId, _num);
        }

        private void SelectSlave_Change(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SlaveComboBox.Text) || int.Parse(SlaveComboBox.Text) > 4 || int.Parse(SlaveComboBox.Text) < 1) return;
            _slaveId = int.Parse(SlaveComboBox.Text);
            RefreshPlot(_slaveId, _typeId, _num);
        }
    }
}
