using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.ComponentModel;

using System.Windows.Forms;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager;
using Keutmann.SharePointManager.ViewModel.TreeView;
using SPM2.Framework.Collections;
using SPM2.Framework;
using Keutmann.SharePointManager.Components.Menu;
using SPM2.Framework.IoC;

namespace Keutmann.SharePointManager.Components
{
    public class SPContextMenu : ContextMenuStrip, ISPMenuItem
    {

        //public TreeViewComponent Explorer
        //{
        //    get
        //    {
        //        return Program.Window.Explorer;
        //    }
        //}

        //public ExplorerNodeBase CurrentNode
        //{
        //    get
        //    {
        //        return Program.Window.Explorer.SelectedNode as ExplorerNodeBase;
        //    }
        //}

        public IContainerAdapter IoCContainer { get; set; }

        public SPTreeNode TreeNode { get; set; }

        public SPContextMenu(IContainerAdapter container)
        {
            IoCContainer = container;
        }

        public void Initialize(SPTreeNode treeNode)
        {
            TreeNode = treeNode;

            this.Items.AddRange(EnsureTreeNode(IoCContainer.Resolve<IEnumerable<ISPMenuItem>>(TreeNode.Model.GetType().AssemblyQualifiedName), TreeNode));
            if (this.Items.Count > 0)
            {
                this.Items.Add(new ToolStripSeparator());
            }
            this.Items.AddRange(EnsureTreeNode(IoCContainer.Resolve<IEnumerable<ISPMenuItem>>(this.GetType().AssemblyQualifiedName), TreeNode));
        }


        private ToolStripItem[] EnsureTreeNode(IEnumerable<ISPMenuItem> collection, SPTreeNode treeNode)
        {
            var list = new List<ToolStripItem>();

            foreach (var menuItem in collection)
            {
                if (menuItem != null)
                {
                    menuItem.TreeNode = treeNode;
                }
                list.Add((ToolStripItem)menuItem);
            }
            return list.ToArray();
        }


        public SPContextMenu(IContainer container)
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
