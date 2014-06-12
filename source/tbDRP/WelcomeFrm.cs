using System;
using tbDRP.Dock;

namespace tbDRP
{
    public partial class WelcomeFrm : DockDocumentFrm
    {
        public WelcomeFrm()
        {
            InitializeComponent();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            string tag = this.BtnStart.Tag as string;
            if (tag == "run")
            {
                this.BtnStart.Text = "停止";
                this.BtnStart.Tag = "stop";
            }
            else
            {
                this.BtnStart.Text = "启动";
                this.BtnStart.Tag = "run";
            }
        }

        private void BtnTitle_Click(object sender, EventArgs e)
        {
            this.Hide();
            TongKuanFrm form = new TongKuanFrm();
            form.ShowDialog();
            this.Show();
        }

        private void BtnTaobaoLogin_Click(object sender, EventArgs e)
        {
            TaobaoLoginFrm form = new TaobaoLoginFrm();
            form.ShowDialog();
        }
    }
}