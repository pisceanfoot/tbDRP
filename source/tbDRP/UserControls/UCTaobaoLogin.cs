using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace tbDRP.UserControls
{
    public partial class UCTaobaoLogin : UserControl
    {
        private TaobaoLoginFrm taobaoLoginFrm = null;
         
        public UCTaobaoLogin()
        {
            InitializeComponent();
        }

        private void BtnTaobaoLogin_Click(object sender, EventArgs e)
        {
            if (taobaoLoginFrm == null || taobaoLoginFrm.IsDisposed)
            {
                taobaoLoginFrm = new TaobaoLoginFrm();
            }

            DockContext.Current.Show(taobaoLoginFrm);
        }

        protected override void OnBackgroundImageChanged(EventArgs e)
        {
            //base.OnBackgroundImageChanged(e);
        }
    }
}
