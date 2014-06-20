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
using tbDRP.FenXiaoShangPin;
using tbDRP.Http;

namespace tbDRP
{
    public partial class FenXiaoFabuFrm : DockDocumentFrm
    {
        private const string URL = "http://gongxiao.tmall.com/distributor/user/my_supplier.htm";

        private WebBrowserManager manager;
        private List<VenderModel> list;

        private Timer addFenXiaoProductTimer;
        private Timer checkDownTimer;

        public FenXiaoFabuFrm()
        {
            InitializeComponent();

            list = new List<VenderModel>();

            manager = new WebBrowserManager();
            manager.DocumentComplete += manager_DocumentComplete;
            
            WebBrowser browser = manager.Browser;
            browser.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(browser);

            addFenXiaoProductTimer = new Timer();
            addFenXiaoProductTimer.Interval = 500;
            addFenXiaoProductTimer.Tick += addFenXiaoProductTimer_Tick;
            addFenXiaoProductTimer.Enabled = false;

            checkDownTimer = new Timer();
            checkDownTimer.Interval = 800;
            checkDownTimer.Tick += checkDownTimer_Tick;
            checkDownTimer.Enabled = false;
        }

        private void InitList()
        {
            list.Clear();
            list.Add(new VenderModel() { ID = "all", ShortName = "全部" });
        }

        private int venderIndex = 0;
        private bool publishAllVender = false;
        private void BtnPublish_Click(object sender, EventArgs e)
        {
            startPublishNewProduct = true;

            if (checkBoxCurrentOnly.Checked)
            {
                publishAllVender = false;
                PublishCurrentPage();
            }
            else
            {
                venderIndex = this.comboBoxVender.SelectedIndex;
                if (venderIndex == 0)
                {
                    publishAllVender = true;
                    venderIndex = 1;
                }
                else
                {
                    publishAllVender = false;
                }

                Vender();
            }
        }

        private void Vender()
        {
            if (venderIndex < this.list.Count)
            {
                VenderModel model = this.list[venderIndex++];

                this.manager.Browser.Task = "Publish";
                this.manager.Navigate(model.ProductUrl);
            }
        }

        private void FenXiaoFabuFrm_Load(object sender, EventArgs e)
        {
            InitList();
            manager.Browser.Task = "Vender";
            manager.Navigate(URL);
        }

        private void manager_DocumentComplete(Browse.WebBrowserEx browser)
        {
            if (browser.Task == "Vender")
            {
                // 切换商家
                LoadVenderList(browser);
                
            }
            else if (browser.Task == "Publish")
            {
                // 产品列表
                Publish(browser);
            }
        }

        #region Vender
        private void LoadVenderList(WebBrowserEx browser)
        {
            string html = manager.DocumentHtml();
            List<VenderModel> tmp = FenXiaoManager.GetVender(html);
            if (tmp != null && tmp.Count > 0)
            {
                this.list.AddRange(tmp);
            }

            // 分页处理
            if (html.IndexOf("class=\"page-next\"") != -1)
            {
                var htmlElement = manager.FindID("dpl:pagination");
                if (htmlElement != null)
                {
                    htmlElement = manager.FindClassName("page-next");
                    if (htmlElement != null)
                    {
                        manager.ClickHelemnt(htmlElement);

                        this.TabText = "发布分销商品(商家列表加载中...)";
                        return;
                    }
                }

                this.TabText = "发布分销商品(商家列表加载完成)";
                BindVenderList();
            }
            else
            {
                this.TabText = "发布分销商品(商家列表加载完成)";
                BindVenderList();
            }
        }

        private void BindVenderList()
        {
            this.comboBoxVender.DataSource = list;
            this.comboBoxVender.DisplayMember = "ShortName";
            this.comboBoxVender.ValueMember = "ID";

            this.manager.Browser.Task = "Vender_Done";
        }
        #endregion

        #region Product
        private void checkDownTimer_Tick(object sender, EventArgs e)
        {
            checkDownTimer.Enabled = false;

            if (!this.manager.Browser.Busy)
            {
                //if (this.manager.Browser.Url.AbsolutePath.IndexOf("item.htm?id=") != -1)
                //{

                //}

                //this.parentFrm.SetOnSell();
                addFenXiaoProductTimer.Start();
                return;
            }

            checkDownTimer.Enabled = true;
        }
        private int fenxiaoProductListIndex = 0;
        private int addProductCount = 0;
        
