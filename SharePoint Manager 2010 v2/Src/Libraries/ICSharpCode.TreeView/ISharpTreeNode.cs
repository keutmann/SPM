using System;
using System.Windows.Controls;
namespace ICSharpCode.TreeView
{
    public interface ISharpTreeNode
    {
        event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        System.Collections.Generic.IEnumerable<SharpTreeNode> Ancestors();
        System.Collections.Generic.IEnumerable<SharpTreeNode> AncestorsAndSelf();

        bool CanCopy(SharpTreeNode[] nodes);
        bool CanDelete(SharpTreeNode[] nodes);
        bool CanDrag(SharpTreeNode[] nodes);
        DropEffect CanDrop(System.Windows.IDataObject data, DropEffect requestedEffect);
        bool CanPaste(System.Windows.IDataObject data);
        SharpTreeNodeCollection Children { get; }
        event EventHandler Collapsing;
        System.Windows.IDataObject Copy(SharpTreeNode[] nodes);
        void Delete(SharpTreeNode[] nodes);
        void DeleteCore(SharpTreeNode[] nodes);
        System.Collections.Generic.IEnumerable<SharpTreeNode> Descendants();
        System.Collections.Generic.IEnumerable<SharpTreeNode> DescendantsAndSelf();
        void Drop(System.Windows.IDataObject data, int index, DropEffect finalEffect);
        void EnsureLazyChildren();
        System.Collections.Generic.IEnumerable<SharpTreeNode> ExpandedDescendants();
        System.Collections.Generic.IEnumerable<SharpTreeNode> ExpandedDescendantsAndSelf();
        string ExpandedIconUri { get; }
        string IconUri { get; set; }
        bool IsCheckable { get; }
        bool? IsChecked { get; set; }
        bool IsCut { get; }
        bool IsEditable { get; }
        bool IsEditing { get; set; }
        bool IsExpanded { get; set; }
        bool IsLast { get; }
        bool IsRoot { get; }
        bool LazyLoading { get; set; }
        int Level { get; }
        void LoadChildren();
        string LoadEditText();
        SharpTreeNode Parent { get; }
        //ContextMenu ContextMenu { get; set; }
        void Paste(System.Windows.IDataObject data);
        void RaisePropertyChanged(string name);
        bool SaveEditText(string value);
        bool ShowExpander { get; }
        bool ShowIcon { get; }
        object Text { get; set; }
        object ToolTip { get; set; }
    }
}
