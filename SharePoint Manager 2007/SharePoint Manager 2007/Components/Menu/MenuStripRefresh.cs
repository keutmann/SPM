using System;
using System.Windows.Forms;
using System.ComponentModel;


namespace Keutmann.SharePointManager.Components
{
    public class MenuStripRefresh : ContextMenuStripBase
    {
        public ToolStripItem RefreshItem;


        public MenuStripRefresh()
        {
            Init();
        }

        public MenuStripRefresh(IContainer container)
        {
            container.Add(this);

            Init();
        }

        private void Init()
        {
            RefreshItem = SPMMenu.Items.CreateRefresh();

            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                RefreshItem
            });
        }
    }
}
