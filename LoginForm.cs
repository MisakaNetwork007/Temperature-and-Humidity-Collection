using Microsoft.IdentityModel.Tokens;
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

namespace Temperature_and_Humidity_Collection
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }


        private void LoginButton_Click(object sender, EventArgs e)
        {
            string account = AccountBox.Text;
            string password = PasswordBox.Text;
            if (account.IsNullOrEmpty())
            {
                MessageBox.Show("账号不能为空！", "登录信息错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (password.IsNullOrEmpty())
            {
                MessageBox.Show("密码不能为空！", "登录信息错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (var context = new MyDbContext())
            {
                var user = context.UserInformationTables.FirstOrDefault(e => e.UserAccount == account);
                if (user == null)
                {
                    MessageBox.Show("账号不存在", "登录信息错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!user.UserPassword.Equals(password))
                {
                    MessageBox.Show("密码错误", "登录信息错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                StaticData.currentUser = user;
            }

            var result = MessageBox.Show("登陆成功", "登录信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void LookCheckBox_Click(object sender, EventArgs e)
        {
            if(LookCheckBox.Checked)
            {
                LookCheckBox.BackgroundImage = Properties.Resources.密码可视;
                PasswordBox.PasswordChar = Char.MinValue;
            }
            else
            {
                LookCheckBox.BackgroundImage = Properties.Resources.密码不可视;
                PasswordBox.PasswordChar = '*';
            }
        }
    }
}
