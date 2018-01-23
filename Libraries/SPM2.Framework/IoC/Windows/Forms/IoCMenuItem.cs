using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SPM2.Framework.Commands;
using SPM2.Framework.IoC;
using SPM2.Framework.Menu;

namespace SPM2.Framework.IoC.Windows.Forms
{
    public abstract class IoCToolStripMenuItem : ToolStripMenuItem, IMenuItem
    {
        public CommandManager Manager { get; set; }
        private MenuItemViewModel Model;

        public override bool Enabled
        {
            get
            {
                if (Model.Commands.Count() == 0)
                    return base.Enabled;

                foreach (var item in Model.Commands)
                {
                    if (item.CanExecute())
                        return true;
                }

                return false;
            }
            set
            {
                base.Enabled = value;
            }
        }

        public IoCToolStripMenuItem(IContainerAdapter container)
        {
            Enabled = true;
            Manager = container.Resolve<CommandManager>();
            LoadModel(container);
        }

        public void LoadModel(IContainerAdapter container)
        {
            Model = new MenuItemViewModel(container, this.GetType());
            if (Model.Items != null && Model.Items.Count() > 0)
                this.DropDownItems.AddRange(Model.Items.Cast<ToolStripItem>().ToArray());
        }

        protected override void OnClick(EventArgs e)
        {
            if (Model.Commands == null)
                return;

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                foreach (var item in Model.Commands)
                {
                    Manager.Push(item);
                    item.Execute();
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

    }
}
