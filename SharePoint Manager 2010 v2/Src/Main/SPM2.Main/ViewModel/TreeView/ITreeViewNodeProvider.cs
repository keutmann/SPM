using System.Collections.Generic;

namespace SPM2.Main.ViewModel.TreeView
{
    public interface ITreeViewNodeProvider
    {
        IEnumerable<IItemNode> LoadChildren(IItemNode parentNode);
        IItemNode LoadFarmNode();
    }
}