        private List<FenXiaoModel> fenxiaoProductList;
        private void Publish(WebBrowserEx browser)
        {
            fenxiaoProductListIndex = 0;
            addProductCount = 0;

            if (fenxiaoProductList == null)
            {
                fenxiaoProductList = new List<FenXiaoModel>();
            }
            fenxiaoProductList.Clear();
            string html = this.manager.DocumentHtml();

            List<FenXiaoModel> tmpList = FenXiaoManager.GetProductFromVender(html);
            if (tmpList != null && tmpList.Count > 0)
            {
                fenxiaoProductList.AddRange(tmpList);
                addFenXiaoProductTimer.Start();
            }
            else
            {
                // 下一个 vender
                if (publishAllVender)
                {
                    Vender();
                }
            }
        }

        private void addFenXiaoProductTimer_Tick(object sender, EventArgs e)
        {
            addFenXiaoProductTimer.Enabled = false;

            if (!startPublishNewProduct)
            {
                return;
            }

            int maxFenXiaoCount = (int)numericPerPage.Value;
            if (maxFenXiaoCount > 0)
            {
                if (addProductCount >= maxFenXiaoCount)
                {
                    return;
                }
            }

            if (fenxiaoProductListIndex < fenxiaoProductList.Count)
            {
                int findProductIndex = fenxiaoProductListIndex;
                fenxiaoProductListIndex++;
                
                FenXiaoModel model = fenxiaoProductList[findProductIndex];

                if (Filter(model))
                {
                    return;
                }

                HtmlElement table = manager.FindID("J_MyItemList");
                HtmlElementCollection trCol = table.GetElementsByTagName("tr");

                HtmlElement tr = trCol[findProductIndex];
                HtmlElement a = manager.FindClassName("J_download", tr);

                if (a != null)
                {
                    addProductCount++;

                    int y = manager.GetYoffset(a);
                    manager.ToY(y - 100);

                    manager.Browser.Task = "PublishProduct";
                    manager.ClickHelemnt(a);

                    checkDownTimer.Start();
                }
            }
            else
            {
                // 仅当前页
                if (checkBoxCurrentOnly.Checked)
                {
                    return;
                }

                // next Page
                manager.Browser.Task = "Publish";
                
                HtmlElement next = manager.FindClassName("page-next");
                if (next != null)
                {
                    manager.ClickHelemnt(next);
                }
                else
                {
                    if (publishAllVender)
                    {
                        Vender();
                    }
                }
            }
        }

        private bool Filter(FenXiaoModel model)
        {
            if (checkBoxInventory.Checked && model.Inventory != "有货")
            {
                addFenXiaoProductTimer.Start();
                return true;
            }
            if (!string.IsNullOrEmpty(model.F))
            {
                addFenXiaoProductTimer.Start();
                return true;
            }
            decimal priceFrom;
            if (decimal.TryParse(model.PriceFrom, out priceFrom))
            {
                decimal filterPrice = numericPriceFrom.Value;
                if (filterPrice < 0)
                {
                    filterPrice = 0;
                }

                // 价格过滤
                if (priceFrom <= filterPrice)
                {
                    addFenXiaoProductTimer.Start();
                    return true;
                }
            }

            if (numericSellCount.Value > 0)
            {
                // 成交笔数
                int count;
                if (int.TryParse(model.SellCount, out count))
                {
                    if (count < numericSellCount.Value)
                    {
                        addFenXiaoProductTimer.Start();
                        return true;
                    }
                }
            }

            DateTime sellDate = dateTimeUpdateDate.Value;
            if (sellDate > DateTime.Parse("2000-01-01"))
            {
                DateTime onSellDate;
                if (DateTime.TryParse(model.UpdateDate, out onSellDate))
                {
                    if (onSellDate < sellDate)
                    {
                        addFenXiaoProductTimer.Start();
                        return true;
                    }
                }
            }

            return false;
        }
        #endregion

        #region Stop
        private bool startPublishNewProduct = false;
        private void BtnStopFabu_Click(object sender, EventArgs e)
        {
            startPublishNewProduct = false;
        }
        #endregion

        #region 仅处理当前页面
        private void PublishCurrentPage()
        {
            Publish(this.manager.Browser);
        }
        #endregion
    }
}
