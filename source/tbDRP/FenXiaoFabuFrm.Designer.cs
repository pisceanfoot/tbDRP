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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxVender = new System.Windows.Forms.ComboBox();
            this.BtnPublish = new System.Windows.Forms.Button();
            this.BtnStopFabu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.comboBoxVender);
            this.splitContainer1.Panel1.Controls.Add(this.BtnStopFabu);
            this.splitContainer1.Panel1.Controls.Add(this.BtnPublish);
            this.splitContainer1.Size = new System.Drawing.Size(638, 457);
            this.splitContainer1.SplitterDistance = 101;
            this.splitContainer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "商家列表";
            // 
            // comboBoxVender
            // 
            this.comboBoxVender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVender.FormattingEnabled = true;
            this.comboBoxVender.Location = new System.Drawing.Point(72, 40);
            this.comboBoxVender.Name = "comboBoxVender";
            this.comboBoxVender.Size = new System.Drawing.Size(214, 20);
            this.comboBoxVender.TabIndex = 2;
            // 
            // BtnPublish
            // 
            this.BtnPublish.Location = new System.Drawing.Point(319, 27);
            this.BtnPublish.Name = "BtnPublish";
            this.BtnPublish.Size = new System.Drawing.Size(75, 50);
            this.BtnPublish.TabIndex = 1;
            this.BtnPublish.Text = "发布新品";
            this.BtnPublish.UseVisualStyleBackColor = true;
            this.BtnPublish.Click += new System.EventHandler(this.BtnPublish_Click);
            // 
            // BtnStopFabu
            // 
            this.BtnStopFabu.Location = new System.Drawing.Point(422, 27);
            this.BtnStopFabu.Name = "BtnStopFabu";
            this.BtnStopFabu.Size = new System.Drawing.Size(75, 50);
            this.BtnStopFabu.TabIndex = 1;
            this.BtnStopFabu.Text = "停止发布";
            this.BtnStopFabu.UseVisualStyleBackColor = true;
            this.BtnStopFabu.Click += new System.EventHandler(this.BtnStopFabu_Click);
            // 
            // FenXiaoFabuFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 457);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FenXiaoFabuFrm";
            this.TabText = "发布分销商品";
            this.Text = "发布分销商品";
            this.Load += new System.EventHandler(this.FenXiaoFabuFrm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button BtnPublish;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxVender;
        private System.Windows.Forms.Button BtnStopFabu;
    }
}