using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using tbDRP.Browse;
using tbDRP.Dock;
using tbDRP.FenXiaoShangPin;

namespace tbDRP
{
    public partial class DistributionFrm : DockDocumentFrm
    {
        private const string url = "http://goods.gongxiao.tmall.com/distributor/item/my_item_list.htm?onSale=0";
        private WebBrowserManager manager;
        private WebBrowserEx webBrowser;

        public DistributionFrm()
        {
            InitializeComponent();
        }

        private string html;
        public DistributionFrm(WebBrowserEx webBrowser)
        {
            InitializeComponent();

            this.webBrowser = webBrowser;
            manager = new WebBrowserManager(webBrowser);
            Init(webBrowser);
        }

        private void Init(WebBrowserEx webBrowser)
        {
            Stream stream = webBrowser.DocumentStream;
            stream.Position = 0;
            byte[] buffer = new byte[stream.Length];

            stream.Read(buffer, 0, buffer.Length);

            html = Context.HttpEncoding.GetString(buffer);
        }

        private void LoadOfflineProduct()
        {
            List<FenXiaoModel> list = FenXiaoManager.SplitTable(html);
            if (list == null || list.Count == 0)
            {
                return;
            }

            BindFenXiaoListView(list);
        }

        private void BindFenXiaoListView(List<FenXiaoModel> list)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<List<FenXiaoModel>>(BindFenXiaoListView), list);
            }
            else
            {
                this.listView.Items.Clear();
                this.listView.Tag = list;

                foreach (FenXiaoModel model in list)
                {
                    ListViewItem item = new ListViewItem(model.Title);

                    item.SubItems.Add(model.Price);
                    item.SubItems.Add(model.Cost);
                    item.SubItems.Add(model.DiffertialCost);
                    item.SubItems.Add(model.Partener);
                    item.SubItems.Add(model.Inventory);
                    item.SubItems.Add(model.TitleStatus);

                    listView.Items.Add(item);
                }
            }
        }

        private void DistributionFrm_Load(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(LoadOfflineProduct));
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            webBrowser = new WebBrowserEx();
            webBrowser.Navigate(url);
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
                    Init(webBrowser);

                    this.BeginInvoke(new Action(LoadOfflineProduct));
                }
            }
        }

        private void BtnChangeTitle_Click(object sender, EventArgs e)
        {
            
        }

        private int onSellClickIndex = 0;
        private void BtnOnSell_Click(object sender, EventArgs e)
        {
            BtnOnSell.Enabled = false;

            onSellClickIndex = 0;
            SetOnSell();
        }

        private EditProductFrm editProductFrm = null;
        public void SetOnSell()
        {
            List<FenXiaoModel> list = this.listView.Tag as List<FenXiaoModel>;

            if (list == null || list.Count == 0)
            {
                BtnOnSell.Enabled = true;
                return;
            }
            if (onSellClickIndex >= list.Count)
            {
                BtnOnSell.Enabled = true;
                return;
            }

            for (; onSellClickIndex < list.Count; onSellClickIndex++)
            {
                FenXiaoModel model = list[onSellClickIndex];
                if (!string.IsNullOrEmpty(model.TitleStatus))
                {
                    string title = TongKuan.TongKuanManager.GetNewTitle(model.Title);
                    if (string.IsNullOrEmpty(title))
                    {
                        continue;
                    }

                    model.NewTitle = title;
                    
                }

                onSellClickIndex++;

                if (editProductFrm == null || editProductFrm.IsDisposed)
                {
                    editProductFrm = DockContext.Current.Show(typeof(EditProductFrm), this) as EditProductFrm;
                }
                else
                {
                    editProductFrm.Show();
                }
                editProductFrm.Run(model);
                break;
            }
        }
    }
}
