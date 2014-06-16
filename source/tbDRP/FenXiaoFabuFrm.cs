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

namespace tbDRP
{
    public partial class FenXiaoFabuFrm : DockDocumentFrm
    {
        private const string URL = "http://gongxiao.tmall.com/distributor/user/my_supplier.htm";

        private WebBrowserManager manager;
        private List<VenderModel> list;

        public FenXiaoFabuFrm()
        {
            InitializeComponent();

            list = new List<VenderModel>();

            manager = new WebBrowserManager();
            manager.DocumentComplete += manager_DocumentComplete;
            
            WebBrowser browser = manager.Browser;
            browser.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(browser);
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
            venderIndex = this.comboBoxVender.SelectedIndex;
            if (venderIndex == 0)
            {
                publishAllVender = true;
            }
            else
            {
                publishAllVender = false;
                venderIndex--;
            }
            
            Publish();
        }

        private void Publish()
        {
            if (venderIndex < this.list.Count)
            {
                VenderModel model = this.list[venderIndex];

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
                LoadVenderList(browser);
            }
            else if (browser.Task == "Publish")
            {
                Publish(browser);
            }
            else if (browser.Task == "PublishProduct")
            {
                PublishProduct(browser);
            }
            else if (browser.Task == "ListProduct")
            {
                ListProduct(browser);
            }
        }

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
        }

        private void ListProduct(WebBrowserEx browser)
        {

        }

        private void PublishProduct(WebBrowserEx browser)
        {

        }

        private void Publish(WebBrowserEx browser)
        {
            string html = this.manager.DocumentHtml();


        }
    }
}
