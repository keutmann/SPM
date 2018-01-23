using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using AvalonDock;
using ICSharpCode.TreeView;
using SPM2.Framework;
using SPM2.Framework.WPF;
using SPM2.Framework.WPF.Commands;
using SPM2.Main.ViewModel.TreeView;
using SPM2.SharePoint.Model;

namespace SPM2.Main.GUI.Pads
{
    [Title("SharePoint Explorer")]
    [Export("SPM2.Main.MainWindow.LeftDockPane", typeof (DockableContent))]
    [ExportMetadata("ID", "SPM2.Main.GUI.Pads.SPTreeViewPad")]
    public class SPTreeViewPad : AbstractPadWindow, IPartImportsSatisfiedNotification
    {
        private readonly SharpTreeView _wpfView = new SharpTreeView();


        public SPTreeViewPad()
        {
            Title = "SharePoint Explorer";
            _wpfView.ShowLines = false;

            Application.Current.MainWindow.ContentRendered += (s, e) => SelectItem();

            _wpfView.PreviewMouseDown += (s, e) => DoSelect = true;
            _wpfView.PreviewStylusDown += (s, e) => DoSelect = true;
            _wpfView.PreviewKeyDown += WpfViewPreviewKeyDown;
            _wpfView.SelectionChanged += WpfViewSelectionChanged;

            Content = _wpfView;
        }

        private bool DoSelect { get; set; }

        [Import]
        public TreeViewNodeProvider NodeProvider { get; set; }

        #region IPartImportsSatisfiedNotification Members

        public void OnImportsSatisfied()
        {
            var node = (SharpTreeNode) NodeProvider.LoadFarmNode();
            _wpfView.Root = node;

            //this.ModelProvider.ExpandToDefault();
        }

        #endregion

        private void WpfViewPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Return)
            {
                SelectItem();
            }
        }


        private void WpfViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DoSelect)
            {
                SelectItem();
                DoSelect = false;
            }
        }


        private void SelectItem()
        {
            object item = _wpfView.SelectedItem;
            if (item != null && item is IItemNode)
            {
                var treeNode = (IItemNode) item;
                if (treeNode.SPNode is MoreNode)
                {
                    // Excute the more 
                    var spNode = (MoreNode) treeNode.SPNode;

                    //spNode.ParentNode.LoadChildren();
                }
                else
                {
                    // Select the node in the Window
                    if (SPM2Commands.ObjectSelected.CanExecute(treeNode, this))
                    {
                        SPM2Commands.ObjectSelected.Execute(treeNode, this);
                    }
                }
            }
        }
    }
}