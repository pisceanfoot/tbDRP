using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace tbDRP
{
    public class WebBrowserManager
    {


        private WebBrowser webBrowser;

        public WebBrowserManager()
        {
            this.webBrowser = new WebBrowser();
        }

        public WebBrowserManager(WebBrowser webBrowser)
        {
            this.webBrowser = webBrowser;
        }

        public WebBrowser Browser
        {
            get { return this.webBrowser; }
        }

        public void Navigate(string url)
        {
            this.webBrowser.Navigate(url);
        }
    }
}
