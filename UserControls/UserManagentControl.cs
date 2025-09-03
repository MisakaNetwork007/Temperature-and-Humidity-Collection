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
    public partial class UserManagentControl : UserControl
    {
        public UserManagentControl()
        {
            InitializeComponent();
            InitComtrol();
        }

        private void InitComtrol()
        {
            List<UserInformationTable> users = new List<UserInformationTable>();
            using (var context = new MyDbContext())
            {
                users = context.UserInformationTables.AsNoTracking()
                    .Where(u => u.Uid != 1).ToList();
            }

            UserLayoutPanel.RowCount = users.Count + 1;
            for(int i = 0; i < users.Count; i++)
            {
                UserLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
                var label_uid = new Label();
                var label_account = new Label();
                var label_name = new Label();
                var label_identity = new Label();

                label_uid.AutoSize = true;
                label_account.AutoSize = true;
                label_name.AutoSize = true;
                label_identity.AutoSize = true;

                label_uid.Dock = DockStyle.Fill;
                label_account.Dock = DockStyle.Fill;
                label_name.Dock = DockStyle.Fill;
                label_identity.Dock = DockStyle.Fill;

                Font font = new Font("Microsoft YaHei UI", 12F);
                label_uid.Font = font;
                label_account.Font = font;
                label_name.Font = font;
                label_identity.Font = font;

                label_uid.TextAlign = ContentAlignment.MiddleCenter;
                label_account.TextAlign = ContentAlignment.MiddleCenter;
                label_name.TextAlign = ContentAlignment.MiddleCenter;
                label_identity.TextAlign = ContentAlignment.MiddleCenter;

                label_uid.Text = users[i].Uid.ToString();
                label_account.Text = users[i].UserAccount.ToString();
                label_name.Text = users[i].UserName.ToString();
                label_identity.Text = StaticData.GetIdentityName(users[i].UserAccessLevel);
                
                UserLayoutPanel.Controls.Add(label_uid, 0, i+1);
                UserLayoutPanel.Controls.Add(label_account, 1, i+1);
                UserLayoutPanel.Controls.Add(label_name, 2, i+1);
                UserLayoutPanel.Controls.Add(label_identity, 3, i+1);
            }
        }

        private void RemoveUserLayoutPanel()
        {
            for(int i = UserLayoutPanel.RowCount - 1; i > 0; i--)
            {
                for(int j = 0; j < UserLayoutPanel.ColumnCount; j++)
                {
                    Control control = UserLayoutPanel.GetControlFromPosition(j, i);
                    if (control != null)
                    {
                        UserLayoutPanel.Controls.Remove(control);
                        control.Dispose();
                    }
                }
                UserLayoutPanel.RowStyles.RemoveAt(UserLayoutPanel.RowStyles.Count-1);
            }
            UserLayoutPanel.RowCount = 1;
        }

        private void AddUser_Click(object sender, EventArgs e)
        {
            if(StaticData.currentUser.UserAccessLevel < 2)
            {
                MessageBox.Show("权限不足！", "操作提醒", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var userOperationForm = new UserOperationForm(0);
            if(userOperationForm.ShowDialog() == DialogResult.OK)
            {
                RemoveUserLayoutPanel();
                InitComtrol();
            }
        }

        private void UpdateUser_Click(object sender, EventArgs e)
        {
            if (StaticData.currentUser.UserAccessLevel < 2)
            {
                MessageBox.Show("权限不足！", "操作提醒", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var userOperationForm = new UserOperationForm(1);
            if (userOperationForm.ShowDialog() == DialogResult.OK)
            {
                RemoveUserLayoutPanel();
                InitComtrol();
            }
        }

        private void DeleteUser_Click(object sender, EventArgs e)
        {
            if (StaticData.currentUser.UserAccessLevel < 3)
            {
                MessageBox.Show("权限不足！", "操作提醒", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var userOperationForm = new UserOperationForm(2);
            if (userOperationForm.ShowDialog() == DialogResult.OK)
            {
                RemoveUserLayoutPanel();
                InitComtrol();
            }
        }
    }
}
