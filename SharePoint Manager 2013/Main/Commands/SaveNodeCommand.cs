using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPM2.Framework.IoC;
using SPM2.Framework.Commands;
using Keutmann.SharePointManager.Components;
using Keutmann.SharePointManager.Collections;
using Keutmann.SharePointManager.Components.Menu.File;

namespace Keutmann.SharePointManager.Commands
{
    [IoCBind(typeof(SaveMenuItem))]
    public class SaveNodeCommand : ICommand
    {

        public TreeViewComponent TreeView { get; set; }
        public IChangedNodes ChangedNodes { get; set; }

        public ExplorerNodeBase SelectedNode
        {
            get
            {
                return TreeView.SelectedNode as ExplorerNodeBase;
            }
        }

        public SaveNodeCommand(TreeViewComponent treeview, IChangedNodes changedNodes)
        {
            TreeView = treeview;
            ChangedNodes = changedNodes;    
        }

        public void Execute()
        {
            if (!Properties.Settings.Default.ReadOnly)
            {
                if (SelectedNode == null)
                    return;

                //this.toolStripStatusLabel.Text = SPMLocalization.GetString("Saving_Changes");

                if (ChangedNodes.ContainsKey(SelectedNode))
                {
                    SelectedNode.Update();
                    SelectedNode.Setup();
                    ChangedNodes.Remove(SelectedNode);
                }

                //this.toolStripStatusLabel.Text = SPMLocalization.GetString("Changes_Saved");
            }
        }

        public bool CanExecute()
        {
            if (SelectedNode == null)
                return false;

            return ChangedNodes.ContainsKey(SelectedNode);
        }
    }
}


