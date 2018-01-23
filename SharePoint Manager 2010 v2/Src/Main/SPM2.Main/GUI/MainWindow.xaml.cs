using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.Generic;

using System.Reflection;
using System.Resources;
using System.Globalization;
using System.Collections;
using System.Windows.Media.Imaging;

using AvalonDock;

using SPM2.Framework.WPF;
using SPM2.Framework.Collections;
using SPM2.Framework;
using SPM2.Framework.Reflection;
using SPM2.Framework.WPF.Commands;
using SPM2.SharePoint.Model;
using System.ComponentModel.Composition;
using SPM2.Main.ViewModel;
using SPM2.SharePoint;
using GalaSoft.MvvmLight.Messaging;

namespace SPM2.Main
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [Export(AppModel.MAINWINDOW_CONTRACT_NAME, typeof(Window))]
    public partial class MainWindow : Window
    {
        public const string ToolBarTreyContainer_AddInID = "SPM2.Main.MainWindow.ToolBarTreyContainer";
        public const string MenuContainer_AddInID = "SPM2.Main.MainWindow.MenuContainer";
        public const string LeftDockPane_AddInID = "SPM2.Main.MainWindow.LeftDockPane";
        public const string ContentPane_AddInID = "SPM2.Main.MainWindow.ContentPane";
        public const string BottomDockPane_AddInID = "SPM2.Main.MainWindow.BottomDockPane";


        
        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnInitialized(System.EventArgs e)
        {
            base.OnInitialized(e);

            Uri iconUri = new Uri(SharePointContext.GetImagePath("admintitlegraphic.gif"), UriKind.Absolute);
            this.Icon = BitmapFrame.Create(iconUri);

            MainWindowModel model = (MainWindowModel)this.Resources["Model"];

            if (model.Menus != null)
            {
                //this.MenuContainer.Children.AddRange(model.Menus.Select(p => p.Value as Menu));

                foreach (var item in model.ToolBars)
                {
                    this.ToolBarTrayControl.ToolBars.Add(item.Value);
                }

                foreach (var item in model.LeftDockableContents)
                {
                    this.LeftDockPane.Items.Add(item.Value);
                }

                foreach (var item in model.CenterDockableContents)
                {
                    this.ContentPane.Items.Add(item.Value);
                }

                foreach (var item in model.BottomDockableContents)
                {
                    this.BottomDockPane.Items.Add(item.Value);
                }
            }

            CommandBinding();
        }



        private void CommandBinding()
        {
            
            ExecuteMessageEvent.Register(this, ApplicationCommands.Close, message => this.Close(), message => message.CanExecute(true));
            
            ExecuteMessageEvent.Register(this, SPM2Commands.ObjectSelected, message => SelectObject(message.Parameter.Parameter));

        }


        private void SelectObject(object obj)
        {
            FirstTextBlock.Text = string.Empty;
            if (obj != null && obj is ISPNode)
            {
                ISPNode node = (ISPNode)obj;
                string name = node.SPObjectType.Name;
                if (FirstTextBlock.Text != name)
                {
                    FirstTextBlock.Text = node.SPObjectType.Name;
                }
            }
        }

    }
}
