using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using SPM2.Framework;
using System.Windows;
using SPM2.Framework.WPF.Components;
using System.ComponentModel.Composition;
using SPM2.Framework.Collections;

namespace SPM2.Main.Commands
{
    [Export(MainWindow.ToolBarTreyContainer_AddInID, typeof(ToolBar))]
    public class MainToolBar : ToolBar
    {
        public const string AddInID = "SPM2.Main.Commands.MainToolBar";

        [ImportMany(typeof(MainToolBar))]
        public OrderingCollection<UIElement> LacyItems { get; set; }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            foreach (var item in LacyItems)
            {
                this.Items.Add(item.Value);
            }
        }

    }
}
