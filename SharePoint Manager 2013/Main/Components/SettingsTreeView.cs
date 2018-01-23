using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPM2.Framework.Forms;
using SPM2.Framework.IoC;
using System.Windows.Forms;
using SPM2.Framework.Configuration;
using SPM2.Framework;
using SPM2.Framework.Extensions;

namespace Keutmann.SharePointManager.Components
{
    
    public class SettingsTreeView : TreeViewExtended
    {
        public IContainerAdapter IoCContainer { get; set; }

        public SettingsTreeView(IContainerAdapter container)
        {
            IoCContainer = container;
            ShowNodeToolTips = true;
            HideSelection = false;
            Dock = DockStyle.Fill;
        }


        public void LoadModel()
        {
            CreateChildNodes(typeof(ISettings), this.Nodes);
        }



        private void CreateChildNodes(Type parentType, TreeNodeCollection nodes)
        {
            var treeNodes = IoCContainer.ResolveBind<ISettings>(parentType);

            foreach (var item in treeNodes)
            {
                nodes.Add(CreateNode(item));
            }
        }

        private TreeNode CreateNode(ISettings settings)
        {
            var descriptor = new ClassDescriptor(settings.GetType());
            var node = new TreeNode();
            
            node.Text = descriptor.Title;
            node.Tag = settings;

            if (descriptor.Icon != null)
            {
                int index = this.AddImage(descriptor.Icon.Small);
                node.ImageIndex = index;
                node.SelectedImageIndex = index;
            }

            // Create 
            CreateChildNodes(settings.GetType(), node.Nodes);

            return node;
        }
    }
}
