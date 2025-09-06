namespace Temperature_and_Humidity_Collection.UserControls
{
    partial class DisplayLogControl
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
            TabControl = new TabControl();
            tabPage1 = new TabPage();
            OperationLayoutPanel = new TableLayoutPanel();
            label5 = new Label();
            tabPage2 = new TabPage();
            WarningLayoutPanel = new TableLayoutPanel();
            TabControl.SuspendLayout();
            tabPage1.SuspendLayout();
            OperationLayoutPanel.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // TabControl
            // 
            TabControl.Controls.Add(tabPage1);
            TabControl.Controls.Add(tabPage2);
            TabControl.Font = new Font("Microsoft YaHei UI", 12F);
            TabControl.ItemSize = new Size(100, 30);
            TabControl.Location = new Point(0, 0);
            TabControl.Multiline = true;
            TabControl.Name = "TabControl";
            TabControl.Padding = new Point(10, 5);
            TabControl.SelectedIndex = 0;
            TabControl.Size = new Size(1176, 473);
            TabControl.TabIndex = 3;
            TabControl.SelectedIndexChanged += SelectedPage;
            // 
            // tabPage1
            // 
            tabPage1.AutoScroll = true;
            tabPage1.Controls.Add(OperationLayoutPanel);
            tabPage1.ForeColor = SystemColors.ControlText;
            tabPage1.Location = new Point(4, 34);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1168, 435);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "操作日志";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // OperationLayoutPanel
            // 
            OperationLayoutPanel.AutoSize = true;
            OperationLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            OperationLayoutPanel.ColumnCount = 1;
            OperationLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            OperationLayoutPanel.Controls.Add(label5, 0, 0);
            OperationLayoutPanel.Dock = DockStyle.Top;
            OperationLayoutPanel.Location = new Point(3, 3);
            OperationLayoutPanel.Name = "OperationLayoutPanel";
            OperationLayoutPanel.RowCount = 6;
            OperationLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            OperationLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            OperationLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            OperationLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            OperationLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            OperationLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            OperationLayoutPanel.Size = new Size(1162, 247);
            OperationLayoutPanel.TabIndex = 0;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft YaHei UI", 12F);
            label5.Location = new Point(4, 10);
            label5.Margin = new Padding(3);
            label5.Name = "label5";
            label5.Size = new Size(92, 21);
            label5.TabIndex = 0;
            label5.Text = "test000001";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(WarningLayoutPanel);
            tabPage2.Location = new Point(4, 34);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1168, 435);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "错误日志";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // WarningLayoutPanel
            // 
            WarningLayoutPanel.AutoSize = true;
            WarningLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            WarningLayoutPanel.ColumnCount = 1;
            WarningLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            WarningLayoutPanel.Dock = DockStyle.Top;
            WarningLayoutPanel.Location = new Point(3, 3);
            WarningLayoutPanel.Name = "WarningLayoutPanel";
            WarningLayoutPanel.RowCount = 1;
            WarningLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            WarningLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            WarningLayoutPanel.Size = new Size(1162, 42);
            WarningLayoutPanel.TabIndex = 0;
            // 
            // DisplayLogControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(TabControl);
            Name = "DisplayLogControl";
            Size = new Size(1176, 473);
            TabControl.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            OperationLayoutPanel.ResumeLayout(false);
            OperationLayoutPanel.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl TabControl;
        private TabPage tabPage1;
        private TableLayoutPanel OperationLayoutPanel;
        private Label label5;
        private TabPage tabPage2;
        private TableLayoutPanel WarningLayoutPanel;
    }
}
