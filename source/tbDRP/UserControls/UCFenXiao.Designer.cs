namespace tbDRP.UserControls
{
    partial class UCFenXiao
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnPublishFenxiao = new System.Windows.Forms.Button();
            this.BtnSetOnline = new System.Windows.Forms.Button();
            this.BtnTongKuanTitle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnPublishFenxiao
            // 
            this.BtnPublishFenxiao.Location = new System.Drawing.Point(14, 21);
            this.BtnPublishFenxiao.Name = "BtnPublishFenxiao";
            this.BtnPublishFenxiao.Size = new System.Drawing.Size(140, 49);
            this.BtnPublishFenxiao.TabIndex = 0;
            this.BtnPublishFenxiao.Text = "发布分销商品";
            this.BtnPublishFenxiao.UseVisualStyleBackColor = true;
            this.BtnPublishFenxiao.Click += new System.EventHandler(this.BtnPublishFenxiao_Click);
            // 
            // BtnSetOnline
            // 
            this.BtnSetOnline.Location = new System.Drawing.Point(14, 88);
            this.BtnSetOnline.Name = "BtnSetOnline";
            this.BtnSetOnline.Size = new System.Drawing.Size(140, 49);
            this.BtnSetOnline.TabIndex = 0;
            this.BtnSetOnline.Text = "上架分销商品";
            this.BtnSetOnline.UseVisualStyleBackColor = true;
            this.BtnSetOnline.Click += new System.EventHandler(this.BtnSetOnline_Click);
            // 
            // BtnTongKuanTitle
            // 
            this.BtnTongKuanTitle.Location = new System.Drawing.Point(14, 159);
            this.BtnTongKuanTitle.Name = "BtnTongKuanTitle";
            this.BtnTongKuanTitle.Size = new System.Drawing.Size(140, 49);
            this.BtnTongKuanTitle.TabIndex = 0;
            this.BtnTongKuanTitle.Text = "同款标题查找";
            this.BtnTongKuanTitle.UseVisualStyleBackColor = true;
            this.BtnTongKuanTitle.Click += new System.EventHandler(this.BtnTongKuanTitle_Click);
            // 
            // UCFenXiao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtnTongKuanTitle);
            this.Controls.Add(this.BtnSetOnline);
            this.Controls.Add(this.BtnPublishFenxiao);
            this.Name = "UCFenXiao";
            this.Size = new System.Drawing.Size(238, 301);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnPublishFenxiao;
        private System.Windows.Forms.Button BtnSetOnline;
        private System.Windows.Forms.Button BtnTongKuanTitle;
    }
}
