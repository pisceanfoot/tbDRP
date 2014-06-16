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
            DockContent form = null;
            if (formContainer.ContainsKey(type))
            {
                form = formContainer[type];
            }
            if (form != null && form.IsDisposed)
            {
                formContainer.Remove(type);
                form = null;
            }

            if(form == null)
            {
                form = (DockContent)Activator.CreateInstance(type, args);
                formContainer.Add(type, form);
            }

            form.Show(this.mainDockPanel);
            return form;
        }

        public void Close(Type type)
        {
            if (formContainer.ContainsKey(type))
            {
                DockContent form = formContainer[type];
                formContainer.Remove(type);

                form.Close();
                form = null;
            }
        }

        public void Hide(Type type)
        {
            if (formContainer.ContainsKey(type))
            {
                DockContent form = formContainer[type];
                form.Hide();
            }
        }

        #region Forms
        private Dictionary<Type, DockContent> formContainer = new Dictionary<Type, DockContent>();
        #endregion
    }
}
