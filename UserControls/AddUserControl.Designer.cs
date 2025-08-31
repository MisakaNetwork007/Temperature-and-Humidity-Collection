namespace Temperature_and_Humidity_Collection.UserControls
{
    partial class AddUserControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            UMPopUpWindow = new GroupBox();
            IdentityComboBox = new ComboBox();
            NameTextBox = new TextBox();
            PasswordTextBox = new TextBox();
            label8 = new Label();
            AccountTextBox = new TextBox();
            button2 = new Button();
            button1 = new Button();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            UMPopUpWindow.SuspendLayout();
            SuspendLayout();
            // 
            // UMPopUpWindow
            // 
            UMPopUpWindow.Controls.Add(IdentityComboBox);
            UMPopUpWindow.Controls.Add(NameTextBox);
            UMPopUpWindow.Controls.Add(PasswordTextBox);
            UMPopUpWindow.Controls.Add(label8);
            UMPopUpWindow.Controls.Add(AccountTextBox);
            UMPopUpWindow.Controls.Add(button2);
            UMPopUpWindow.Controls.Add(button1);
            UMPopUpWindow.Controls.Add(label7);
            UMPopUpWindow.Controls.Add(label6);
            UMPopUpWindow.Controls.Add(label5);
            UMPopUpWindow.Font = new Font("Microsoft YaHei UI", 16F);
            UMPopUpWindow.Location = new Point(0, 0);
            UMPopUpWindow.Name = "UMPopUpWindow";
            UMPopUpWindow.Size = new Size(580, 362);
            UMPopUpWindow.TabIndex = 3;
            UMPopUpWindow.TabStop = false;
            UMPopUpWindow.Text = "添加用户";
            // 
            // IdentityComboBox
            // 
            IdentityComboBox.Font = new Font("Microsoft YaHei UI", 16F);
            IdentityComboBox.FormattingEnabled = true;
            IdentityComboBox.Items.AddRange(new object[] { "管理员", "组长", "组员" });
            IdentityComboBox.Location = new Point(152, 213);
            IdentityComboBox.Name = "IdentityComboBox";
            IdentityComboBox.Size = new Size(183, 36);
            IdentityComboBox.TabIndex = 9;
            // 
            // NameTextBox
            // 
            NameTextBox.Font = new Font("Microsoft YaHei UI", 16F);
            NameTextBox.Location = new Point(152, 163);
            NameTextBox.MaxLength = 20;
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(368, 35);
            NameTextBox.TabIndex = 8;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new Point(152, 115);
            PasswordTextBox.MaxLength = 20;
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.Size = new Size(368, 35);
            PasswordTextBox.TabIndex = 7;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft YaHei UI", 12F);
            label8.Location = new Point(81, 171);
            label8.Name = "label8";
            label8.Size = new Size(42, 21);
            label8.TabIndex = 6;
            label8.Text = "昵称";
            // 
            // AccountTextBox
            // 
            AccountTextBox.Location = new Point(152, 66);
            AccountTextBox.MaxLength = 20;
            AccountTextBox.Name = "AccountTextBox";
            AccountTextBox.Size = new Size(368, 35);
            AccountTextBox.TabIndex = 5;
            // 
            // button2
            // 
            button2.BackColor = Color.OrangeRed;
            button2.Cursor = Cursors.Hand;
            button2.Font = new Font("Microsoft YaHei UI", 12F);
            button2.ForeColor = SystemColors.ButtonHighlight;
            button2.Location = new Point(363, 295);
            button2.Name = "button2";
            button2.Size = new Size(92, 38);
            button2.TabIndex = 4;
            button2.Text = "取消";
            button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.DarkOrange;
            button1.Cursor = Cursors.Hand;
            button1.Font = new Font("Microsoft YaHei UI", 12F);
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(126, 295);
            button1.Name = "button1";
            button1.Size = new Size(92, 38);
            button1.TabIndex = 3;
            button1.Text = "确定";
            button1.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft YaHei UI", 12F);
            label7.Location = new Point(81, 221);
            label7.Name = "label7";
            label7.Size = new Size(42, 21);
            label7.TabIndex = 2;
            label7.Text = "身份";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft YaHei UI", 12F);
            label6.Location = new Point(81, 123);
            label6.Name = "label6";
            label6.Size = new Size(42, 21);
            label6.TabIndex = 1;
            label6.Text = "密码";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft YaHei UI", 12F);
            label5.Location = new Point(81, 74);
            label5.Name = "label5";
            label5.Size = new Size(42, 21);
            label5.TabIndex = 0;
            label5.Text = "账号";
            // 
            // AddUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(UMPopUpWindow);
            Name = "AddUserControl";
            Size = new Size(580, 362);
            UMPopUpWindow.ResumeLayout(false);
            UMPopUpWindow.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox UMPopUpWindow;
        private ComboBox IdentityComboBox;
        private TextBox NameTextBox;
        private TextBox PasswordTextBox;
        private Label label8;
        private TextBox AccountTextBox;
        private Button button2;
        private Button button1;
        private Label label7;
        private Label label6;
        private Label label5;
    }
}
