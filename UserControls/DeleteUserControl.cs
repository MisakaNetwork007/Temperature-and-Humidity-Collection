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
using Temperature_and_Humidity_Collection.Models;

namespace Temperature_and_Humidity_Collection.UserControls
{
    public partial class DeleteUserControl : UserControl
    {

        public event EventHandler CloseRequested;
        public event EventHandler CancelRequested;
        List<UserInformationTable> users = new List<UserInformationTable>();

        public DeleteUserControl()
        {
            InitializeComponent();
            InitControl();
        }

        private void InitControl()
        {
            using (var context = new MyDbContext())
            {
                users = context.UserInformationTables
                    .Where(u => u.Uid != 1 && u.UserAccessLevel <= StaticData.currentUser.UserAccessLevel)
                    .ToList();
            }
            UIDComboBox.Items.AddRange(users.Select(u => u.Uid as object).ToArray());
        }

        private void UIDChange_Select(object sender, EventArgs e)
        {
            var user = users.Find(e => e.Uid == int.Parse(UIDComboBox.Text));
            if (user == null) return;
            AccountTextBox.Text = user.UserAccount;
            NameTextBox.Text = user.UserName;
            IdentityTextBox.Text = StaticData.GetIdentityName(user.UserAccessLevel);
        }

        private void Sure_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(UIDComboBox.Text))
            {
                MessageBox.Show("请选择用户UID！", "操作提醒", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var context = new MyDbContext())
            {
                var user = users.Find(e => e.Uid == int.Parse(UIDComboBox.Text));
                if (user != null)
                {
                    context.UserInformationTables.Remove(user);
                    int changesCount = context.SaveChanges();
                    if (changesCount == 0)
                    {
                        OperationLogTable o = new OperationLogTable()
                        {
                            Uid = StaticData.currentUser.Uid,
                            Datetime = DateTime.Now,
                            OperationCode = (short)OperationCode.DeleteUser,
                            Status = false,
                            PUserAccount = user.UserAccount,
                            PUserPassword = user.UserPassword,
                            PUserName = user.UserName,
                            PUserAccessLevel = user.UserAccessLevel,
                            ErrorCode = (short)ErrorCode.DBSaveChangesError
                        };
                        LogManagent.Instance.UploadOperationLog(o);

                        MessageBox.Show("删除失败！", "操作提醒", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        OperationLogTable o = new OperationLogTable()
                        {
                            Uid = StaticData.currentUser.Uid,
                            Datetime = DateTime.Now,
                            OperationCode = (short)OperationCode.DeleteUser,
                            Status = true,
                            PUserAccount = user.UserAccount,
                            PUserPassword = user.UserPassword,
                            PUserName = user.UserName,
                            PUserAccessLevel = user.UserAccessLevel,
                            ErrorCode = (short)ErrorCode.None
                        };
                        LogManagent.Instance.UploadOperationLog(o);

                        var result = MessageBox.Show("删除成功！", "操作提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (result == DialogResult.OK)
                        {
                            CloseRequested?.Invoke(this, EventArgs.Empty);
                        }
                    }
                }
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            CancelRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}
