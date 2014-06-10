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
    public partial class MainFrm : Form
    {
        public MainFrm()
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


    }
}
