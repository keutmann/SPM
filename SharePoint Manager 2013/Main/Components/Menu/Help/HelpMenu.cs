using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPM2.Framework.IoC;
using SPM2.Framework.IoC.Windows.Forms;
using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components.Menu.Help
{
    [IoCBind(typeof(MainMenuStrip), 500)]
    public class HelpMenu : IoCToolStripMenuItem
    {
        public HelpMenu(IContainerAdapter container, ISPMLocalization local)
            : base(container)
        {
            Text = local.GetText("Interface_Help_Text");
            ToolTipText = local.GetText("Interface_Help_ToolTip");
        }
    }

}
