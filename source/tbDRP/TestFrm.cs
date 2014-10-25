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
    public partial class TestFrm : Form
    {
        private WebBrowserManager editProductBrowser;

        public TestFrm()
        {
            InitializeComponent();

            this.editProductBrowser = new WebBrowserManager();
            this.editProductBrowser.DocumentComplete += editProductBrowser_DocumentComplete;

            this.editProductBrowser.Browser.Dock = DockStyle.Fill;
            this.Controls.Add(this.editProductBrowser.Browser);
        }

        void editProductBrowser_DocumentComplete(Browse.WebBrowserEx obj)
        {
            var a = this.editProductBrowser.FindID("promoted");
            this.editProductBrowser.ClickHelemnt(a);
        }

        private void TestFrm_Load(object sender, EventArgs e)
        {
            editProductBrowser.Navigate("http://upload.taobao.com/auction/publish/edit.htm?item_num_id=41895430469&auto=false&isCheckEnd=&isFromDBHTab=false&errorCodes=");
        }

        private void dddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editProductBrowser.Navigate("http://upload.taobao.com/auction/publish/edit.htm?item_num_id=41895430469&auto=false&isCheckEnd=&isFromDBHTab=false&errorCodes=");
        }


    }
}
