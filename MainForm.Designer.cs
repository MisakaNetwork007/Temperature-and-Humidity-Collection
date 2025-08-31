namespace Temperature_and_Humidity_Collection
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            CurTimeLabel = new Label();
            IdentityLabel = new Label();
            CurUserLabel = new Label();
            label1 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            DataMonitoringButton = new Button();
            HistoricalTrendButton = new Button();
            DisplayLogButton = new Button();
            UserManagementButton = new Button();
            panel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.MediumSeaGreen;
            panel1.Controls.Add(CurTimeLabel);
            panel1.Controls.Add(IdentityLabel);
            panel1.Controls.Add(CurUserLabel);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1264, 104);
            panel1.TabIndex = 0;
            // 
            // CurTimeLabel
            // 
            CurTimeLabel.AutoSize = true;
            CurTimeLabel.Font = new Font("Microsoft YaHei UI", 16F, FontStyle.Bold);
            CurTimeLabel.ForeColor = SystemColors.ControlLightLight;
            CurTimeLabel.Location = new Point(1061, 19);
            CurTimeLabel.Name = "CurTimeLabel";
            CurTimeLabel.Size = new Size(191, 60);
            CurTimeLabel.TabIndex = 3;
            CurTimeLabel.Text = "2025年 8月 28号\r\n21：25";
            CurTimeLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // IdentityLabel
            // 
            IdentityLabel.AutoSize = true;
            IdentityLabel.Font = new Font("Microsoft YaHei UI", 16F);
            IdentityLabel.Location = new Point(851, 49);
            IdentityLabel.Name = "IdentityLabel";
            IdentityLabel.RightToLeft = RightToLeft.No;
            IdentityLabel.Size = new Size(145, 30);
            IdentityLabel.TabIndex = 2;
            IdentityLabel.Text = "身份：管理员";
            // 
            // CurUserLabel
            // 
            CurUserLabel.AutoSize = true;
            CurUserLabel.Font = new Font("Microsoft YaHei UI", 16F);
            CurUserLabel.Location = new Point(851, 17);
            CurUserLabel.Name = "CurUserLabel";
            CurUserLabel.Size = new Size(167, 30);
            CurUserLabel.TabIndex = 1;
            CurUserLabel.Text = "当前用户：张三";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 36F);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(55, 17);
            label1.Name = "label1";
            label1.Size = new Size(171, 62);
            label1.TabIndex = 0;
            label1.Text = "欢迎！";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = SystemColors.Info;
            flowLayoutPanel1.Controls.Add(DataMonitoringButton);
            flowLayoutPanel1.Controls.Add(HistoricalTrendButton);
            flowLayoutPanel1.Controls.Add(DisplayLogButton);
            flowLayoutPanel1.Controls.Add(UserManagementButton);
            flowLayoutPanel1.Dock = DockStyle.Bottom;
            flowLayoutPanel1.Location = new Point(0, 625);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(150, 0, 150, 0);
            flowLayoutPanel1.Size = new Size(1264, 56);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // DataMonitoringButton
            // 
            DataMonitoringButton.BackColor = SystemColors.MenuHighlight;
            DataMonitoringButton.Font = new Font("Microsoft YaHei UI", 12F);
            DataMonitoringButton.ForeColor = SystemColors.ControlLightLight;
            DataMonitoringButton.Location = new Point(200, 3);
            DataMonitoringButton.Margin = new Padding(50, 3, 50, 3);
            DataMonitoringButton.Name = "DataMonitoringButton";
            DataMonitoringButton.Size = new Size(137, 53);
            DataMonitoringButton.TabIndex = 0;
            DataMonitoringButton.Text = "数据监控";
            DataMonitoringButton.UseVisualStyleBackColor = false;
            // 
            // HistoricalTrendButton
            // 
            HistoricalTrendButton.BackColor = Color.Coral;
            HistoricalTrendButton.Font = new Font("Microsoft YaHei UI", 12F);
            HistoricalTrendButton.ForeColor = SystemColors.ControlLightLight;
            HistoricalTrendButton.Location = new Point(437, 3);
            HistoricalTrendButton.Margin = new Padding(50, 3, 50, 3);
            HistoricalTrendButton.Name = "HistoricalTrendButton";
            HistoricalTrendButton.Size = new Size(137, 53);
            HistoricalTrendButton.TabIndex = 1;
            HistoricalTrendButton.Text = "历史趋势";
            HistoricalTrendButton.UseVisualStyleBackColor = false;
            // 
            // DisplayLogButton
            // 
            DisplayLogButton.BackColor = SystemColors.MenuHighlight;
            DisplayLogButton.Font = new Font("Microsoft YaHei UI", 12F);
            DisplayLogButton.ForeColor = SystemColors.ControlLightLight;
            DisplayLogButton.Location = new Point(674, 3);
            DisplayLogButton.Margin = new Padding(50, 3, 50, 3);
            DisplayLogButton.Name = "DisplayLogButton";
            DisplayLogButton.Size = new Size(137, 53);
            DisplayLogButton.TabIndex = 2;
            DisplayLogButton.Text = "日志显示";
            DisplayLogButton.UseVisualStyleBackColor = false;
            // 
            // UserManagementButton
            // 
            UserManagementButton.BackColor = Color.Coral;
            UserManagementButton.Font = new Font("Microsoft YaHei UI", 12F);
            UserManagementButton.ForeColor = SystemColors.ControlLightLight;
            UserManagementButton.Location = new Point(911, 3);
            UserManagementButton.Margin = new Padding(50, 3, 50, 3);
            UserManagementButton.Name = "UserManagementButton";
            UserManagementButton.Size = new Size(137, 53);
            UserManagementButton.TabIndex = 3;
            UserManagementButton.Text = "用户管理";
            UserManagementButton.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(panel1);
            MaximizeBox = false;
            Name = "MainForm";
            Text = "温湿度采集系统";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button DataMonitoringButton;
        private Button HistoricalTrendButton;
        private Button DisplayLogButton;
        private Button UserManagementButton;
        private Label label1;
        private Label IdentityLabel;
        private Label CurUserLabel;
        private Label CurTimeLabel;
    }
}
