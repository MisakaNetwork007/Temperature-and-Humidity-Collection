namespace Temperature_and_Humidity_Collection
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LoginButton = new Button();
            label1 = new Label();
            panel1 = new Panel();
            AccountBox = new TextBox();
            label2 = new Label();
            panel2 = new Panel();
            LookCheckBox = new CheckBox();
            PasswordBox = new TextBox();
            label3 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // LoginButton
            // 
            LoginButton.BackColor = SystemColors.Highlight;
            LoginButton.Cursor = Cursors.Hand;
            LoginButton.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold);
            LoginButton.ForeColor = SystemColors.ButtonHighlight;
            LoginButton.Location = new Point(113, 306);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(117, 48);
            LoginButton.TabIndex = 0;
            LoginButton.Text = "登录";
            LoginButton.UseVisualStyleBackColor = false;
            LoginButton.Click += LoginButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 16F, FontStyle.Bold);
            label1.Location = new Point(91, 73);
            label1.Name = "label1";
            label1.Size = new Size(167, 30);
            label1.TabIndex = 1;
            label1.Text = "温湿度采集系统";
            label1.UseWaitCursor = true;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(AccountBox);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(24, 162);
            panel1.Name = "panel1";
            panel1.Size = new Size(288, 53);
            panel1.TabIndex = 2;
            // 
            // AccountBox
            // 
            AccountBox.Font = new Font("Microsoft YaHei UI", 12F);
            AccountBox.Location = new Point(89, 15);
            AccountBox.MaxLength = 20;
            AccountBox.Name = "AccountBox";
            AccountBox.Size = new Size(181, 28);
            AccountBox.TabIndex = 1;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 12F);
            label2.Location = new Point(24, 18);
            label2.Name = "label2";
            label2.Size = new Size(42, 21);
            label2.TabIndex = 0;
            label2.Text = "账号";
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(LookCheckBox);
            panel2.Controls.Add(PasswordBox);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(24, 221);
            panel2.Name = "panel2";
            panel2.Size = new Size(288, 53);
            panel2.TabIndex = 3;
            // 
            // LookCheckBox
            // 
            LookCheckBox.Appearance = Appearance.Button;
            LookCheckBox.BackgroundImage = Properties.Resources.密码不可视;
            LookCheckBox.BackgroundImageLayout = ImageLayout.Zoom;
            LookCheckBox.Location = new Point(246, 18);
            LookCheckBox.Name = "LookCheckBox";
            LookCheckBox.RightToLeft = RightToLeft.No;
            LookCheckBox.Size = new Size(24, 24);
            LookCheckBox.TabIndex = 2;
            LookCheckBox.UseVisualStyleBackColor = true;
            LookCheckBox.Click += LookCheckBox_Click;
            // 
            // PasswordBox
            // 
            PasswordBox.Font = new Font("Microsoft YaHei UI", 12F);
            PasswordBox.Location = new Point(89, 15);
            PasswordBox.MaxLength = 20;
            PasswordBox.Name = "PasswordBox";
            PasswordBox.PasswordChar = '*';
            PasswordBox.Size = new Size(181, 28);
            PasswordBox.TabIndex = 1;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft YaHei UI", 12F);
            label3.Location = new Point(24, 18);
            label3.Name = "label3";
            label3.Size = new Size(42, 21);
            label3.TabIndex = 0;
            label3.Text = "密码";
            // 
            // LoginForm
            // 
            AcceptButton = LoginButton;
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(344, 441);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(LoginButton);
            MaximizeBox = false;
            Name = "LoginForm";
            Text = "登陆界面";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button LoginButton;
        private Label label1;
        private Panel panel1;
        private Label label2;
        private TextBox AccountBox;
        private Panel panel2;
        private TextBox PasswordBox;
        private Label label3;
        private CheckBox LookCheckBox;
    }
}