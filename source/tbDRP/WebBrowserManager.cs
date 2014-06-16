using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        #region Find Element
        #region Find ID

        public HtmlElement FindID(string id)
        {
            return this.webBrowser.Document.GetElementById(id);
        }
        #endregion Find ID

        #region Find ClassName
        private Regex wholeWordRegex = null;
        public HtmlElement FindClassName(string className, HtmlElement element = null)
        {
            if (string.IsNullOrEmpty(className))
            {
                return null;
            }

            wholeWordRegex = new Regex(string.Format("\\b{0}\\b", className));

            if (element == null)
            {
                element = this.webBrowser.Document.Body;
            }

            HtmlElement findElement = FindClassRecusive(element, className);
            return findElement;
        }

        private HtmlElement FindClassRecusive(HtmlElement element, string className)
        {
            if (element == null)
            {
                return null;
            }

            string elementClassName = element.GetAttribute("className");
            if (wholeWordRegex.Match(elementClassName).Success)
            {
                return element;
            }

            if (element.Children != null && element.Children.Count > 0)
            {
                foreach (HtmlElement child in element.Children)
                {
                    HtmlElement find = FindClassRecusive(child, className);
                    if (find != null)
                    {
                        return find;
                    }
                }
            }

            return null;
        }

        #endregion Find ClassName
        #endregion

        #region Action
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
        #endregion
    }
}
