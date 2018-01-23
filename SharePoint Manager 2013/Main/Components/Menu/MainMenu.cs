using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SPM2.Framework.IoC;
using SPM2.Framework.Menu;

namespace Keutmann.SharePointManager.Components.Menu
{
    public class MainMenuStrip : MenuStrip
    {
        public MainMenuStrip(IContainerAdapter container)
        {
            this.TabIndex = 0;

            var items = container.ResolveBind<IMenuItem>(this.GetType());

            this.Items.AddRange(items.Cast<ToolStripItem>().ToArray());
        }
    }

}

