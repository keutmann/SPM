using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPM2.Framework.IoC;
using SPM2.Framework.IoC.Windows.Forms;
using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components.Menu.View
{
    [IoCBind(typeof(MainMenuStrip), 300)]
    public class ViewMenu : IoCToolStripMenuItem
    {
        public ViewMenu(IContainerAdapter container, ISPMLocalization local)
            : base(container)
        {
            Text = local.GetText("Interface_View_Text");
            ToolTipText = local.GetText("Interface_View_ToolTip");
        }
    }
}
