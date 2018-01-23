using System;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;


namespace Keutmann.SharePointManager.Components
{
    public class RecycleBinNode : ExplorerNodeBase
    {
        public SPRecycleBinItem RecycleBinItem
        {
            get
            {
                return this.Tag as SPRecycleBinItem;
            }
        }
        

        public override ContextMenuStrip ContextMenuStrip
        {
            get
            {
                if (base.ContextMenuStrip == MenuStripBase)
                {
                    MenuStripRefresh menu = new MenuStripRefresh();
                    
                    menu.Insert(0, "Restore", null, new EventHandler(RestoreMenuItem_Click));
                    menu.Insert(1, new ToolStripSeparator());
                    
                    base.ContextMenuStrip = menu;
                }
                return base.ContextMenuStrip;
            }
            set
            {
                base.ContextMenuStrip = value;
            }
        }

        public RecycleBinNode(SPRecycleBinItem item)
        {
            this.Tag = item;
            this.SPParent = item.Web;

            Setup();

            int index = Program.Window.Explorer.AddImage(this.ImageUrl());
            this.ImageIndex = index;
            this.SelectedImageIndex = index;
        }

        public override void Setup()
        {
            this.Text = RecycleBinItem.Title;
            this.ToolTipText = RecycleBinItem.LeafName;
            this.Name = RecycleBinItem.ID.ToString();
        }

        public override string ImageUrl()
        {
            string path = this.RecycleBinItem.ImageUrl;
            path = path.Substring(path.LastIndexOf("/") + 1);
            path = SPMPaths.ImageDirectory + path;
            return path;
        }

        public void Restore()
        {
            RecycleBinItem.Restore();
            this.Remove();
        }

        private void RestoreMenuItem_Click(object sender, EventArgs e)
        {
            Restore();
        }
    }
}
