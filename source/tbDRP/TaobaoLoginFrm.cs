using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using tbDRP.Browse;
using tbDRP.Dock;

namespace tbDRP
{
    public partial class TaobaoLoginFrm : DockDocumentFrm
    {
        private WebBrowserManager manager;

        public TaobaoLoginFrm()
        {
            InitializeComponent();

            Init();
        }

        private void Init()
        {
            manager = new WebBrowserManager();
            WebBrowser webBrowser = manager.Browser;
            
            webBrowser.Dock = DockStyle.Fill;
            this.Controls.Add(webBrowser);

            // 登录成功后跳转到分销页面
            //webBrowser.Navigate("https://login.taobao.com/member/login.jhtml?redirectURL=http%3a%2f%2fgoods.gongxiao.tmall.com%2fdistributor%2fitem%2fmy_item_list.htm%3fonSale%3d0");
            webBrowser.Navigate("http://goods.gongxiao.tmall.com/distributor/item/my_item_list.htm?onSale=0");
            webBrowser.DocumentCompleted += webBrowser_DocumentCompleted;
            
        }

        void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowserEx webBrowser = sender as WebBrowserEx;
            if (webBrowser.ReadyState == WebBrowserReadyState.Complete)
            {
                if (e.Url.AbsolutePath != webBrowser.Url.AbsolutePath)
                    return;

                if (webBrowser.Url.AbsolutePath.Contains("distributor"))
                {
                    webBrowser.DocumentCompleted -= webBrowser_DocumentCompleted;
                    DockContext.Current.Show(typeof(DistributionFrm));
                    //this.Close();
                }
            }
        }
    }
}
