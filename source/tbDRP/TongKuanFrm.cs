using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace tbDRP
{
    public partial class TongKuanFrm : Form
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
