using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using SPM2.Framework;
using SPM2.Framework.WPF;
using System.ComponentModel.Composition;
using SPM2.Framework.Collections;

namespace SPM2.Main.GUI
{
    [Export(MainWindow.MenuContainer_AddInID, typeof(Menu))]
    public class MainMenu : Menu
    {
        public const string AddInID = "SPM2.Main.GUI.MainMenu";

        [ImportMany(AddInID, typeof(MenuItem))]
        public OrderingCollection<MenuItem> LacyItems { get; set; }

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
