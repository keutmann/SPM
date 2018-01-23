using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Keutmann.SharePointManager.ViewModel.TreeView;
using SPM2.SharePoint.Model;
using SPM2.Framework.IoC;

namespace Keutmann.SharePointManager.Components.Menu
{
    [IoCBind(typeof(SPContextMenu), 30000)]
    public class GenericRefesh : ToolStripMenuItem, ISPMenuItem
    {
        public SPTreeNode TreeNode { get; set; }

        public GenericRefesh()
        {
            Text = "Refesh";
            Size = new System.Drawing.Size(125, 22);
            Image = global::Keutmann.SharePointManager.Properties.Resources.refresh3;
        }

        protected override void OnClick(EventArgs e)
        {
            TreeNode.Refresh();
        }
    }
}
