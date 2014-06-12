using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace tbDRP.Dock
{
    public class MainDockFrm : Form
    {
        // Fields
        protected DockPanel MainDockPanel = new DockPanel();

        // Methods
        public MainDockFrm()
        {
            this.MainDockPanel.ActiveAutoHideContent = null;
            this.MainDockPanel.Dock = DockStyle.Fill;
            this.MainDockPanel.Font = new Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.World);
            this.MainDockPanel.Location = new Point(0, 0x31);
            this.MainDockPanel.Name = "MainDockPanel";
            this.MainDockPanel.Size = new Size(0x318, 0x1f6);

            this.IsMdiContainer = true;
            this.Controls.Add(this.MainDockPanel);
        }
    }
}
