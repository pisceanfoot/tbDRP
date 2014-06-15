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
        public event Action<WebBrowserEx> DocumentComplete;

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
            this.webBrowser.DocumentCompleted += webBrowser_DocumentCompleted;
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowserEx webBrowser = sender as WebBrowserEx;
            if (webBrowser.ReadyState == WebBrowserReadyState.Complete)
            {
                if (e.Url.AbsolutePath != webBrowser.Url.AbsolutePath)
                    return;

                webBrowser.DocumentCompleted -= webBrowser_DocumentCompleted;
                if (DocumentComplete != null)
                {
                    DocumentComplete(webBrowser);
                }
            }
        }
    }
}
