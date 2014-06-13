using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace tbDRP
{
    public class DockContext
    {
        public static DockContext Current;

        private DockPanel mainDockPanel;

        public DockContext(DockPanel mainDockPanel)
        {
            this.mainDockPanel = mainDockPanel;
        }

        public void Show(Form form)
        {
            ((DockContent)form).Show(this.mainDockPanel);
        }

        public void Show(Type type)
        {
            DockContent form;
            if (formContainer.ContainsKey(type))
            {
                form = formContainer[type];
            }
            else
            {
                form = (DockContent)Activator.CreateInstance(type);
                formContainer.Add(type, form);
            }

            ((DockContent)form).Show(this.mainDockPanel);
        }

        #region Forms
        private Dictionary<Type, DockContent> formContainer = new Dictionary<Type, DockContent>();
        private DistributionFrm distributionFrm;                // 分销

        #endregion
    }
}
