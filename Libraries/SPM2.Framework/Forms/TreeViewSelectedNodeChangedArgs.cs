using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPM2.Framework.Forms
{
    public delegate void TreeViewSelectedNodeChangedEventHandler(object sender, TreeViewSelectedNodeChangedArgs e);

    public class TreeViewSelectedNodeChangedArgs : EventArgs
    {
        public TreeViewAction Action { get; set; }
        public TreeNode BeforeNode { get; set; }
        public TreeNode AfterNode { get; set; }

        public TreeViewSelectedNodeChangedArgs(TreeNode beforeNode, TreeNode afterNode, TreeViewAction action)
        {
            BeforeNode = beforeNode;
            AfterNode = afterNode;
            Action = action;
        }
    }
}
