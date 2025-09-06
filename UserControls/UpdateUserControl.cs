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
    public partial class UpdateUserControl : UserControl
    {

        public event EventHandler CloseRequested;
        public event EventHandler CancelRequested;
        List<UserInformationTable> users = new List<UserInformationTable>();

        public UpdateUserControl()
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
            IdentityComboBox.Items.Clear();
            if (StaticData.currentUser.UserAccessLevel == 2)
            {
                IdentityComboBox.Items.AddRange(["组长", "组员"]);
            }
            else if (StaticData.currentUser.UserAccessLevel == 3)
            {
                IdentityComboBox.Items.AddRange(["管理员", "组长", "组员"]);
            }
        }

        private void UID_Select(object sender, EventArgs e)
        {
            var user = users.Find(e => e.Uid == int.Parse(UIDComboBox.Text));
            if (user == null) return;
            AccountTextBox.Text = user.UserAccount;
            PasswordTextBox.Text = user.UserPassword;
            NameTextBox.Text = user.UserName;
            IdentityComboBox.Text = StaticData.GetIdentityName(user.UserAccessLevel);
        }

        private void Sure_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(UIDComboBox.Text))
            {
                MessageBox.Show("请选择用户UID！", "操作提醒", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(string.IsNullOrEmpty(AccountTextBox.Text))
            {
                MessageBox.Show("账号不能为空！", "操作提醒", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(PasswordTextBox.Text))
            {
                MessageBox.Show("密码不能为空！", "操作提醒", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(NameTextBox.Text))
            {
                MessageBox.Show("昵称不能为空！", "操作提醒", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(IdentityComboBox.Text))
            {
                MessageBox.Show("请设置身份！", "操作提醒", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var context = new MyDbContext())
            {
                var user = context.UserInformationTables.FirstOrDefault(e => e.Uid == int.Parse(UIDComboBox.Text));
                if (user == null)
                {
                    MessageBox.Show("用户不存在！", "操作提醒", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(user.UserAccount == AccountTextBox.Text)
                {
                    OperationLogTable o = new OperationLogTable()
                    {
                        Uid = StaticData.currentUser.Uid,
                        Datetime = DateTime.Now,
                        OperationCode = (short)OperationCode.UpdateUser,
                        Status = false,
                        PUserAccount = user.UserAccount,
                        PUserPassword = user.UserPassword,
                        PUserName = user.UserName,
                        PUserAccessLevel = user.UserAccessLevel,
                        ErrorCode = (short)ErrorCode.PAccountError
                    };
                    LogManagent.Instance.UploadOperationLog(o);

                    MessageBox.Show("用户账号已存在！", "操作提醒", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    user.UserAccount = AccountTextBox.Text;
                    user.UserPassword = PasswordTextBox.Text;
                    user.UserName = NameTextBox.Text;
                    user.UserAccessLevel = StaticData.GetIdentityLevel(IdentityComboBox.Text);
                    int changesCount = context.SaveChanges();
                    if (changesCount == 0)
                    {
                        OperationLogTable o = new OperationLogTable()
                        {
                            Uid = StaticData.currentUser.Uid,
                            Datetime = DateTime.Now,
                            OperationCode = (short)OperationCode.UpdateUser,
                            Status = false,
                            PUserAccount = user.UserAccount,
                            PUserPassword = user.UserPassword,
                            PUserName = user.UserName,
                            PUserAccessLevel = user.UserAccessLevel,
                            ErrorCode = (short)ErrorCode.DBSaveChangesError
                        };
                        LogManagent.Instance.UploadOperationLog(o);

                        MessageBox.Show("更新失败！", "操作提醒", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


                        var result = MessageBox.Show("更新成功！", "操作提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
