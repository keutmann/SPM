using System;
using System.Windows.Threading;
using System.Xml;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.ComponentModel;
using System.Windows.Input;

using AvalonDock;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Folding;
using ICSharpCode.AvalonEdit.Highlighting;

using SPM2.Framework;
using SPM2.Framework.WPF;
using SPM2.Framework.WPF.Components;
using SPM2.Framework.WPF.Commands;
using SPM2.Framework.ComponentModel;

using SPM2.SharePoint;
using SPM2.SharePoint.Model;
using System.ComponentModel.Composition;
using System.Windows;
using SPM2.Framework.Xml;

namespace SPM2.Main.GUI.Pads
{

    [Title("Text editor")]
    [Export(MainWindow.ContentPane_AddInID, typeof(DockableContent))]
    [ExportMetadata("ID", "SPM2.Main.GUI.Pads.EditorPad")]
    [ExportMetadata("After", "SPM2.Main.GUI.Pads.BrowserPad")]
    public class EditorPad : AbstractPadWindow
    {
        private const string NAME = "Editor";

        public TextEditor Editor = new TextEditor();
        private FoldingManager foldingManager;
        private AbstractFoldingStrategy foldingStrategy;

        private object SelectedObject { get; set; }

        private PropertyGridEditValue GridValue { get; set; }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            this.Title = NAME;

            //this.Loaded += new System.Windows.RoutedEventHandler(EditorPad_Loaded);

            DispatcherTimer foldingUpdateTimer = new DispatcherTimer();
            foldingUpdateTimer.Interval = TimeSpan.FromSeconds(2);
            foldingUpdateTimer.Tick += foldingUpdateTimer_Tick;
            foldingUpdateTimer.Start();

            this.Content = this.Editor;

            Application.Current.MainWindow.CommandBindings.AddCommandExecutedHandler(SPM2Commands.EditString, EditString_Executed);
            Application.Current.MainWindow.CommandBindings.AddCommandExecutedHandler(SPM2Commands.ObjectSelected, ObjectSelected_Executed);
            //Workbench.MainWindow.CommandBindings.AddCommandCanExecuteHandler(ApplicationCommands.Save, Save_CanExecute);

        }

        //void EditorPad_Loaded(object sender, System.Windows.RoutedEventArgs e)
        //{
        //}

        private void EditString_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.GridValue = (PropertyGridEditValue)e.Parameter;
            
            SetObject();
            this.Show();
        }

        void ObjectSelected_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.SelectedObject = e.Parameter;
        }


        void Save_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            this.GridValue.Value = this.Editor.Text;
            e.Handled = false;
        }



        protected override void OnClosed()
        {
            base.OnClosed();

            Application.Current.MainWindow.CommandBindings.RemoveCommandExecutedHandler(SPM2Commands.ObjectSelected, EditString_Executed);
            Application.Current.MainWindow.CommandBindings.RemoveCommandExecutedHandler(SPM2Commands.EditString, EditString_Executed);
        }

        void foldingUpdateTimer_Tick(object sender, EventArgs e)
        {
            if (foldingStrategy != null)
            {
                foldingStrategy.UpdateFoldings(foldingManager, Editor.Document);
            }
        }

        

        private void SetObject()
        {
            if(this.GridValue != null)
            {
                string text = (string)this.GridValue.Value;


                if (text != null && text.Trim().StartsWith("<"))
                {

                    this.Editor.Text = Serializer.FormatXml(text);
                   
                    
                    this.Editor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinition("XML");
                    this.Editor.TextArea.IndentationStrategy = new ICSharpCode.AvalonEdit.Indentation.DefaultIndentationStrategy();
                    this.foldingStrategy = new XmlFoldingStrategy();
                }
                else
                {
                    this.Editor.Text = text;
                    this.Editor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinition("TXT");
                    this.Editor.TextArea.IndentationStrategy = new ICSharpCode.AvalonEdit.Indentation.DefaultIndentationStrategy();
                    foldingStrategy = null;
                }
             
                if (foldingStrategy != null)
                {
                    if (foldingManager == null)
                    {
                        foldingManager = FoldingManager.Install(this.Editor.TextArea);
                    }
                    foldingStrategy.UpdateFoldings(foldingManager, this.Editor.Document);
                }
                else
                {
                    if (foldingManager != null)
                    {
                        FoldingManager.Uninstall(foldingManager);
                        foldingManager = null;
                    }
                }

            }

        }


    }
}
