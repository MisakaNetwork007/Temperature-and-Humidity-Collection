using Microsoft.EntityFrameworkCore;
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
    public partial class DisplayLogControl : UserControl
    {
        public DisplayLogControl()
        {
            InitializeComponent();
            ClearOperationLog();
            RefreshOperationLog();
        }

        private void RefreshOperationLog()
        {
            using (var context = new MyDbContext())
            {
                var operationLogs = context.OperationLogTables
                    .OrderByDescending(p => p.Id)
                    .Include(p => p.UidNavigation)
                    .Take(100)
                    .ToList();
                OperationLayoutPanel.RowCount = operationLogs.Count;
                for (int i = 0; i < operationLogs.Count; i++)
                {
                    var lab = new Label();
                    switch (operationLogs[i].OperationCode)
                    {
                        case (short)OperationCode.Login:
                            lab.Text = string.Format("{0} 于 {1} 登录。操作{2}！", operationLogs[i].UidNavigation.UserName, operationLogs[i].Datetime.ToString("yyyy-MM-dd HH:mm:ss"), operationLogs[i].Status ? "成功" : "失败");
                            break;
                        case (short)OperationCode.Logout:
                            lab.Text = string.Format("{0} 于 {1} 登出。操作{2}！", operationLogs[i].UidNavigation.UserName, operationLogs[i].Datetime.ToString("yyyy-MM-dd HH:mm:ss"), operationLogs[i].Status ? "成功" : "失败");
                            break;
                        case (short)OperationCode.MonitorData:
                            lab.Text = string.Format("{0} 于 {1} 监控数据。操作{2}！", operationLogs[i].UidNavigation.UserName, operationLogs[i].Datetime.ToString("yyyy-MM-dd HH:mm:ss"), operationLogs[i].Status ? "成功" : "失败");
                            break;
                        case (short)OperationCode.InspectData:
                            lab.Text = string.Format("{0} 于 {1} 查看历史数据。操作{2}！", operationLogs[i].UidNavigation.UserName, operationLogs[i].Datetime.ToString("yyyy-MM-dd HH:mm:ss"), operationLogs[i].Status ? "成功" : "失败");
                            break;
                        case (short)OperationCode.AddUser:
                            lab.Text = string.Format("{0} 于 {1} 添加账号为：{2}，昵称为：{3} 的用户。操作{4}！", operationLogs[i].UidNavigation.UserName, operationLogs[i].Datetime.ToString("yyyy-MM-dd HH:mm:ss")
                                , operationLogs[i].PUserAccount, operationLogs[i].PUserName, operationLogs[i].Status ? "成功" : "失败");
                            break;
                        case (short)OperationCode.UpdateUser:
                            lab.Text = string.Format("{0} 于 {1} 修改账号为：{2}，昵称为：{3} 的用户。操作{4}！", operationLogs[i].UidNavigation.UserName, operationLogs[i].Datetime.ToString("yyyy-MM-dd HH:mm:ss")
                                , operationLogs[i].PUserAccount, operationLogs[i].PUserName, operationLogs[i].Status ? "成功" : "失败");
                            break;
                        case (short)OperationCode.DeleteUser:
                            lab.Text = string.Format("{0} 于 {1} 删除账号为：{2}，昵称为：{3} 的用户。操作{4}！", operationLogs[i].UidNavigation.UserName, operationLogs[i].Datetime.ToString("yyyy-MM-dd HH:mm:ss")
                                , operationLogs[i].PUserAccount, operationLogs[i].PUserName, operationLogs[i].Status ? "成功" : "失败");
                            break;
                    }
                    OperationLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
                    lab.Font = new Font("Microsoft YaHei UI", 12F);
                    lab.Anchor = AnchorStyles.Left;
                    lab.AutoSize = true;
                    OperationLayoutPanel.Controls.Add(lab, 0, i);
                }
            }
        }

        private void RefreshWarningLog()
        {
            using (var context = new MyDbContext())
            {
                var errorLogs = context.OperationLogTables
                    .OrderByDescending(p => p.Id)
                    .Where(p => p.Status == false)
                    .Include(p => p.UidNavigation)
                    .Take(100)
                    .ToList();
                WarningLayoutPanel.RowCount = errorLogs.Count;
                for (int i = 0; i < errorLogs.Count; i++)
                {
                    var lab = new Label();
                    switch (errorLogs[i].ErrorCode)
                    {
                        case (short)ErrorCode.AccountError:
                            lab.Text = string.Format("用户于 {0} 登录时发生账号错误！输入账号为：{1}", errorLogs[i].Datetime.ToString("yyyy-MM-dd HH:mm:ss"), errorLogs[i].PUserAccount);
                            break;
                        case (short)ErrorCode.PasswordError:
                            lab.Text = string.Format("用户于 {0} 登录时发生密码错误！输入账号为：{1}", errorLogs[i].Datetime.ToString("yyyy-MM-dd HH:mm:ss"), errorLogs[i].PUserPassword);
                            break;
                        case (short)ErrorCode.AccessLevelError:
                            lab.Text = string.Format("用户 {0} 于 {1} 试图管理用户，因权限不足而失败！", errorLogs[i].UidNavigation.UserName, errorLogs[i].Datetime.ToString("yyyy-MM-dd HH:mm:ss"));
                            break;
                        case (short)ErrorCode.PAccountError:
                            lab.Text = string.Format("用户 {0} 于 {1} 增加或修改用户的账号已存在！输入账号为：{2}", errorLogs[i].UidNavigation.UserName, errorLogs[i].Datetime.ToString("yyyy-MM-dd HH:mm:ss"), errorLogs[i].PUserAccount);
                            break;
                        case (short)ErrorCode.DBTableError:
                            lab.Text = string.Format("于 {0} 发生数据表错误！", errorLogs[i].Datetime.ToString("yyyy-MM-dd HH:mm:ss"));
                            break;
                        case (short)ErrorCode.DBConncetError:
                            lab.Text = string.Format("于 {0} 发生数据库连接错误！", errorLogs[i].Datetime.ToString("yyyy-MM-dd HH:mm:ss"));
                            break;
                        case (short)ErrorCode.DBSaveChangesError:
                            lab.Text = string.Format("于 {0} 用户 {1} 保存数据发生错误！", errorLogs[i].Datetime.ToString("yyyy-MM-dd HH:mm:ss"), errorLogs[i].UidNavigation.UserName);
                            break;
                    }
                    WarningLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
                    lab.Font = new Font("Microsoft YaHei UI", 12F);
                    lab.Anchor = AnchorStyles.Left;
                    lab.AutoSize = true;
                    WarningLayoutPanel.Controls.Add(lab, 0, i);
                }
            }
        }

        private void ClearOperationLog()
        {
            OperationLayoutPanel.Controls.Clear();
            OperationLayoutPanel.RowStyles.Clear();
            OperationLayoutPanel.RowCount = 0;
        }

        private void ClearWarningLog()
        {
            WarningLayoutPanel.Controls.Clear();
            WarningLayoutPanel.RowStyles.Clear();
            WarningLayoutPanel.RowCount = 0;
        }


        private void SelectedPage(object sender, EventArgs e)
        {
            switch(TabControl.SelectedIndex)
            {
                case 0:
                    ClearOperationLog();
                    RefreshOperationLog();
                    break;
                case 1:
                    ClearWarningLog();
                    RefreshWarningLog();
                    break;
            }
        }
    }
}
