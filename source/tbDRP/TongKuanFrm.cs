using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using tbDRP.Dock;
using tbDRP.FenXiaoShangPin;

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

            title = tbDRP.TongKuan.TongKuanManager.GetNewTitle(title, this.TxtVender.Text);
            this.TxtNewTitle.Text = title;
        }

        public string Title
        {
            set { this.TxtTitle.Text = value; }
        }

        public string Vender
        {
            set { this.TxtVender.Text = value; }
        }

        public string NewTitle
        {
            get
            {
                return this.TxtNewTitle.Text;
            }
        }

        private void BtnNewTitle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
