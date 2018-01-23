using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.ComponentModel;
using System.Windows.Controls;
using SPM2.Framework;
using SPM2.Framework.WPF;
using SPM2.Main.GUI;
using System.ComponentModel.Composition;
using SPM2.Framework.Collections;

namespace SPM2.Main.Commands
{
    [Export(MainMenu.AddInID, typeof(MenuItem))]
    [ExportMetadata("Order", 100)]
    public class FileMenu : MenuItem
    {
        public const string AddInID = "SPM2.Main.Commands.File";

        [ImportMany(typeof(FileMenu))]
        public OrderingCollection<MenuItem> LacyItems { get; set; }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            this.Header = "_File";

            foreach (var item in LacyItems)
            {
                this.Items.Add(item.Value);
            }
        }
    }
}
