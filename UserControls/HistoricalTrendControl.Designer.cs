namespace Temperature_and_Humidity_Collection.UserControls
{
    partial class HistoricalTrendControl
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
            label1 = new Label();
            SlaveComboBox = new ComboBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            TemperatureButton = new RadioButton();
            HumidityButton = new RadioButton();
            tableLayoutPanel1 = new TableLayoutPanel();
            Last10 = new RadioButton();
            Last20 = new RadioButton();
            Last50 = new RadioButton();
            FormsPlot = new ScottPlot.WinForms.FormsPlot();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(SlaveComboBox);
            splitContainer1.Panel1.Controls.Add(tableLayoutPanel2);
            splitContainer1.Panel1.Controls.Add(tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(FormsPlot);
            splitContainer1.Size = new Size(1154, 500);
            splitContainer1.SplitterDistance = 200;
            splitContainer1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 12F);
            label1.Location = new Point(31, 30);
            label1.Name = "label1";
            label1.Size = new Size(58, 21);
            label1.TabIndex = 7;
            label1.Text = "从站：";
            // 
            // SlaveComboBox
            // 
            SlaveComboBox.Font = new Font("Microsoft YaHei UI", 12F);
            SlaveComboBox.FormattingEnabled = true;
            SlaveComboBox.Items.AddRange(new object[] { "1", "2", "3", "4" });
            SlaveComboBox.Location = new Point(31, 54);
            SlaveComboBox.Name = "SlaveComboBox";
            SlaveComboBox.Size = new Size(121, 29);
            SlaveComboBox.TabIndex = 6;
            SlaveComboBox.Text = "1";
            SlaveComboBox.SelectedIndexChanged += SelectSlave_Change;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(TemperatureButton, 0, 0);
            tableLayoutPanel2.Controls.Add(HumidityButton, 0, 1);
            tableLayoutPanel2.Location = new Point(31, 117);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.Size = new Size(135, 113);
            tableLayoutPanel2.TabIndex = 5;
            // 
            // TemperatureButton
            // 
            TemperatureButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            TemperatureButton.AutoSize = true;
            TemperatureButton.Checked = true;
            TemperatureButton.Font = new Font("Microsoft YaHei UI", 12F);
            TemperatureButton.Location = new Point(37, 4);
            TemperatureButton.Name = "TemperatureButton";
            TemperatureButton.Size = new Size(60, 49);
            TemperatureButton.TabIndex = 0;
            TemperatureButton.TabStop = true;
            TemperatureButton.Text = "温度";
            TemperatureButton.UseVisualStyleBackColor = true;
            TemperatureButton.Click += SelectT_Click;
            // 
            // HumidityButton
            // 
            HumidityButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            HumidityButton.AutoSize = true;
            HumidityButton.Font = new Font("Microsoft YaHei UI", 12F);
            HumidityButton.Location = new Point(37, 60);
            HumidityButton.Name = "HumidityButton";
            HumidityButton.Size = new Size(60, 49);
            HumidityButton.TabIndex = 1;
            HumidityButton.Text = "湿度";
            HumidityButton.UseVisualStyleBackColor = true;
            HumidityButton.Click += SelectH_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(Last10, 0, 0);
            tableLayoutPanel1.Controls.Add(Last20, 0, 1);
            tableLayoutPanel1.Controls.Add(Last50, 0, 2);
            tableLayoutPanel1.Location = new Point(31, 266);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Size = new Size(135, 188);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // Last10
            // 
            Last10.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            Last10.AutoSize = true;
            Last10.Checked = true;
            Last10.Font = new Font("Microsoft YaHei UI", 12F);
            Last10.Location = new Point(28, 4);
            Last10.Name = "Last10";
            Last10.Size = new Size(78, 55);
            Last10.TabIndex = 0;
            Last10.TabStop = true;
            Last10.Text = "近10条";
            Last10.UseVisualStyleBackColor = true;
            Last10.Click += Select10_Click;
            // 
            // Last20
            // 
            Last20.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            Last20.AutoSize = true;
            Last20.Font = new Font("Microsoft YaHei UI", 12F);
            Last20.Location = new Point(28, 66);
            Last20.Name = "Last20";
            Last20.Size = new Size(78, 55);
            Last20.TabIndex = 1;
            Last20.Text = "近20条";
            Last20.UseVisualStyleBackColor = true;
            Last20.Click += Select20_Click;
            // 
            // Last50
            // 
            Last50.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            Last50.AutoSize = true;
            Last50.Font = new Font("Microsoft YaHei UI", 12F);
            Last50.Location = new Point(28, 128);
            Last50.Name = "Last50";
            Last50.Size = new Size(78, 56);
            Last50.TabIndex = 2;
            Last50.Text = "近50条";
            Last50.UseVisualStyleBackColor = true;
            Last50.Click += Select50_Click;
            // 
            // FormsPlot
            // 
            FormsPlot.DisplayScale = 1F;
            FormsPlot.Dock = DockStyle.Fill;
            FormsPlot.Font = new Font("Microsoft YaHei UI", 9F);
            FormsPlot.Location = new Point(0, 0);
            FormsPlot.Name = "FormsPlot";
            FormsPlot.Size = new Size(950, 500);
            FormsPlot.TabIndex = 0;
            // 
            // HistoricalTrendControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            Name = "HistoricalTrendControl";
            Size = new Size(1154, 500);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private TableLayoutPanel tableLayoutPanel1;
        private RadioButton Last10;
        private RadioButton Last20;
        private RadioButton Last50;
        private ScottPlot.WinForms.FormsPlot FormsPlot;
        private TableLayoutPanel tableLayoutPanel2;
        private RadioButton TemperatureButton;
        private RadioButton HumidityButton;
        private Label label1;
        private ComboBox SlaveComboBox;
    }
}
