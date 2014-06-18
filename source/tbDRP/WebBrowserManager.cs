using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using tbDRP.Browse;
using tbDRP.Http;

namespace tbDRP
{
    public class WebBrowserManager
    {
        private string mailUrl = null;

        public event Action<WebBrowserEx> DocumentComplete;

        private WebBrowserEx webBrowser;

        public WebBrowserManager()
        {
            this.webBrowser = new WebBrowserEx();
            this.webBrowser.DocumentCompleted += webBrowser_DocumentCompleted;
        }

        public WebBrowserManager(WebBrowserEx webBrowser)
        {
            this.webBrowser = webBrowser;
            this.webBrowser.DocumentCompleted += webBrowser_DocumentCompleted;
        }

        public WebBrowserEx Browser
        {
            get { return this.webBrowser; }
        }

        public void Navigate(string url)
        {
            if (!string.IsNullOrEmpty(this.mailUrl))
            {
                url = NetDataManager.GetUrl(this.mailUrl, url);
            }

            this.webBrowser.Navigate(url);
            
            this.mailUrl = url;
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowserEx webBrowser = sender as WebBrowserEx;
            if (webBrowser.ReadyState == WebBrowserReadyState.Complete)
            {
                if (e.Url.AbsolutePath != webBrowser.Url.AbsolutePath)
                    return;

                if (DocumentComplete != null)
                {
                    DocumentComplete(webBrowser);
                }
            }
        }

        #region Html
        public string DocumentHtml()
        {
            return DocumentHtml(Context.HttpEncoding);
        }

        public string DocumentHtml(Encoding encoding)
        {
            Stream stream = webBrowser.DocumentStream;
            stream.Position = 0;
            byte[] buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);

            return encoding.GetString(buffer);
        }
        #endregion

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

        #region Get Position

        private int GetMaxPosition()
        {
            return this.Browser.Document.Window.Size.Height;
        }

        private int GetY()
        {
            return Browser.Document.GetElementsByTagName("HTML")[0].ScrollTop;
        }

        private int GetY(HtmlElement element)
        {
            return element.ScrollTop;
        }

        public void ToY(int y)
        {
            Browser.Document.Window.ScrollTo(0, y);
        }

        public int GetXoffset(HtmlElement element)
        {
            //get element pos
            int xPos = element.OffsetRectangle.Left;

            //get the parents pos
            HtmlElement tempEl = element.OffsetParent;
            while (tempEl != null)
            {
                xPos += tempEl.OffsetRectangle.Left;
                tempEl = tempEl.OffsetParent;
            }

            return xPos;
        }

        public int GetYoffset(HtmlElement element)
        {
            //get element pos
            int yPos = element.OffsetRectangle.Top;

            //get the parents pos
            HtmlElement tempEl = element.OffsetParent;
            while (tempEl != null)
            {
                yPos += tempEl.OffsetRectangle.Top;
                tempEl = tempEl.OffsetParent;
            }

            return yPos;
        }

        #endregion Get Position

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
