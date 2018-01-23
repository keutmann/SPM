using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

using SPM2.Framework;
using SPM2.Framework.WPF;
using SPM2.Main.GUI;
using System.ComponentModel.Composition;
using SPM2.SharePoint;
using SPM2.Framework.WPF.Windows;

namespace SPM2.Main.Commands
{
    //[Icon("icasax.png")]
    [Export(typeof(FileMenu))]
    [ExportMetadata("ID", AddInID)]
    public class Settings : MenuItem
    {

        public const string AddInID = "SPM2.Main.Commands.Settings";

        public Settings()
        {
            this.Header = "Settings";
            this.Icon = ImageExtensions.LoadImage(SharePointContext.GetImagePath("icasax.png"));
            this.Click += new RoutedEventHandler(ClickHandler);
        }

        void ClickHandler(object sender, RoutedEventArgs e)
        {
            SettingsDialog dialog = new SettingsDialog(Application.Current.MainWindow);
            dialog.ShowDialog();
        }
    }
}
