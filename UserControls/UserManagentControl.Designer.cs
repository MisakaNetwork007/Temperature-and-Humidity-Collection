namespace Temperature_and_Humidity_Collection.UserControls
{
    partial class UserManagentControl
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
            splitContainer1 = new SplitContainer();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            UserLayoutPanel = new TableLayoutPanel();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            UserLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(button3);
            splitContainer1.Panel1.Controls.Add(button2);
            splitContainer1.Panel1.Controls.Add(button1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.AutoScroll = true;
            splitContainer1.Panel2.Controls.Add(UserLayoutPanel);
            splitContainer1.Size = new Size(1194, 462);
            splitContainer1.SplitterDistance = 216;
            splitContainer1.TabIndex = 3;
            // 
            // button3
            // 
            button3.BackColor = Color.SteelBlue;
            button3.Font = new Font("Microsoft YaHei UI", 12F);
            button3.ForeColor = SystemColors.ControlLightLight;
            button3.Location = new Point(46, 286);
            button3.Name = "button3";
            button3.Size = new Size(119, 49);
            button3.TabIndex = 2;
            button3.Text = "修改用户";
            button3.UseVisualStyleBackColor = false;
            button3.Click += UpdateUser_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Red;
            button2.Font = new Font("Microsoft YaHei UI", 12F);
            button2.ForeColor = SystemColors.ControlLightLight;
            button2.Location = new Point(46, 358);
            button2.Name = "button2";
            button2.Size = new Size(119, 49);
            button2.TabIndex = 1;
            button2.Text = "删除用户";
            button2.UseVisualStyleBackColor = false;
            button2.Click += DeleteUser_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Orange;
            button1.Font = new Font("Microsoft YaHei UI", 12F);
            button1.ForeColor = SystemColors.ControlLightLight;
            button1.Location = new Point(46, 213);
            button1.Name = "button1";
            button1.Size = new Size(119, 49);
            button1.TabIndex = 0;
            button1.Text = "增加用户";
            button1.UseVisualStyleBackColor = false;
            button1.Click += AddUser_Click;
            // 
            // UserLayoutPanel
            // 
            UserLayoutPanel.AutoSize = true;
            UserLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            UserLayoutPanel.ColumnCount = 4;
            UserLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            UserLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300F));
            UserLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 250F));
            UserLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 250F));
            UserLayoutPanel.Controls.Add(label8, 3, 0);
            UserLayoutPanel.Controls.Add(label7, 2, 0);
            UserLayoutPanel.Controls.Add(label6, 1, 0);
            UserLayoutPanel.Controls.Add(label5, 0, 0);
            UserLayoutPanel.Dock = DockStyle.Top;
            UserLayoutPanel.Location = new Point(0, 0);
            UserLayoutPanel.Name = "UserLayoutPanel";
            UserLayoutPanel.RowCount = 1;
            UserLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            UserLayoutPanel.Size = new Size(974, 62);
            UserLayoutPanel.TabIndex = 0;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Dock = DockStyle.Fill;
            label8.Font = new Font("Microsoft YaHei UI", 12F);
            label8.Location = new Point(707, 4);
            label8.Margin = new Padding(3);
            label8.Name = "label8";
            label8.Size = new Size(263, 54);
            label8.TabIndex = 3;
            label8.Text = "用户身份";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Fill;
            label7.Font = new Font("Microsoft YaHei UI", 12F);
            label7.Location = new Point(456, 4);
            label7.Margin = new Padding(3);
            label7.Name = "label7";
            label7.Size = new Size(244, 54);
            label7.TabIndex = 2;
            label7.Text = "用户昵称";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Fill;
            label6.Font = new Font("Microsoft YaHei UI", 12F);
            label6.Location = new Point(155, 4);
            label6.Margin = new Padding(3);
            label6.Name = "label6";
            label6.Size = new Size(294, 54);
            label6.TabIndex = 1;
            label6.Text = "用户账号";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Microsoft YaHei UI", 12F);
            label5.Location = new Point(4, 4);
            label5.Margin = new Padding(3);
            label5.Name = "label5";
            label5.Size = new Size(144, 54);
            label5.TabIndex = 0;
            label5.Text = "用户ID";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UserManagentControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            Name = "UserManagentControl";
            Size = new Size(1194, 462);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            UserLayoutPanel.ResumeLayout(false);
            UserLayoutPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Button button3;
        private Button button2;
        private Button button1;
        private TableLayoutPanel UserLayoutPanel;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
    }
}
