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
        }

        private void editProductBrowser_DocumentComplete(Browse.WebBrowserEx browser)
        {
            FenXiaoModel model = browser.Tag as FenXiaoModel;
            if (model == null)
            {
                return;
            }

            // set title
            Application.DoEvents(); 
            System.Threading.Thread.Sleep(1000);
            Application.DoEvents();

            if (!string.IsNullOrEmpty(model.TitleStatus))
            {
                HtmlElement element = browser.Document.GetElementById("TitleID");
                element.SetAttribute("value", model.NewTitle);
            }

            HtmlElement submit = browser.Document.GetElementById("event_submit_do_edit");
            ClickHelemnt(submit);
        }

        public void Run(FenXiaoModel model)
        {
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
