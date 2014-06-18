using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using tbDRP.Dock;

namespace tbDRP
{
    public partial class TongKuanFrm : DockDocumentFrm
    {
        public TongKuanFrm()
        {
            InitializeComponent();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string title = this.TxtTitle.Text;

            title = tbDRP.TongKuan.TongKuanManager.GetNewTitle(title);
            this.TxtNewTitle.Text = title;
        }
    }
}
