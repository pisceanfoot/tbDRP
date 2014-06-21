using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
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

        public string ProductID { get; set; }

        private void BtnNewTitle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnInBrowser_Click(object sender, EventArgs e)
        {
            string title = TxtTitle.Text.Trim();
            title = HttpUtility.UrlEncode(title, Context.HttpEncoding);
            string url = "http://s.taobao.com/search?q=" + title;

            Process.Start(url);
        }

        private void BtnBrowserProduct_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ProductID))
            {
                return;
            }

            string url = "http://item.taobao.com/item.htm?id=" + ProductID;
            Process.Start(url);
        }
    }
}
