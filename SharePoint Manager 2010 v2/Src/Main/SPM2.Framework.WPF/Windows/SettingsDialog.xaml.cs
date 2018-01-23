using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ComponentModel.Composition;
using SPM2.Framework.ComponentModel;
using System.Windows.Threading;
using System.Threading;
using SPM2.Framework.Configuration;
using SPM2.Framework.WPF.ViewModel.TreeView;

namespace SPM2.Framework.WPF.Windows
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    [Export("SettingsDialog")]
    public partial class SettingsDialog : System.Windows.Window
    {
        public SettingsDialog()
        {
            InitializeComponent();

            this.TreeView.SelectionChanged += new SelectionChangedEventHandler(TreeView_SelectionChanged);

            this.BtnOK.Click += new RoutedEventHandler(BtnOK_Click);
            this.BtnCancel.Click += new RoutedEventHandler(BtnCancel_Click);
            
        }

        void TreeView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SettingsModel selected = this.TreeView.SelectedItem as SettingsModel;

            if (this.GridControl.propertyGrid.SelectedObject != selected.SettingsObject)
            {
                Dispatcher.BeginInvoke(DispatcherPriority.Normal, new ThreadStart(() =>
                {
                    this.GridControl.propertyGrid.SelectedObject = selected.SettingsObject;
                }));
            }
        }

        void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Save()
        {
            SettingsProvider.Current.Save();
        }


        /// <summary>
        /// Constructor that takes a parent for this SettingsDialog dialog.
        /// </summary>
        /// <param name="parent">Parent window for this dialog.</param>
        public SettingsDialog(System.Windows.Window parent)
            : this()
        {
            this.Owner = parent;
        }
    }
}
