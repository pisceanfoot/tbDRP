namespace tbDRP.UserControls
{
    partial class UCTaobaoLogin
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
            this.BtnTaobaoLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnTaobaoLogin
            // 
            this.BtnTaobaoLogin.Location = new System.Drawing.Point(14, 21);
            this.BtnTaobaoLogin.Name = "BtnTaobaoLogin";
            this.BtnTaobaoLogin.Size = new System.Drawing.Size(140, 49);
            this.BtnTaobaoLogin.TabIndex = 0;
            this.BtnTaobaoLogin.Text = "淘宝登录";
            this.BtnTaobaoLogin.UseVisualStyleBackColor = true;
            this.BtnTaobaoLogin.Click += new System.EventHandler(this.BtnTaobaoLogin_Click);
            // 
            // UCTaobaoLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtnTaobaoLogin);
            this.Name = "UCTaobaoLogin";
            this.Size = new System.Drawing.Size(198, 311);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnTaobaoLogin;
    }
}
