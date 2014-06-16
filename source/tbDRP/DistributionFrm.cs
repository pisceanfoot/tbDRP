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
        private const string URL = "http://goods.gongxiao.tmall.com/distributor/item/my_item_list.htm?onSale=0";
        private WebBrowserEx webBrowser;
        private List<FenXiaoModel> allProductList;
        private Timer timer;

        public DistributionFrm()
        {
            InitializeComponent();

            this.allProductList = new List<FenXiaoModel>();

            this.timer = new Timer();
            this.timer.Tick += timer_Tick;
            this.timer.Interval = 500;
            this.timer.Enabled = false;
        }

        private string Init(WebBrowserEx webBrowser)
        {
            Stream stream = webBrowser.DocumentStream;
            stream.Position = 0;
            byte[] buffer = new byte[stream.Length];

            stream.Read(buffer, 0, buffer.Length);

            string documentHtml = Context.HttpEncoding.GetString(buffer);
            List<FenXiaoModel> tmp = ConvertOfflineProduct(documentHtml);
            if (tmp != null && tmp.Count > 0)
            {
                BindFenXiaoListView(tmp);

                this.allProductList.AddRange(tmp);
            }

            return documentHtml;
        }

        private List<FenXiaoModel> ConvertOfflineProduct(string html)
        {
            List<FenXiaoModel> list = FenXiaoManager.SplitTable(html);
            return list;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.timer.Enabled = false;
            
            LoadAllOfflineProduct();
        }

        private void LoadAllOfflineProduct()
        {
            allProductList.Clear();
            this.listView.Items.Clear();

            webBrowser = new WebBrowserEx();
            webBrowser.Navigate(URL);
            webBrowser.DocumentCompleted += webBrowser_DocumentCompleted;
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowserEx webBrowser = sender as WebBrowserEx;
            if (webBrowser.ReadyState == WebBrowserReadyState.Complete)
            {
                if (e.Url.AbsolutePath != webBrowser.Url.AbsolutePath)
                    return;

                if (webBrowser.Url.AbsolutePath.Contains("distributor"))
                {
                    string html = Init(webBrowser);

                    // next page
                    if (html.IndexOf("class=\"page-next\"") != -1)
                    {
                        WebBrowserManager m = new WebBrowserManager(this.webBrowser);
                        var pageContainer = m.FindID("dpl:pagination");
                        if (pageContainer != null)
                        {
                            pageContainer = m.FindClassName("page-next", pageContainer);
                        }
                        if (pageContainer != null)
                        {
                            m.ClickHelemnt(pageContainer);
                        }

                        this.TabText = "商品分销管理(加载中 ... ...)";
                    }
                    else
                    {
                        webBrowser.DocumentCompleted -= webBrowser_DocumentCompleted;
                        this.TabText = "商品分销管理(加载完成)";
                    }
                }
            }
        }

        private void BindFenXiaoListView(List<FenXiaoModel> list)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<List<FenXiaoModel>>(BindFenXiaoListView), list);
            }
            else
            {
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
            this.timer.Start();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            
            this.timer.Start();
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
            List<FenXiaoModel> list = this.allProductList;

            if (list == null || list.Count == 0)
            {
                BtnOnSell.Enabled = true;
                return;
            }
            if (onSellClickIndex >= list.Count)
            {
                BtnOnSell.Enabled = true;

                if (editProductFrm != null && !editProductFrm.IsDisposed)
                {
                    DockContext.Current.Close(typeof(EditProductFrm));
                    this.editProductFrm = null;
                }

                return;
            }

            for (; onSellClickIndex < list.Count; )
            {
                FenXiaoModel model = list[onSellClickIndex];
                if (!string.IsNullOrEmpty(model.TitleStatus))
                {
                    string title = TongKuan.TongKuanManager.GetNewTitle(model.Title);
                    if (string.IsNullOrEmpty(title))
                    {
                        // 商家原始名称
                        model.NewTitle = model.Title;
                    }
                    else
                    {
                        // 同款销量高的名称
                        model.NewTitle = title;
                    }
                }

                onSellClickIndex++;

                if (editProductFrm == null || editProductFrm.IsDisposed)
                {
                    editProductFrm = DockContext.Current.Show(typeof(EditProductFrm), this) as EditProductFrm;
                }
                else
                {
                    if (!editProductFrm.Visible)
                    {
                        editProductFrm.Show();
                    }
                }
                editProductFrm.Run(model);
                break;
            }
        }
    }
}
