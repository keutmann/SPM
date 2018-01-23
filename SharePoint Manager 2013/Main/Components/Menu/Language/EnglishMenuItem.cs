using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SPM2.Framework.Menu;
using SPM2.Framework.IoC;
using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components.Menu.Language
{
    [IoCBind(typeof(LanguageMenu))]
    public class EnglishMenuItem : ToolStripMenuItem, IMenuItem
    {
        public EnglishMenuItem(ISPMLocalization local)
        {
            Text = local.GetText("Interface_EnglishLanguage");
            ToolTipText = "";
            Checked = true;
        }

        protected override void OnCheckStateChanged(EventArgs e)
        {
            base.OnCheckStateChanged(e);


        }
    }
}
