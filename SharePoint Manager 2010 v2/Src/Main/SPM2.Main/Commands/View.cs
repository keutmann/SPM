using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.ComponentModel;
using SPM2.Framework;
using SPM2.Framework.WPF;
using SPM2.Main.GUI;
using System.ComponentModel.Composition;

namespace SPM2.Main.Commands
{
    [Export(MainMenu.AddInID, typeof(MenuItem))]
    [ExportMetadata("After",  FileMenu.AddInID)]
    public class View : MenuItem
    {
        public const string AddInID = "SPM2.Main.Commands.View";


        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            this.Header = "View";
        }
    }
}
