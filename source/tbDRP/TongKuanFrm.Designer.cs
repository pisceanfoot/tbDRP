namespace tbDRP
{
    partial class TongKuanFrm
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
            this.label1 = new System.Windows.Forms.Label();
            this.TxtTitle = new System.Windows.Forms.TextBox();
            this.TxtNewTitle = new System.Windows.Forms.TextBox();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.BtnNewTitle = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtVender = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnInBrowser = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "标题:";
            // 
            // TxtTitle
            // 
            this.TxtTitle.Location = new System.Drawing.Point(97, 39);
            this.TxtTitle.Name = "TxtTitle";
            this.TxtTitle.Size = new System.Drawing.Size(304, 21);
            this.TxtTitle.TabIndex = 1;
            // 
            // TxtNewTitle
            // 
            this.TxtNewTitle.Location = new System.Drawing.Point(49, 113);
            this.TxtNewTitle.Multiline = true;
            this.TxtNewTitle.Name = "TxtNewTitle";
            this.TxtNewTitle.Size = new System.Drawing.Size(438, 170);
            this.TxtNewTitle.TabIndex = 2;
            // 
            // BtnSearch
            // 
            this.BtnSearch.Location = new System.Drawing.Point(412, 37);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(75, 23);
            this.BtnSearch.TabIndex = 3;
            this.BtnSearch.Text = "查找";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // BtnNewTitle
            // 
            this.BtnNewTitle.Location = new System.Drawing.Point(412, 305);
            this.BtnNewTitle.Name = "BtnNewTitle";
            this.BtnNewTitle.Size = new System.Drawing.Size(75, 23);
            this.BtnNewTitle.TabIndex = 4;
            this.BtnNewTitle.Text = "确认修改";
            this.BtnNewTitle.UseVisualStyleBackColor = true;
            this.BtnNewTitle.Click += new System.EventHandler(this.BtnNewTitle_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "商家：";
            // 
            // TxtVender
            // 
            this.TxtVender.Location = new System.Drawing.Point(97, 75);
            this.TxtVender.Name = "TxtVender";
            this.TxtVender.Size = new System.Drawing.Size(304, 21);
            this.TxtVender.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(504, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "* 新标题";
            // 
            // BtnInBrowser
            // 
            this.BtnInBrowser.Location = new System.Drawing.Point(412, 72);
            this.BtnInBrowser.Name = "BtnInBrowser";
            this.BtnInBrowser.Size = new System.Drawing.Size(75, 23);
            this.BtnInBrowser.TabIndex = 5;
            this.BtnInBrowser.Text = "浏览器查看";
            this.BtnInBrowser.UseVisualStyleBackColor = true;
            this.BtnInBrowser.Click += new System.EventHandler(this.BtnInBrowser_Click);
            // 
            // TongKuanFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 339);
            this.Controls.Add(this.BtnInBrowser);
            this.Controls.Add(this.BtnNewTitle);
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.TxtNewTitle);
            this.Controls.Add(this.TxtVender);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtTitle);
            this.Controls.Add(this.label1);
            this.Name = "TongKuanFrm";
            this.TabText = "同款标题查找";
            this.Text = "同款标题查找";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtTitle;
        private System.Windows.Forms.TextBox TxtNewTitle;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.Button BtnNewTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtVender;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnInBrowser;
    }
}