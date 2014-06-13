namespace tbDRP
{
    partial class LeftMenuFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LeftMenuFrm));
            this.navigateBar = new MT.WindowsUI.NavigationPane.NavigateBar();
            this.navBtnTaobaoLogin = new MT.WindowsUI.NavigationPane.NavigateBarButton();
            this.navBtnFenXiao = new MT.WindowsUI.NavigationPane.NavigateBarButton();
            this.navigateBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // navigateBar
            // 
            this.navigateBar.AlwaysUseSystemColors = false;
            this.navigateBar.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.navigateBar.CollapsibleWidth = 27;
            this.navigateBar.Controls.Add(this.navBtnTaobaoLogin);
            this.navigateBar.Controls.Add(this.navBtnFenXiao);
            this.navigateBar.DisplayedButtonCount = 2;
            this.navigateBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigateBar.Location = new System.Drawing.Point(0, 0);
            this.navigateBar.MinimumSize = new System.Drawing.Size(22, 100);
            this.navigateBar.Name = "navigateBar";
            this.navigateBar.NavigateBarButtons.AddRange(new MT.WindowsUI.NavigationPane.NavigateBarButton[] {
            this.navBtnTaobaoLogin,
            this.navBtnFenXiao});
            this.navigateBar.NavigateBarColorTable = ((MT.WindowsUI.NavigationPane.NavigateBarColorTable)(resources.GetObject("navigateBar.NavigateBarColorTable")));
            this.navigateBar.NavigateBarDisplayedButtonCount = 2;
            this.navigateBar.SelectedButton = this.navBtnTaobaoLogin;
            this.navigateBar.Size = new System.Drawing.Size(202, 435);
            this.navigateBar.TabIndex = 0;
            this.navigateBar.Text = "navigateBar1";
            // 
            // navBtnTaobaoLogin
            // 
            this.navBtnTaobaoLogin.Caption = "淘宝用户登录";
            this.navBtnTaobaoLogin.CaptionDescription = "登录你的淘宝帐户";
            this.navBtnTaobaoLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.navBtnTaobaoLogin.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.navBtnTaobaoLogin.IsSelected = true;
            this.navBtnTaobaoLogin.IsShowCollapseScreenCaption = false;
            this.navBtnTaobaoLogin.Key = "1B604AFC148A4B30824C5E98BA1C7AFB";
            this.navBtnTaobaoLogin.Location = new System.Drawing.Point(0, 339);
            this.navBtnTaobaoLogin.MinimumSize = new System.Drawing.Size(22, 20);
            this.navBtnTaobaoLogin.Name = "navBtnTaobaoLogin";
            this.navBtnTaobaoLogin.Size = new System.Drawing.Size(202, 32);
            this.navBtnTaobaoLogin.TabIndex = 4;
            this.navBtnTaobaoLogin.ToolTipText = "登录你的淘宝帐户";
            // 
            // navBtnFenXiao
            // 
            this.navBtnFenXiao.Caption = "分销管理";
            this.navBtnFenXiao.CaptionDescription = "管理分销商品";
            this.navBtnFenXiao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.navBtnFenXiao.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.navBtnFenXiao.IsSelected = false;
            this.navBtnFenXiao.IsShowCollapseScreenCaption = false;
            this.navBtnFenXiao.Key = "862B792DEA934B8999AB34E3FC53C8A8";
            this.navBtnFenXiao.Location = new System.Drawing.Point(0, 371);
            this.navBtnFenXiao.MinimumSize = new System.Drawing.Size(22, 20);
            this.navBtnFenXiao.Name = "navBtnFenXiao";
            this.navBtnFenXiao.Size = new System.Drawing.Size(202, 32);
            this.navBtnFenXiao.TabIndex = 5;
            this.navBtnFenXiao.ToolTipText = "管理分销商品";
            // 
            // LeftMenuFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(202, 435);
            this.Controls.Add(this.navigateBar);
            this.Name = "LeftMenuFrm";
            this.TabText = "快捷导航";
            this.Text = "快捷导航";
            this.navigateBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MT.WindowsUI.NavigationPane.NavigateBar navigateBar;
        private MT.WindowsUI.NavigationPane.NavigateBarButton navBtnTaobaoLogin;
        private MT.WindowsUI.NavigationPane.NavigateBarButton navBtnFenXiao;
    }
}