using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeifenLuo.WinFormsUI.Docking;

namespace tbDRP.Dock
{
    public class DockDocumentFrm : DockContent
    {
        // Methods
        public DockDocumentFrm()
        {
            base.AllowEndUserDocking = false;
            base.DockAreas = DockAreas.Document;

            if (string.IsNullOrEmpty(this.TabText))
            {
                this.TabText = this.Text;
            }
        }
    }
}
