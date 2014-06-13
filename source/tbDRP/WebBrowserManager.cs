using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using tbDRP.Browse;

namespace tbDRP
{
    public class WebBrowserManager
    {


        private WebBrowserEx webBrowser;

        public WebBrowserManager()
        {
            this.webBrowser = new WebBrowserEx();
        }

        public WebBrowserManager(WebBrowserEx webBrowser)
        {
            this.webBrowser = webBrowser;
        }

        public WebBrowserEx Browser
        {
            get { return this.webBrowser; }
        }

        public void Navigate(string url)
        {
            this.webBrowser.Navigate(url);
        }
    }
}
