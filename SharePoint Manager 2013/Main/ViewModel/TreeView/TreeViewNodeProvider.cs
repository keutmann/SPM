using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SPM2.Framework.Collections;
using SPM2.SharePoint;
using SPM2.SharePoint.Model;
using SPM2.Framework.IoC;

namespace Keutmann.SharePointManager.ViewModel.TreeView
{
    //[Export()]
    //[PartCreationPolicy(CreationPolicy.Shared)]
    public class TreeViewNodeProvider : ITreeViewNodeProvider
    {
        public IContainerAdapter IoCContainer { get; set; }        

        public ISPNodeProvider SPProvider { get; set; }

        public TreeViewNodeProvider(ISPNodeProvider provider, IContainerAdapter container)
        {
            IoCContainer = container;
            SPProvider = provider;
        }

        public SPTreeNode LoadFarmNode()
        {
            var spFarmNode = SPProvider.LoadFarmNode();
            var node = SPTreeNode.Create(this, spFarmNode);
            node.Setup();
            //node.IsExpanded = true;
            return node;
        }

        public SPTreeNode Load(ISPNode spNode)
        {
            var root = SPTreeNode.Create(this, spNode);
            LoadTreeNodes(root);

            return root;
        }

        private void LoadTreeNodes(SPTreeNode parent)
        {
            if (parent.Model.Children.Count == 0) return;

            parent.Nodes.AddRange(parent.Model.Children.Select(spNode => SPTreeNode.Create(this, spNode)).ToArray());

            foreach (SPTreeNode item in parent.Nodes)
            {
                LoadTreeNodes(item);
            }
        }

        public IEnumerable<SPTreeNode> LoadChildren(SPTreeNode parentNode)
        {
            var model = parentNode.Model;

            var index = model.Children.Count;

            model.LoadChildren();

            // Load new nodes
            var list = new List<SPTreeNode>();
            for (var count = index; count < parentNode.Model.Children.Count; count++)
            {
                var spNode = parentNode.Model.Children[count];

                var treeNode = SPTreeNode.Create(this, spNode);
                parentNode.Nodes.Insert(count, treeNode);
                list.Add(treeNode);
            }


            var modelCollection = model as ISPNodeCollection;
            if (modelCollection == null) return list;

            // Add more node
            if (modelCollection.LoadingChildren)
            {
                var moreNode = new MoreNode(modelCollection);
                moreNode.NodeProvider = modelCollection.NodeProvider;
                var spNode = SPMoreNode.Create(this, moreNode);
                list.Add(spNode);
                parentNode.Nodes.Add(spNode);
            }

            return list;
        }

        private bool IsThereMoreNodes(List<ISPNode> nodes)
        {
            return nodes.Count > 0 && nodes[nodes.Count - 1] is MoreNode;
        }
    }
}
