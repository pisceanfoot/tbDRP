using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using tbDRP.Http;

namespace tbDRP
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            NetDataManager.UseSpicalEncoding("gb2312");

            

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainFrm());
        }
    }
}
