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
    public partial class EditProductFrm : DockDocumentFrm
    {
        private Timer checkDownTimer;
        private Timer clickTimer;
        private WebBrowserManager editProductBrowser;
        private DistributionFrm parentFrm;

        public EditProductFrm(DistributionFrm parentFrm)
        {
            InitializeComponent();

            this.parentFrm = parentFrm; 

            this.editProductBrowser = new WebBrowserManager();
            this.editProductBrowser.DocumentComplete += editProductBrowser_DocumentComplete;

            this.editProductBrowser.Browser.Dock = DockStyle.Fill;
            this.Controls.Add(this.editProductBrowser.Browser);

            checkDownTimer = new Timer();
            checkDownTimer.Interval = 800;
            checkDownTimer.Tick += checkDownTimer_Tick;
            checkDownTimer.Enabled = false;

            this.clickTimer = new Timer();
            this.clickTimer.Tick += clickTimer_Tick;
            this.clickTimer.Interval = 700;
            this.clickTimer.Enabled = false;
        }

        private void clickTimer_Tick(object sender, EventArgs e)
        {
            this.clickTimer.Enabled = false;

            FenXiaoModel model = this.editProductBrowser.Browser.Tag as FenXiaoModel;
            if (model == null)
            {
                return;
            }

            if (!string.IsNullOrEmpty(model.TitleStatus))
            {
                HtmlElement element = this.editProductBrowser.Browser.Document.GetElementById("TitleID");
                element.SetAttribute("value", model.NewTitle);
            }

            HtmlElement submit = this.editProductBrowser.Browser.Document.GetElementById("event_submit_do_edit");
            ClickHelemnt(submit);

            this.checkDownTimer.Start();
            checkDownTimes = 0;
        }

        private int checkDownTimes = 0;
        private void checkDownTimer_Tick(object sender, EventArgs e)
        {
            checkDownTimer.Enabled = false;
            checkDownTimes++;

            if (!this.editProductBrowser.Browser.Busy)
            {
                if (this.editProductBrowser.Browser.Url.AbsolutePath.IndexOf("item.htm?id=") != -1)
                {

                }

                this.parentFrm.SetOnSell();
                return;
            }
            if (checkDownTimes >= 10)
            {
                this.parentFrm.SetOnSell();
                return;
            }

            checkDownTimer.Enabled = true;
        }

        private void editProductBrowser_DocumentComplete(Browse.WebBrowserEx browser)
        {
            if (browser.Task == "EditProduct")
            {
                this.clickTimer.Start();
                browser.Task = "";
            }
        }

        public void Run(FenXiaoModel model)
        {
            editProductBrowser.Browser.Task = "EditProduct";
            editProductBrowser.Browser.Tag = model;
            editProductBrowser.Navigate(model.Url);
        }

        public void ClickHelemnt(HtmlElement h)
        {
            Focus(h);
            Over(h);
            Down(h);
            h.InvokeMember("click");
        }

        public void Over(HtmlElement h)
        {
            h.InvokeMember("fireEvent", new object[] { "onmouseover" });
        }

        public void Down(HtmlElement h)
        {
            h.InvokeMember("fireEvent", new object[] { "onmousedown" });
        }

        public void Focus(HtmlElement h)
        {
            h.Focus();
        }
    }
}
