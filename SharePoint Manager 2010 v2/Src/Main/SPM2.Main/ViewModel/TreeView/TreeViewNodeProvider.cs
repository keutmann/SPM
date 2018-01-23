using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using SPM2.SharePoint;

namespace SPM2.Main.ViewModel.TreeView
{
    [Export()]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class TreeViewNodeProvider : ITreeViewNodeProvider
    {
        [Import()]
        public SPNodeProvider SPProvider { get; set; }

        public IItemNode LoadFarmNode()
        {
            var spFarmNode = SPProvider.LoadFarmNode();
            var node = ItemNode.Create(this, spFarmNode);
            node.IsExpanded = true;
            return node;
        }

        public IEnumerable<IItemNode> LoadChildren(IItemNode parentNode)
        {
            parentNode.SPNode.LoadChildren();
            return parentNode.SPNode.Children.Select(spNode => ItemNode.Create(this, spNode));
        }
    }
}
