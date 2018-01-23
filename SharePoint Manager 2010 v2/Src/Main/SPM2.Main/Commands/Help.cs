using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.ComponentModel;
using SPM2.Main.GUI;
using SPM2.Framework;
using SPM2.Framework.WPF;
using System.Windows.Controls;
using System.ComponentModel.Composition;
using SPM2.Framework.Collections;

namespace SPM2.Main.Commands
{
    [Export(MainMenu.AddInID, typeof(MenuItem))]
    [ExportMetadata("Order", int.MaxValue-100)]
    public class Help : MenuItem
    {
        public const string AddInID = "SPM2.Main.Commands.Help";

        [ImportMany(AddInID, typeof(MenuItem))]
        public OrderingCollection<MenuItem> LacyItems { get; set; }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            this.Header = "_Help";

            foreach (var item in LacyItems)
            {
                this.Items.Add(item.Value);
            }
        }
    }
}
