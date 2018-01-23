using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPM2.Framework.IoC.Windows.Forms;
using SPM2.Framework.IoC;
using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components.Menu.Edit
{
    [IoCBind(typeof(EditMenu), 1000)]
    public class RefreshMenuItem : IoCToolStripMenuItem
    {
        public RefreshMenuItem(IContainerAdapter container, ISPMLocalization local)
            : base(container)
        {
            Text = local.GetText("Interface_Refresh_Text");
            ToolTipText = local.GetText("Interface_Refresh_ToolTip");
            Image = global::Keutmann.SharePointManager.Properties.Resources.refresh3;
        }
    }
}
