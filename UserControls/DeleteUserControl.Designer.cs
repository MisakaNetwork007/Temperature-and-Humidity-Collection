namespace Temperature_and_Humidity_Collection.UserControls
{
    partial class DeleteUserControl
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
            UIDComboBox = new ComboBox();
            label1 = new Label();
            NameTextBox = new TextBox();
            label8 = new Label();
            AccountTextBox = new TextBox();
            button2 = new Button();
            button1 = new Button();
            label7 = new Label();
            label5 = new Label();
            IdentityTextBox = new TextBox();
            UMPopUpWindow.SuspendLayout();
            SuspendLayout();
            // 
            // UMPopUpWindow
            // 
            UMPopUpWindow.Controls.Add(IdentityTextBox);
            UMPopUpWindow.Controls.Add(UIDComboBox);
            UMPopUpWindow.Controls.Add(label1);
            UMPopUpWindow.Controls.Add(NameTextBox);
            UMPopUpWindow.Controls.Add(label8);
            UMPopUpWindow.Controls.Add(AccountTextBox);
            UMPopUpWindow.Controls.Add(button2);
            UMPopUpWindow.Controls.Add(button1);
            UMPopUpWindow.Controls.Add(label7);
            UMPopUpWindow.Controls.Add(label5);
            UMPopUpWindow.Font = new Font("Microsoft YaHei UI", 16F);
            UMPopUpWindow.Location = new Point(0, 0);
            UMPopUpWindow.Name = "UMPopUpWindow";
            UMPopUpWindow.Size = new Size(580, 362);
            UMPopUpWindow.TabIndex = 4;
            UMPopUpWindow.TabStop = false;
            UMPopUpWindow.Text = "删除用户";
            // 
            // UIDComboBox
            // 
            UIDComboBox.Font = new Font("Microsoft YaHei UI", 16F);
            UIDComboBox.FormattingEnabled = true;
            UIDComboBox.Location = new Point(144, 66);
            UIDComboBox.Name = "UIDComboBox";
            UIDComboBox.Size = new Size(183, 36);
            UIDComboBox.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 12F);
            label1.Location = new Point(73, 74);
            label1.Name = "label1";
            label1.Size = new Size(59, 21);
            label1.TabIndex = 10;
            label1.Text = "用户ID";
            // 
            // NameTextBox
            // 
            NameTextBox.Font = new Font("Microsoft YaHei UI", 16F);
            NameTextBox.Location = new Point(144, 167);
            NameTextBox.MaxLength = 20;
            NameTextBox.Name = "NameTextBox";
            NameTextBox.ReadOnly = true;
            NameTextBox.Size = new Size(368, 35);
            NameTextBox.TabIndex = 8;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft YaHei UI", 12F);
            label8.Location = new Point(73, 175);
            label8.Name = "label8";
            label8.Size = new Size(42, 21);
            label8.TabIndex = 6;
            label8.Text = "昵称";
            // 
            // AccountTextBox
            // 
            AccountTextBox.Location = new Point(144, 116);
            AccountTextBox.MaxLength = 20;
            AccountTextBox.Name = "AccountTextBox";
            AccountTextBox.ReadOnly = true;
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
            label7.Location = new Point(73, 225);
            label7.Name = "label7";
            label7.Size = new Size(42, 21);
            label7.TabIndex = 2;
            label7.Text = "身份";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft YaHei UI", 12F);
            label5.Location = new Point(73, 124);
            label5.Name = "label5";
            label5.Size = new Size(42, 21);
            label5.TabIndex = 0;
            label5.Text = "账号";
            // 
            // IdentityTextBox
            // 
            IdentityTextBox.Location = new Point(144, 217);
            IdentityTextBox.Name = "IdentityTextBox";
            IdentityTextBox.ReadOnly = true;
            IdentityTextBox.Size = new Size(183, 35);
            IdentityTextBox.TabIndex = 12;
            // 
            // DeleteUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(UMPopUpWindow);
            Name = "DeleteUserControl";
            Size = new Size(580, 362);
            UMPopUpWindow.ResumeLayout(false);
            UMPopUpWindow.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox UMPopUpWindow;
        private TextBox IdentityTextBox;
        private ComboBox UIDComboBox;
        private Label label1;
        private TextBox NameTextBox;
        private Label label8;
        private TextBox AccountTextBox;
        private Button button2;
        private Button button1;
        private Label label7;
        private Label label5;
    }
}
