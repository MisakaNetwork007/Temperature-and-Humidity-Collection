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
    public partial class AddUserControl : UserControl
    {
        public event EventHandler CloseRequested;
        public event EventHandler CancelRequested;

        public AddUserControl()
        {
            InitializeComponent();
            InitControl();
        }

        private void InitControl()
        {
            IdentityComboBox.Items.Clear();
            if(StaticData.currentUser.UserAccessLevel == 2)
            {
                IdentityComboBox.Items.AddRange(["组长", "组员"]);
            }
            else if(StaticData.currentUser.UserAccessLevel == 3)
            {
                IdentityComboBox.Items.AddRange(["管理员", "组长", "组员"]);
            }
        }

        private void Sure_Click(object sender, EventArgs e)
        {
            UserInformationTable user = new UserInformationTable();
            user.UserAccount = AccountTextBox.Text;
            user.UserPassword = PasswordTextBox.Text;
            user.UserName = NameTextBox.Text;
            user.UserAccessLevel = StaticData.GetIdentityLevel(IdentityComboBox.Text);

            if(string.IsNullOrEmpty(user.UserAccount))
            {
                MessageBox.Show("账号不得为空！", "操作提醒", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(string.IsNullOrEmpty(user.UserPassword))
            {
                MessageBox.Show("密码不得为空！", "操作提醒", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(string.IsNullOrEmpty(user.UserName))
            {
                MessageBox.Show("昵称不得为空！", "操作提醒", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(user.UserAccessLevel == 0)
            {
                MessageBox.Show("请设置用户身份！", "操作提醒", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            using(var context = new MyDbContext())
            {
                if(context.UserInformationTables.FirstOrDefault(u=>u.UserAccount == user.UserAccount) != null)
                {
                    MessageBox.Show("账号已存在！", "操作提醒", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                context.UserInformationTables.Add(user);
                int changesCount = context.SaveChanges();
                if(changesCount == 0)
                {
                    MessageBox.Show("保存失败！", "操作提醒", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }else
                {
                    var result = MessageBox.Show("保存成功！", "操作提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if(result == DialogResult.OK)
                    {
                        CloseRequested?.Invoke(this, EventArgs.Empty);
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
