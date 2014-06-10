namespace tbDRP
{
    partial class MainFrm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnStart = new System.Windows.Forms.Button();
            this.BtnTitle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(344, 139);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "淘宝用户";
            // 
            // BtnStart
            // 
            this.BtnStart.Location = new System.Drawing.Point(279, 170);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(75, 23);
            this.BtnStart.TabIndex = 1;
            this.BtnStart.Text = "启动";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // BtnTitle
            // 
            this.BtnTitle.Location = new System.Drawing.Point(12, 170);
            this.BtnTitle.Name = "BtnTitle";
            this.BtnTitle.Size = new System.Drawing.Size(75, 23);
            this.BtnTitle.TabIndex = 2;
            this.BtnTitle.Text = "标题";
            this.BtnTitle.UseVisualStyleBackColor = true;
            this.BtnTitle.Click += new System.EventHandler(this.BtnTitle_Click);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 214);
            this.Controls.Add(this.BtnTitle);
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainFrm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.Button BtnTitle;
    }
}

