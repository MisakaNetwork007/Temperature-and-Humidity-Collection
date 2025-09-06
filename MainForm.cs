using Temperature_and_Humidity_Collection.Models;
using Temperature_and_Humidity_Collection.UserControls;
using Timer = System.Windows.Forms.Timer;

namespace Temperature_and_Humidity_Collection
{
    public partial class MainForm : Form
    {

        private Timer _minuteTimer;
        private int _lastMinute = -1;
        private NowDataControl _nowDataControl;
        private HistoricalTrendControl _historicalTrendControl;
        private DisplayLogControl _displayLogControl;
        private UserManagentControl _userManagentControl;
        private CurrentInterface _currentInterface;

        public MainForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            StaticData.uiSyncContext = SynchronizationContext.Current;

            InitForm();
            InitializeTimer();
        }

        private void InitForm()
        {
            CurUserLabel.Text = "当前用户：" + StaticData.currentUser.UserName;
            IdentityLabel.Text = "身份：" + StaticData.GetIdentityName(StaticData.currentUser.UserAccessLevel);
            
            string timeFormat = string.Concat("yyyy年MM月dd日", '\n', "dddd", '\n', "HH:mm");
            CurTimeLabel.Text = DateTime.Now.ToString(timeFormat);

            _nowDataControl = new NowDataControl();
            this.Controls.Add(_nowDataControl);
            _nowDataControl.Location = new Point(55, 134);
            _currentInterface = CurrentInterface.NowData;

            OperationLogTable o = new OperationLogTable()
            { 
                Uid = StaticData.currentUser.Uid,
                Datetime = DateTime.Now,
                OperationCode = (short)OperationCode.MonitorData,
                Status = true,
                ErrorCode = (short)ErrorCode.None
            };
            LogManagent.Instance.UploadOperationLog(o);
        }

        private void InitializeTimer()
        {
            // 创建定时器，每秒检查一次
            _minuteTimer = new Timer();
            _minuteTimer.Interval = 2000; // 2秒
            _minuteTimer.Tick += MinuteTimer_Tick;
            _minuteTimer.Start();
        }

        private void MinuteTimer_Tick(object sender, EventArgs e)
        {
            int currentMinute = DateTime.Now.Minute;

            // 如果分钟数发生了变化
            if (currentMinute != _lastMinute)
            {
                _lastMinute = currentMinute;
                // 更新时间显示
                string timeFormat = string.Concat("yyyy年MM月dd日", '\n', "dddd", '\n', "HH:mm");
                CurTimeLabel.Text = DateTime.Now.ToString(timeFormat);
            }
        }

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            LoginInformationTable l = new LoginInformationTable()
            {
                Uid = StaticData.currentUser.Uid,
                Datetime = DateTime.Now,
                LoginOrLogout = false,
                Status = true,
                ErrorCode = (short)ErrorCode.None
            };

            OperationLogTable o = new OperationLogTable()
            {
                Uid = StaticData.currentUser.Uid,
                Datetime = DateTime.Now,
                OperationCode = (short)OperationCode.Logout,
                Status = true,
                ErrorCode = (short)ErrorCode.None
            };
            LogManagent.Instance.UploadLoginInformation(l);
            LogManagent.Instance.UploadOperationLog(o);

            StaticData.uiSyncContext = null;
            
            _minuteTimer.Stop();
            _minuteTimer.Dispose();
        }

        private void OnShowData_Click(object sender, EventArgs e)
        {
            if (_currentInterface == CurrentInterface.NowData) return;
            switch(_currentInterface)
            {
                case CurrentInterface.HistoricalTrend:
                    _historicalTrendControl.Visible = false;
                    break;
                case CurrentInterface.DisplayLog:
                    _displayLogControl.Visible = false;
                    break;
                case CurrentInterface.UserManagent:
                    _userManagentControl.Visible = false;
                    break;
            }
            if(_nowDataControl == null)
            {
                _nowDataControl = new NowDataControl();
                this.Controls.Add(_nowDataControl);
                _nowDataControl.Location = new Point(55, 134);
            }else
            {
                _nowDataControl.Visible = true;
            }
            _currentInterface = CurrentInterface.NowData;

            OperationLogTable o = new OperationLogTable()
            {
                Uid = StaticData.currentUser.Uid,
                Datetime = DateTime.Now,
                OperationCode = (short)OperationCode.MonitorData,
                Status = true,
                ErrorCode = (short)ErrorCode.None
            };
            LogManagent.Instance.UploadOperationLog(o);
        }

        private void OnShowHistorical_Click(object sender, EventArgs e)
        {
            if (_currentInterface == CurrentInterface.HistoricalTrend) return;
            switch (_currentInterface)
            {
                case CurrentInterface.NowData:
                    _nowDataControl.Visible = false;
                    break;
                case CurrentInterface.DisplayLog:
                    _displayLogControl.Visible = false;
                    break;
                case CurrentInterface.UserManagent:
                    _userManagentControl.Visible = false;
                    break;
            }
            if (_historicalTrendControl == null)
            {
                _historicalTrendControl = new HistoricalTrendControl();
                this.Controls.Add(_historicalTrendControl);
                _historicalTrendControl.Location = new Point(55, 110);
            }
            else
            {
                _historicalTrendControl.Visible = true;
            }
            _currentInterface = CurrentInterface.HistoricalTrend;

            OperationLogTable o = new OperationLogTable()
            {
                Uid = StaticData.currentUser.Uid,
                Datetime = DateTime.Now,
                OperationCode = (short)OperationCode.InspectData,
                Status = true,
                ErrorCode = (short)ErrorCode.None
            };
            LogManagent.Instance.UploadOperationLog(o);
        }

        private void OnShowLog_Click(object sender, EventArgs e)
        {
            if (_currentInterface == CurrentInterface.DisplayLog) return;
            switch (_currentInterface)
            {
                case CurrentInterface.NowData:
                    _nowDataControl.Visible = false;
                    break;
                case CurrentInterface.HistoricalTrend:
                    _historicalTrendControl.Visible = false;
                    break;
                case CurrentInterface.UserManagent:
                    _userManagentControl.Visible = false;
                    break;
            }
            if (_displayLogControl == null)
            {
                _displayLogControl = new DisplayLogControl();
                this.Controls.Add(_displayLogControl);
                _displayLogControl.Location = new Point(42, 125);
            }
            else
            {
                _displayLogControl.Visible = true;
            }
            _currentInterface = CurrentInterface.DisplayLog;
        }

        private void OnShowUserManagent_Click(object sender, EventArgs e)
        {
            if (_currentInterface == CurrentInterface.UserManagent) return;
            switch (_currentInterface)
            {
                case CurrentInterface.NowData:
                    _nowDataControl.Visible = false;
                    break;
                case CurrentInterface.HistoricalTrend:
                    _historicalTrendControl.Visible = false;
                    break;
                case CurrentInterface.DisplayLog:
                    _displayLogControl.Visible = false;
                    break;
            }
            if (_userManagentControl == null)
            {
                _userManagentControl = new UserManagentControl();
                this.Controls.Add(_userManagentControl);
                _userManagentControl.Location = new Point(36, 135);
            }
            else
            {
                _userManagentControl.Visible = true;
            }
            _currentInterface = CurrentInterface.UserManagent;
        }
    
    
    }
}
