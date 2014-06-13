using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using tbDRP.Dock;
using WeifenLuo.WinFormsUI.Docking;

namespace tbDRP
{
    public partial class MainFrm : MainDockFrm
    {
        #region Form
        private LeftMenuFrm leftMenuFrm = new LeftMenuFrm();
        private WelcomeFrm welcomeFrm = new WelcomeFrm();
        #endregion

        public MainFrm()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            leftMenuFrm.DockAreas = DockAreas.DockLeft;
            leftMenuFrm.Show(this.MainDockPanel);

            //welcomeFrm.Show(this.MainDockPanel);

            DockContext.Current = new DockContext(this.MainDockPanel);
        }
    }
}
