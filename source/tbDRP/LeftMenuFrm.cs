using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MT.WindowsUI.NavigationPane;
using tbDRP.Dock;
using tbDRP.UserControls;

namespace tbDRP
{
    public partial class LeftMenuFrm : DockDocumentFrm
    {
        public LeftMenuFrm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            this.navBtnTaobaoLogin.RelatedControl = new UCTaobaoLogin();
            this.navBtnFenXiao.RelatedControl = new UCFenXiao();
        }
    }
}
