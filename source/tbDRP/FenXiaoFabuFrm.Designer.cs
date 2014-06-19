namespace tbDRP
{
    partial class FenXiaoFabuFrm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.numericPerPage = new System.Windows.Forms.NumericUpDown();
            this.checkBoxCurrentOnly = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numericPriceFrom = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxVender = new System.Windows.Forms.ComboBox();
            this.BtnStopFabu = new System.Windows.Forms.Button();
            this.BtnPublish = new System.Windows.Forms.Button();
            this.numericSellCount = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimeUpdateDate = new System.Windows.Forms.DateTimePicker();
            this.checkBoxInventory = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericPerPage)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericPriceFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSellCount)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.numericPerPage);
            this.splitContainer1.Panel1.Controls.Add(this.checkBoxCurrentOnly);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.comboBoxVender);
            this.splitContainer1.Panel1.Controls.Add(this.BtnStopFabu);
            this.splitContainer1.Panel1.Controls.Add(this.BtnPublish);
            this.splitContainer1.Size = new System.Drawing.Size(846, 457);
            this.splitContainer1.SplitterDistance = 101;
            this.splitContainer1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(124, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "前";
            // 
            // numericPerPage
            // 
            this.numericPerPage.Location = new System.Drawing.Point(144, 58);
            this.numericPerPage.Name = "numericPerPage";
            this.numericPerPage.Size = new System.Drawing.Size(49, 21);
            this.numericPerPage.TabIndex = 6;
            // 
            // checkBoxCurrentOnly
            // 
            this.checkBoxCurrentOnly.AutoSize = true;
            this.checkBoxCurrentOnly.Location = new System.Drawing.Point(15, 60);
            this.checkBoxCurrentOnly.Name = "checkBoxCurrentOnly";
            this.checkBoxCurrentOnly.Size = new System.Drawing.Size(96, 16);
            this.checkBoxCurrentOnly.TabIndex = 5;
            this.checkBoxCurrentOnly.Text = "仅发布当前页";
            this.checkBoxCurrentOnly.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxInventory);
            this.groupBox1.Controls.Add(this.dateTimeUpdateDate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.numericSellCount);
            this.groupBox1.Controls.Add(this.numericPriceFrom);
            this.groupBox1.Location = new System.Drawing.Point(474, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 92);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "条件";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "利润大于：";
            // 
            // numericPriceFrom
            // 
            this.numericPriceFrom.Location = new System.Drawing.Point(103, 20);
            this.numericPriceFrom.Name = "numericPriceFrom";
            this.numericPriceFrom.Size = new System.Drawing.Size(49, 21);
            this.numericPriceFrom.TabIndex = 6;
            this.numericPriceFrom.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "商家列表";
            // 
            // comboBoxVender
            // 
            this.comboBoxVender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVender.FormattingEnabled = true;
            this.comboBoxVender.Location = new System.Drawing.Point(72, 14);
            this.comboBoxVender.Name = "comboBoxVender";
            this.comboBoxVender.Size = new System.Drawing.Size(214, 20);
            this.comboBoxVender.TabIndex = 2;
            // 
            // BtnStopFabu
            // 
            this.BtnStopFabu.Location = new System.Drawing.Point(393, 27);
            this.BtnStopFabu.Name = "BtnStopFabu";
            this.BtnStopFabu.Size = new System.Drawing.Size(75, 50);
            this.BtnStopFabu.TabIndex = 1;
            this.BtnStopFabu.Text = "停止发布";
            this.BtnStopFabu.UseVisualStyleBackColor = true;
            this.BtnStopFabu.Click += new System.EventHandler(this.BtnStopFabu_Click);
            // 
            // BtnPublish
            // 
            this.BtnPublish.Location = new System.Drawing.Point(311, 27);
            this.BtnPublish.Name = "BtnPublish";
            this.BtnPublish.Size = new System.Drawing.Size(75, 50);
            this.BtnPublish.TabIndex = 1;
            this.BtnPublish.Text = "发布新品";
            this.BtnPublish.UseVisualStyleBackColor = true;
            this.BtnPublish.Click += new System.EventHandler(this.BtnPublish_Click);
            // 
            // numericSellCount
            // 
            this.numericSellCount.Location = new System.Drawing.Point(103, 53);
            this.numericSellCount.Name = "numericSellCount";
            this.numericSellCount.Size = new System.Drawing.Size(49, 21);
            this.numericSellCount.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "成交笔数大于：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(163, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "铺货时间大于：";
            // 
            // dateTimeUpdateDate
            // 
            this.dateTimeUpdateDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeUpdateDate.Location = new System.Drawing.Point(258, 19);
            this.dateTimeUpdateDate.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dateTimeUpdateDate.Name = "dateTimeUpdateDate";
            this.dateTimeUpdateDate.Size = new System.Drawing.Size(96, 21);
            this.dateTimeUpdateDate.TabIndex = 8;
            this.dateTimeUpdateDate.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // checkBoxInventory
            // 
            this.checkBoxInventory.AutoSize = true;
            this.checkBoxInventory.Location = new System.Drawing.Point(165, 55);
            this.checkBoxInventory.Name = "checkBoxInventory";
            this.checkBoxInventory.Size = new System.Drawing.Size(72, 16);
            this.checkBoxInventory.TabIndex = 9;
            this.checkBoxInventory.Text = "库存有货";
            this.checkBoxInventory.UseVisualStyleBackColor = true;
            // 
            // FenXiaoFabuFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 457);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FenXiaoFabuFrm";
            this.TabText = "发布分销商品";
            this.Text = "发布分销商品";
            this.Load += new System.EventHandler(this.FenXiaoFabuFrm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericPerPage)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericPriceFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSellCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button BtnPublish;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxVender;
        private System.Windows.Forms.Button BtnStopFabu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxCurrentOnly;
        private System.Windows.Forms.NumericUpDown numericPerPage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericPriceFrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericSellCount;
        private System.Windows.Forms.DateTimePicker dateTimeUpdateDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBoxInventory;
    }
}