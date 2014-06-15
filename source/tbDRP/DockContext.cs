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

        public DockContent Show(Type type, params object[] args)
        {
            DockContent form;
            if (formContainer.ContainsKey(type))
            {
                form = formContainer[type];
            }
            else
            {
                form = (DockContent)Activator.CreateInstance(type, args);
                formContainer.Add(type, form);
            }

            form.Show(this.mainDockPanel);
            return form;
        }

        #region Forms
        private Dictionary<Type, DockContent> formContainer = new Dictionary<Type, DockContent>();
        #endregion
    }
}
