using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace tbDRP.Dock
{
    public class BaseIMEConversionFrm : Form
    {
        // Fields
        private const int IME_CHOTKEY_SHAPE_TOGGLE = 0x11;
        private const int IME_CMODE_FULLSHAPE = 8;

        // Methods
        [DllImport("imm32.dll")]
        public static extern IntPtr ImmGetContext(IntPtr hwnd);
        [DllImport("imm32.dll")]
        public static extern bool ImmGetConversionStatus(IntPtr himc, ref int lpdw, ref int lpdw2);
        [DllImport("imm32.dll")]
        public static extern bool ImmGetOpenStatus(IntPtr himc);
        [DllImport("imm32.dll")]
        public static extern bool ImmSetOpenStatus(IntPtr himc, bool b);
        [DllImport("imm32.dll")]
        public static extern int ImmSimulateHotKey(IntPtr hwnd, int lngHotkey);

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            IntPtr himc = ImmGetContext(base.Handle);
            if (ImmGetOpenStatus(himc))
            {
                int lpdw = 0;
                int num2 = 0;
                if (ImmGetConversionStatus(himc, ref lpdw, ref num2) && ((lpdw & 8) > 0))
                {
                    ImmSimulateHotKey(base.Handle, 0x11);
                }
            }
        }
    }
}
