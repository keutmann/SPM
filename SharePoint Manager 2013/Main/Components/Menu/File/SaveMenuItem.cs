using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPM2.Framework.IoC;
using SPM2.Framework.IoC.Windows.Forms;
using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components.Menu.File
{
    [IoCBind(typeof(FileMenu), Order = 1000)]
    public class SaveMenuItem : IoCToolStripMenuItem
    {
        public SaveMenuItem(IContainerAdapter container, ISPMLocalization local)
            : base(container)
        {
            Image = global::Keutmann.SharePointManager.Properties.Resources.save;
            Text = local.GetText("Interface_Save_Text");
            ToolTipText = local.GetText("Interface_Save_ToolTip");
        }
    }
}
