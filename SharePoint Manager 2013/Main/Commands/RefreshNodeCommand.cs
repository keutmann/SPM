using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPM2.Framework.IoC;
using Keutmann.SharePointManager.Components.Menu;
using SPM2.Framework.Commands;
using Keutmann.SharePointManager.Components;
using Keutmann.SharePointManager.Collections;
using Keutmann.SharePointManager.Library;
using Keutmann.SharePointManager.Components.Menu.Edit;

namespace Keutmann.SharePointManager.Commands
{
    [IoCBind(typeof(RefreshMenuItem))]
    public class RefreshNodeCommand : ICommand
    {
        public TreeViewComponent TreeView { get; set; }

        public ExplorerNodeBase SelectedNode
        {
            get
            {
                return TreeView.SelectedNode as ExplorerNodeBase;
            }
        }
        public RefreshNodeCommand(TreeViewComponent treeview)
        {
            TreeView = treeview;
        }

        public void Execute()
        {
            if (SelectedNode != null)
            {
                SelectedNode.Refresh();
            }
        }

        public bool CanExecute()
        {
            return SelectedNode != null;
        }
    }
}


