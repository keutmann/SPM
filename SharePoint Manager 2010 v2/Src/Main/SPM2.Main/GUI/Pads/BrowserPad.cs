using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows.Controls;
using System.ComponentModel;

using AvalonDock;

using SPM2.Framework;
using SPM2.Framework.WPF;
using SPM2.Framework.WPF.Commands;
using SPM2.Framework.WPF.Components;
using SPM2.SharePoint;
using SPM2.SharePoint.Model;
using System.ComponentModel.Composition;
using System.Windows;

namespace SPM2.Main.GUI.Pads
{

    [Title("PropertyGrid")]
    [Export("SPM2.Main.MainWindow.ContentPane", typeof(DockableContent))]
    [ExportMetadata("ID", "SPM2.Main.GUI.Pads.BrowserPad")]
    [ExportMetadata("After", "SPM2.Main.GUI.Pads.PropertyGridPad")]
    public class BrowserPad : AbstractPadWindow
    {
        private const string NAME = "Browser";

        public BrowserControl BrowserContainer = new BrowserControl();

        private object SelectedObject { get; set; }
        private Uri LastSelectedUri { get; set; }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            this.Title = NAME;
            //this.Loaded += new System.Windows.RoutedEventHandler(BrowserPad_Loaded);
            //this.Unloaded += new System.Windows.RoutedEventHandler(BrowserPad_Unloaded);

            this.IsActiveDocumentChanged += new EventHandler(BrowserPad_IsActiveDocumentChanged);
            
            this.Content = this.BrowserContainer;

            Application.Current.MainWindow.CommandBindings.AddCommandExecutedHandler(SPM2Commands.ObjectSelected, ObjectSelected_Executed);
        }


        //private void BrowserPad_Loaded(object sender, System.Windows.RoutedEventArgs e)
        //{
        //}

        //void BrowserPad_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        //{
        //    Workbench.MainWindow.CommandBindings.RemoveCommandExecutedHandler(SPM2Commands.ObjectSelected, ObjectSelected_Executed);
        //}



        private void ObjectSelected_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.SelectedObject = e.Parameter;
            SetObject();
        }

        void BrowserPad_IsActiveDocumentChanged(object sender, EventArgs e)
        {
            SetObject();
        }


        protected override void OnClosed()
        {
            base.OnClosed();

            Application.Current.MainWindow.CommandBindings.RemoveCommandExecutedHandler(SPM2Commands.ObjectSelected, ObjectSelected_Executed);
        }

        private void SetObject()
        {
            if (this.IsWindowVisible)
            {
                ISPNode node = (ISPNode)this.SelectedObject;
                if (node != null)
                {
                    Uri nodeUrl = null;
                    if (!String.IsNullOrEmpty(node.Url))
                    {
                        nodeUrl = new Uri(node.Url);
                    }

                    if ((nodeUrl == null && this.LastSelectedUri != null) || nodeUrl != this.LastSelectedUri)
                    {
                        this.LastSelectedUri = nodeUrl;
                        this.BrowserContainer.Browser.Url = nodeUrl;
                    }

                }
            }
        }


    }
}
