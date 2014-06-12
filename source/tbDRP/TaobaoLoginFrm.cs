using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace tbDRP
{
    public partial class TaobaoLoginFrm : Form
    {
        private WebBrowser webBrowser;
        private WebBrowserManager manager;

        public TaobaoLoginFrm()
        {
            InitializeComponent();

            Init();
        }

        private void Init()
        {
            manager = new WebBrowserManager();
            this.webBrowser = manager.Browser;
            this.webBrowser.Dock = DockStyle.Fill;

            this.Controls.Add(this.webBrowser);

            // 登录成功后跳转到分销页面
            this.webBrowser.Navigate("https://login.taobao.com/member/login.jhtml?redirectURL=http%3a%2f%2fgongxiao.tmall.com%2fdistributor%2findex.htm");
        }
    }
}
