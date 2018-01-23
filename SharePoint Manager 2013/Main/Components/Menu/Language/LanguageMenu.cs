using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPM2.Framework.IoC;
using SPM2.Framework.IoC.Windows.Forms;
using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components.Menu.Language
{
    //[IoCBind(typeof(MainMenuStrip), 400)]
    public class LanguageMenu : IoCToolStripMenuItem
    {
        public LanguageMenu(IContainerAdapter container, ISPMLocalization local)
            : base(container)
        {
            Text = local.GetText("Interface_Languages_Text");
            ToolTipText = local.GetText("Interface_Languages_ToolTip");
        }
    }
}
