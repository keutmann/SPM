using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPM2.Framework.Forms
{
    public interface IShadowNode 
    {
    }

    public class TreeViewExtended : TreeView
    {
        private TreeViewSelectedNodeChangedArgs _selectedNodeChanged;


        public event TreeViewSelectedNodeChangedEventHandler SelectedNodeChanged;




        protected override void OnNodeMouseClick(TreeNodeMouseClickEventArgs e)
        {
            base.OnNodeMouseClick(e);
            if (!(e.Node is IShadowNode))
            {
                SelectedNode = e.Node;
            }
        }

        protected override void OnBeforeSelect(TreeViewCancelEventArgs e)
        {
           base.OnBeforeSelect(e);
            if (!e.Cancel)
            {
                _selectedNodeChanged = new TreeViewSelectedNodeChangedArgs(SelectedNode, e.Node, e.Action);
            }
        }

        protected override void OnAfterSelect(TreeViewEventArgs e)
        {
            base.OnAfterSelect(e);
            
            OnSelectedNodeChanged(_selectedNodeChanged);
            _selectedNodeChanged = null;
        }

        protected virtual void OnSelectedNodeChanged(TreeViewSelectedNodeChangedArgs e)
        {
            if (SelectedNodeChanged != null)
            {
                SelectedNodeChanged(this, e);
            }
        }

        public void DoClick(TreeNode node)
        {
            SelectedNode = node;
            var args = new EventArgs();
            base.OnClick(args);
        }
    }
}
