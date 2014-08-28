using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

                        ThreadRunner.Run(new Action(SearchNewTitle));
                    }
                }
            }
        }

        private void SearchNewTitle()
        {
            if (this.allProductList == null || this.allProductList.Count == 0)
            {
                return;
            }

            int i = 0;
            foreach (FenXiaoModel model in this.allProductList)
            {
                string title = TongKuan.TongKuanManager.GetNewTitle(model.Title, model.Partener);
                if (!string.IsNullOrEmpty(title))
                {
                    // 同款销量高的名称
                    model.NewTitle = title;

                    SetNewTitle(i, title);
                }
                i++;
            }

            SetTitle(">>(新标题搜索完成2)");
        }

        private void SearchNewTitleM2()
        {
            if (this.allProductList == null || this.allProductList.Count == 0)
            {
                return;
            }

            int i = 0;
            foreach (FenXiaoModel model in this.allProductList)
            {
                if (string.IsNullOrEmpty(model.NewTitle))
                {
                    string title = TongKuan.TongKuanManager.GetNewTitle2(model.Title);
                    if (!string.IsNullOrEmpty(title))
                    {
                        // 同款销量高的名称
                        model.NewTitle = title;

                        SetNewTitle(i, title);
                    }
                }
                i++;
            }

            SetTitle(">>(新标题搜索完成)");
        }

        private void SetNewTitle(int index, string newTitle)
        {
            if (this.listView.InvokeRequired)
            {
                this.listView.Invoke(new Action<int, string>(SetNewTitle), index, newTitle);
            }
            else
            {
                ListViewItem item = this.listView.Items[index];
                item.SubItems[1].Text = newTitle;
            }
        }

        private void SetTitle(string newTitle)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(SetTitle), newTitle);
            }
            else
            {
                this.TabText += newTitle;
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
                this.checkBoxSelectAll.Checked = list.Count > 0;

                foreach (FenXiaoModel model in list)
                {
                    ListViewItem item = new ListViewItem(model.Title);
                    item.Checked = true;
                    item.Tag = model;

                    item.SubItems.Add(model.NewTitle);
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

            if (onSellClickIndex < list.Count)
            {
                for (; onSellClickIndex < list.Count; )
                {
                    FenXiaoModel model = list[onSellClickIndex];
                    ListViewItem item = listView.Items[onSellClickIndex];
                    if (!item.Checked)
                    {
                        onSellClickIndex++;
                        continue;
                    }
                    if (model.TitleStatus == "已提交")
                    {
                        onSellClickIndex++;
                        continue;
                    }

                    if (!string.IsNullOrEmpty(model.TitleStatus) &&
                        model.TitleStatus != "已提交" &&
                        string.IsNullOrEmpty(model.NewTitle))
                    {
                        string title = TongKuan.TongKuanManager.GetNewTitle(model.Title, model.Partener);
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
                    if (numericUpdatePrice.Value != 0)
                    {
                        model.ChangePrice = numericUpdatePrice.Value;
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

                    item.SubItems[7].Text = "已提交";
                    model.TitleStatus = "已提交";
                    return;
                }
            }

            BtnOnSell.Enabled = true;

            if (editProductFrm != null && !editProductFrm.IsDisposed)
            {
                DockContext.Current.Close(typeof(EditProductFrm));
                this.editProductFrm = null;
            }
        }

        private void checkBoxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            bool check =  checkBoxSelectAll.Checked;
            if (listView.Items.Count > 0)
            {
                foreach (ListViewItem item in listView.Items)
                {
                    item.Checked = check;
                }
            }
        }

        private void BtnChangeTitle_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems == null || listView.SelectedItems.Count == 0)
            {
                return;
            }

            ListViewItem item = listView.SelectedItems[0];
            FenXiaoModel model = item.Tag as FenXiaoModel;

            TongKuanFrm form = new TongKuanFrm();
            form.Title = model.Title;
            form.Vender = model.Partener;
            form.ProductID = model.ID;
            form.NewTitle = model.NewTitle;
            if (form.ShowDialog() == DialogResult.OK)
            {
                model.NewTitle = form.NewTitle;

                // 新标题
                item.SubItems[1].Text = model.NewTitle;
            }
        }

        private void 浏览BToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listView.SelectedItems == null || this.listView.SelectedItems.Count == 0)
            {
                return;
            }

            ListViewItem item = this.listView.SelectedItems[0];
            FenXiaoModel model = item.Tag as FenXiaoModel;

            string url = "http://item.taobao.com/item.htm?id=" + model.ID;
            Process.Start(url);
        }

        private void BtnChangeTitleM2_Click(object sender, EventArgs e)
        {
            this.TabText = "开始执行方法2";
            ThreadRunner.Run(new Action(SearchNewTitleM2));
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            BtnOnSell.Enabled = true;
        }
    }
}
