using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPM2.Framework.IoC;
using SPM2.Framework.IoC.Windows.Forms;
using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components.Menu.File
{
    [IoCBind(typeof(FileMenu))]
    public class ExitMenuItem : IoCToolStripMenuItem
    {

        public ExitMenuItem(IContainerAdapter container, ISPMLocalization local)
            : base(container)
        {
            Text = local.GetText("Interface_Exit_Text");
            ToolTipText = local.GetText("Interface_Exit_ToolTip");
        }
    }
}
