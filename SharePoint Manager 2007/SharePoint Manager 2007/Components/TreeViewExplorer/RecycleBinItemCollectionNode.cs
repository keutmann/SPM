using System;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;


namespace Keutmann.SharePointManager.Components
{
    public class RecycleBinItemCollectionNode : ExplorerNodeBase
    {
        private ToolStripItem _menuItemRestore = null;

        public SPRecycleBinItemCollection RecycleBinItemCollection
        {
            get
            {
                return this.Tag as SPRecycleBinItemCollection;
            }
        }

        public override ContextMenuStrip ContextMenuStrip
        {
            get
            {
                if (base.ContextMenuStrip == MenuStripBase)
                {
                    // Use refresh menu af base menu to build on
                    MenuStripRefresh menu = new MenuStripRefresh();

                    // Create the restore menu item and save object in the member _restore (use in Opening event)
                    _menuItemRestore = menu.Insert(0, SPMLocalization.GetString("RestoreAll"), null, new EventHandler(RestoreAllMenuItem_Click));

                    // Create a separator in the menu
                    menu.Insert(1, new ToolStripSeparator());

                    // Add the opening event to enable/disenable menu items, if there is any childnodes
                    menu.Opening += new System.ComponentModel.CancelEventHandler(menu_Opening);

                    base.ContextMenuStrip = menu;
                }
                return base.ContextMenuStrip;
            }
            set
            {
                base.ContextMenuStrip = value;
            }
        }


        public RecycleBinItemCollectionNode(object parent, SPRecycleBinItemCollection collection)
        {
            this.Tag = collection;
            this.SPParent = parent;

            this.Text = SPMLocalization.GetString("RecycleBin_Text");
            this.ToolTipText = SPMLocalization.GetString("RecycleBin_ToolTip");
            this.Name = "RecycleBin";
            this.SPParent = parent;

            int index = Program.Window.Explorer.AddImage(this.ImageUrl());
            this.ImageIndex = index;
            this.SelectedImageIndex = index;

            this.Nodes.Add("Dummy");
        }

        public override void LoadNodes()
        {
            base.LoadNodes();

            bool showFirstStage = this.SPParent is SPWeb;

            foreach (SPRecycleBinItem item in RecycleBinItemCollection)
            {
                if (showFirstStage && item.ItemState == SPRecycleBinItemState.FirstStageRecycleBin)
                {
                    this.Nodes.Add(new RecycleBinNode(item));
                }
                else if(!showFirstStage && item.ItemState == SPRecycleBinItemState.SecondStageRecycleBin)
                {
                    this.Nodes.Add(new RecycleBinNode(item));
                }
            }
        }

        public override string ImageUrl()
        {
            return SPMPaths.ImageDirectory + "RECYCBIN.GIF";
        }

        void RestoreAllMenuItem_Click(object sender, EventArgs e)
        {
            foreach (TreeNode node in this.Nodes)
            {
                if (node is RecycleBinNode)
                {
                    ((RecycleBinNode)node).Restore();
                }
            }
        }

        /// <summary>
        /// Enable or disable menu items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void menu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _menuItemRestore.Enabled = this.Nodes.Count > 0;
        }
    }
}
