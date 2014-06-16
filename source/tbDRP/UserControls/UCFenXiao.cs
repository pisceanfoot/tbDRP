using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace tbDRP.UserControls
{
    public partial class UCFenXiao : UserControl
    {
        public UCFenXiao()
        {
            InitializeComponent();
        }

        private void BtnPublishFenxiao_Click(object sender, EventArgs e)
        {
            DockContext.Current.Show(typeof(FenXiaoFabuFrm));
        }

        private void BtnSetOnline_Click(object sender, EventArgs e)
        {
            DockContext.Current.Show(typeof(DistributionFrm));
        }
    }
}
