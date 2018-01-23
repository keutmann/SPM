using System;
using System.Drawing;
using System.ComponentModel;

using System.Windows.Forms;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager;

namespace Keutmann.SharePointManager.Components
{
    public class ContextMenuStripBase : ContextMenuStrip
    {

        public TreeViewExplorer Explorer
        {
            get
            {
                return Program.Window.Explorer;
            }
        }

        public ExplorerNodeBase CurrentNode
        {
            get
            {
                return Program.Window.Explorer.SelectedNode as ExplorerNodeBase;
            }
        }


        public ContextMenuStripBase()
        { }

        public ContextMenuStripBase(IContainer container)
            : base(container)
        {
        }


        public void Insert(int index, ToolStripItem value)
        {
            this.Items.Insert(index, value);
        }

        public ToolStripItem Insert(int index, string text, Image image, EventHandler onClick)
        {
            ToolStripItem item = new ToolStripMenuItem(text, image, onClick);
            this.Items.Insert(index, item);
            return item;
        }
    }
}
