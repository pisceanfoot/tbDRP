using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MT.WindowsUI.NavigationPane;
using tbDRP.Dock;

namespace tbDRP
{
    public class LeftMenuFrm : DockDocumentFrm
    {
        private NavigateBar navigateBar;

        public LeftMenuFrm()
        {
            Initialize();
        }

        private void Initialize()
        {
            this.navigateBar = new NavigateBar();
            this.navigateBar.SuspendLayout();
            // 
            // navigateBar
            // 
            this.navigateBar.AlwaysUseSystemColors = false;
            this.navigateBar.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.navigateBar.CollapsibleWidth = 112;
            this.navigateBar.DisplayedButtonCount = 2;
            this.navigateBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigateBar.IsCollapsible = false;
            this.navigateBar.Location = new System.Drawing.Point(0, 0);
            this.navigateBar.MinimumSize = new System.Drawing.Size(22, 100);
            this.navigateBar.Name = "navigateBar";
            this.navigateBar.NavigateBarDisplayedButtonCount = 2;
            this.navigateBar.SaveAndRestoreSettings = true;
            this.navigateBar.Size = new System.Drawing.Size(164, 353);
            this.navigateBar.TabIndex = 0;


            this.Controls.Add(this.navigateBar);
            this.navigateBar.ResumeLayout(false);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // LeftMenuFrm
            // 
            this.ClientSize = new System.Drawing.Size(284, 439);
            this.HideOnClose = true;
            this.MaximizeBox = false;
            this.Name = "LeftMenuFrm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TabText = "快捷菜单";
            this.Text = "快捷菜单";
            this.ResumeLayout(false);

        }
    }
}
