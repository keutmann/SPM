using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Keutmann.SharePointManager.Library;
using Keutmann.SharePointManager.ViewModel.TreeView;
using SPM2.SharePoint.Model;
using SPM2.Framework.IoC;

namespace Keutmann.SharePointManager.Components.Menu
{
    [IoCBind(typeof(SPContextMenu))]
    public class GenericDelete : ToolStripMenuItem, ISPMenuItem
    {
        public SPTreeNode TreeNode { get; set; }

        public GenericDelete()
        {
            Text = "Delete";
            //Size = new System.Drawing.Size(125, 22);
            Image = global::Keutmann.SharePointManager.Properties.Resources.delete;
        }

        public override bool CanSelect
        {
            get
            {
                
                var type = TreeNode.Model.SPObjectType;
                var method = type.GetMethod("Delete", new Type[] { });
                Enabled = (method != null);

                return Enabled;
            }
        }

        protected override void OnClick(EventArgs e)
        {
            if (!CanSelect) return;

            var result = MessageBox.Show(String.Format(SPMLocalization.GetString("Message_DeleteWarning"), TreeNode.Text), 
                                         SPMLocalization.GetString("Delete_Text"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                var parent = TreeNode.Parent as SPTreeNode;
                Program.Window.Explorer.SelectedNode = parent;
                SPMReflection.CallMethod(TreeNode.SPObject, "Delete", new object[] { });
                TreeNode.Remove();
            }
        }

    }
}
