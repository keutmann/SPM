using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Keutmann.SharePointManager.ViewModel.TreeView;
using SPM2.SharePoint.Model;
using SPM2.Framework.IoC;
using SPM2.Framework;

namespace Keutmann.SharePointManager.Components.Menu
{
    [IoCBind(typeof(SPFeatureNode), 100)]
    public class SPFeatureActivate : ToolStripMenuItem, ISPMenuItem, IFilter 
    {
        public SPTreeNode TreeNode { get; set; }

        public bool Included { get; set; }

        public override bool CanSelect
        {
            get
            {
                if(TreeNode.Model is SPFeatureNode)
                {
                    Enabled = !((SPFeatureNode)TreeNode.Model).Activated;
                    return Enabled;
                }
                return false;
            }
        }


        protected override void OnClick(EventArgs e)
        {
            var feature = (SPFeatureNode)TreeNode.Model;
            feature.ActivateFeature();
            feature.UpdateIconUri();
            TreeNode.ImageIndex = Program.Window.Explorer.AddImage(feature.IconUri);
            TreeNode.SelectedImageIndex = TreeNode.ImageIndex;
        }


        public SPFeatureActivate(TreeViewComponent treeView)
        {
            Text = "Activate";

            var node = treeView.SelectedNode as SPTreeNode;
            if (node != null)
            {
                Included = node.Model is SPFeatureNode;
            }
        }

    }
}
