using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using SPM2.Framework.Collections;
using System.Windows.Controls;
using System.ComponentModel.Composition;
using SPM2.Framework;
using AvalonDock;

namespace SPM2.Main.ViewModel
{
    public class MainWindowModel : ViewModelBase
    {

        private string _name = "Main window";
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [ImportMany(MainWindow.MenuContainer_AddInID, typeof(Menu))]
        public OrderingCollection<Menu> Menus { get; set; }

        [ImportMany(MainWindow.ToolBarTreyContainer_AddInID, typeof(ToolBar))]
        public OrderingCollection<ToolBar> ToolBars { get; set; }

        [ImportMany(MainWindow.LeftDockPane_AddInID, typeof(DockableContent))]
        public OrderingCollection<DockableContent> LeftDockableContents { get; set; }

        [ImportMany(MainWindow.ContentPane_AddInID, typeof(DockableContent))]
        public OrderingCollection<DockableContent> CenterDockableContents { get; set; }

        [ImportMany(MainWindow.BottomDockPane_AddInID, typeof(DockableContent))]
        public OrderingCollection<DockableContent> BottomDockableContents { get; set; }

        public MainWindowModel()
        {
            if (IsInDesignMode)
            {
                this.Name = "InDesign";
            }
            else
            {
                // Code runs "for real": Connect to service, etc...
                this.Name = "In Runtime : Test";
                CompositionProvider.Current.ComposeParts(this);
            }
        }

    }
}
