using ICSharpCode.TreeView;
using SPM2.Framework.WPF.ViewModel.TreeView;
using SPM2.SharePoint.Model;

namespace SPM2.Main.ViewModel.TreeView
{
    public interface IItemNode : ISharpTreeNode
    {
        string ToolTipText { get; set; }
        bool IsSelected { get; set; }
        bool IsHidden { get; set; }
        string TextColor { get; set; }
        ISPNode SPNode { get; set; }
        ITreeViewNodeProvider NodeProvider { get; set; }
    }
}
