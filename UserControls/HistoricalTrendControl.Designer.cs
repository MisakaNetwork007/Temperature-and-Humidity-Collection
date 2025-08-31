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
            tableLayoutPanel1 = new TableLayoutPanel();
            ThePastDay = new RadioButton();
            ThePastMonth = new RadioButton();
            TheLastThreeDays = new RadioButton();
            ThePastWeek = new RadioButton();
            FormsPlot = new ScottPlot.WinForms.FormsPlot();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
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
            splitContainer1.Panel1.Controls.Add(tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(FormsPlot);
            splitContainer1.Size = new Size(1154, 500);
            splitContainer1.SplitterDistance = 200;
            splitContainer1.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(ThePastDay, 0, 0);
            tableLayoutPanel1.Controls.Add(ThePastMonth, 0, 3);
            tableLayoutPanel1.Controls.Add(TheLastThreeDays, 0, 1);
            tableLayoutPanel1.Controls.Add(ThePastWeek, 0, 2);
            tableLayoutPanel1.Location = new Point(36, 136);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Size = new Size(135, 241);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // ThePastDay
            // 
            ThePastDay.AutoSize = true;
            ThePastDay.Font = new Font("Microsoft YaHei UI", 12F);
            ThePastDay.Location = new Point(3, 3);
            ThePastDay.Name = "ThePastDay";
            ThePastDay.Size = new Size(76, 25);
            ThePastDay.TabIndex = 0;
            ThePastDay.TabStop = true;
            ThePastDay.Text = "近一天";
            ThePastDay.UseVisualStyleBackColor = true;
            // 
            // ThePastMonth
            // 
            ThePastMonth.AutoSize = true;
            ThePastMonth.Font = new Font("Microsoft YaHei UI", 12F);
            ThePastMonth.Location = new Point(3, 183);
            ThePastMonth.Name = "ThePastMonth";
            ThePastMonth.Size = new Size(76, 25);
            ThePastMonth.TabIndex = 3;
            ThePastMonth.TabStop = true;
            ThePastMonth.Text = "近一月";
            ThePastMonth.UseVisualStyleBackColor = true;
            // 
            // TheLastThreeDays
            // 
            TheLastThreeDays.AutoSize = true;
            TheLastThreeDays.Font = new Font("Microsoft YaHei UI", 12F);
            TheLastThreeDays.Location = new Point(3, 63);
            TheLastThreeDays.Name = "TheLastThreeDays";
            TheLastThreeDays.Size = new Size(76, 25);
            TheLastThreeDays.TabIndex = 1;
            TheLastThreeDays.TabStop = true;
            TheLastThreeDays.Text = "近三天";
            TheLastThreeDays.UseVisualStyleBackColor = true;
            // 
            // ThePastWeek
            // 
            ThePastWeek.AutoSize = true;
            ThePastWeek.Font = new Font("Microsoft YaHei UI", 12F);
            ThePastWeek.Location = new Point(3, 123);
            ThePastWeek.Name = "ThePastWeek";
            ThePastWeek.Size = new Size(76, 25);
            ThePastWeek.TabIndex = 2;
            ThePastWeek.TabStop = true;
            ThePastWeek.Text = "近一周";
            ThePastWeek.UseVisualStyleBackColor = true;
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
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private TableLayoutPanel tableLayoutPanel1;
        private RadioButton ThePastDay;
        private RadioButton ThePastMonth;
        private RadioButton TheLastThreeDays;
        private RadioButton ThePastWeek;
        private ScottPlot.WinForms.FormsPlot FormsPlot;
    }
}
