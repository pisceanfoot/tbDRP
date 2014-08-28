namespace tbDRP
{
    partial class DistributionFrm
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpdatePrice = new System.Windows.Forms.NumericUpDown();
            this.checkBoxSelectAll = new System.Windows.Forms.CheckBox();
            this.BtnOnSell = new System.Windows.Forms.Button();
            this.BtnChangeTitleM2 = new System.Windows.Forms.Button();
            this.BtnChangeTitle = new System.Windows.Forms.Button();
            this.BtnRefresh = new System.Windows.Forms.Button();
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.浏览BToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpdatePrice)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.BtnReset);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.numericUpdatePrice);
            this.splitContainer1.Panel1.Controls.Add(this.checkBoxSelectAll);
            this.splitContainer1.Panel1.Controls.Add(this.BtnOnSell);
            this.splitContainer1.Panel1.Controls.Add(this.BtnChangeTitleM2);
            this.splitContainer1.Panel1.Controls.Add(this.BtnChangeTitle);
            this.splitContainer1.Panel1.Controls.Add(this.BtnRefresh);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listView);
            this.splitContainer1.Size = new System.Drawing.Size(962, 610);
            this.splitContainer1.SplitterDistance = 107;
            this.splitContainer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(429, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "价格调整：";
            // 
            // numericUpdatePrice
            // 
            this.numericUpdatePrice.Location = new System.Drawing.Point(431, 55);
            this.numericUpdatePrice.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpdatePrice.Name = "numericUpdatePrice";
            this.numericUpdatePrice.Size = new System.Drawing.Size(71, 21);
            this.numericUpdatePrice.TabIndex = 2;
            // 
            // checkBoxSelectAll
            // 
            this.checkBoxSelectAll.AutoSize = true;
            this.checkBoxSelectAll.Location = new System.Drawing.Point(22, 83);
            this.checkBoxSelectAll.Name = "checkBoxSelectAll";
            this.checkBoxSelectAll.Size = new System.Drawing.Size(78, 16);
            this.checkBoxSelectAll.TabIndex = 1;
            this.checkBoxSelectAll.Text = "全选/反选";
            this.checkBoxSelectAll.UseVisualStyleBackColor = true;
            this.checkBoxSelectAll.CheckedChanged += new System.EventHandler(this.checkBoxSelectAll_CheckedChanged);
            // 
            // BtnOnSell
            // 
            this.BtnOnSell.Location = new System.Drawing.Point(214, 26);
            this.BtnOnSell.Name = "BtnOnSell";
            this.BtnOnSell.Size = new System.Drawing.Size(75, 50);
            this.BtnOnSell.TabIndex = 0;
            this.BtnOnSell.Text = "上架";
            this.BtnOnSell.UseVisualStyleBackColor = true;
            this.BtnOnSell.Click += new System.EventHandler(this.BtnOnSell_Click);
            // 
            // BtnChangeTitleM2
            // 
            this.BtnChangeTitleM2.Location = new System.Drawing.Point(321, 26);
            this.BtnChangeTitleM2.Name = "BtnChangeTitleM2";
            this.BtnChangeTitleM2.Size = new System.Drawing.Size(75, 50);
            this.BtnChangeTitleM2.TabIndex = 0;
            this.BtnChangeTitleM2.Text = "自动修改\r\n\r\n标题2";
            this.BtnChangeTitleM2.UseVisualStyleBackColor = true;
            this.BtnChangeTitleM2.Click += new System.EventHandler(this.BtnChangeTitleM2_Click);
            // 
            // BtnChangeTitle
            // 
            this.BtnChangeTitle.Location = new System.Drawing.Point(121, 26);
            this.BtnChangeTitle.Name = "BtnChangeTitle";
            this.BtnChangeTitle.Size = new System.Drawing.Size(75, 50);
            this.BtnChangeTitle.TabIndex = 0;
            this.BtnChangeTitle.Text = "修改标题";
            this.BtnChangeTitle.UseVisualStyleBackColor = true;
            this.BtnChangeTitle.Click += new System.EventHandler(this.BtnChangeTitle_Click);
            // 
            // BtnRefresh
            // 
            this.BtnRefresh.Location = new System.Drawing.Point(22, 26);
            this.BtnRefresh.Name = "BtnRefresh";
            this.BtnRefresh.Size = new System.Drawing.Size(75, 50);
            this.BtnRefresh.TabIndex = 0;
            this.BtnRefresh.Text = "刷新";
            this.BtnRefresh.UseVisualStyleBackColor = true;
            this.BtnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // listView
            // 
            this.listView.CheckBoxes = true;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader8,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.listView.ContextMenuStrip = this.contextMenuStrip1;
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(962, 499);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "名称";
            this.columnHeader1.Width = 243;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "新标题";
            this.columnHeader8.Width = 157;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "价格";
            this.columnHeader2.Width = 81;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "采购价";
            this.columnHeader3.Width = 81;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "差价";
            this.columnHeader4.Width = 78;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "供应商";
            this.columnHeader5.Width = 116;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "库存";
            this.columnHeader6.Width = 55;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "状态";
            this.columnHeader7.Width = 86;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.浏览BToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(126, 26);
            // 
            // 浏览BToolStripMenuItem
            // 
            this.浏览BToolStripMenuItem.Name = "浏览BToolStripMenuItem";
            this.浏览BToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.浏览BToolStripMenuItem.Text = "浏览(&B)...";
            this.浏览BToolStripMenuItem.Click += new System.EventHandler(this.浏览BToolStripMenuItem_Click);
            // 
            // BtnReset
            // 
            this.BtnReset.Location = new System.Drawing.Point(554, 26);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(75, 49);
            this.BtnReset.TabIndex = 4;
            this.BtnReset.Text = "重新上架";
            this.BtnReset.UseVisualStyleBackColor = true;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // DistributionFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 610);
            this.Controls.Add(this.splitContainer1);
            this.Name = "DistributionFrm";
            this.TabText = "下架商品列表";
            this.Text = "下架商品列表";
            this.Load += new System.EventHandler(this.DistributionFrm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpdatePrice)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Button BtnRefresh;
        private System.Windows.Forms.Button BtnChangeTitle;
        private System.Windows.Forms.Button BtnOnSell;
        private System.Windows.Forms.CheckBox checkBoxSelectAll;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 浏览BToolStripMenuItem;
        private System.Windows.Forms.Button BtnChangeTitleM2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpdatePrice;
        private System.Windows.Forms.Button BtnReset;
    }
}