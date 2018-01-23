using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPM2.Framework.IoC;
using SPM2.Framework.IoC.Windows.Forms;
using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components.Menu.File
{
    [IoCBind(typeof(FileMenu), Order = 2000)]
    public class SaveAllMenuItem : IoCToolStripMenuItem
    {
        public SaveAllMenuItem(IContainerAdapter container, ISPMLocalization local)
            : base(container)
        {
            Text = local.GetText("Interface_SaveAll_Text");
            ToolTipText = local.GetText("Interface_SaveAll_ToolTip");
            Image = global::Keutmann.SharePointManager.Properties.Resources.saveall;
        }
    }
}
