using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPM2.Framework.IoC;
using SPM2.Framework.IoC.Windows.Forms;
using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components.Menu.Edit
{
    [IoCBind(typeof(MainMenuStrip), 200)]
    public class EditMenu : IoCToolStripMenuItem
    {
        public EditMenu(IContainerAdapter container, ISPMLocalization local)
            : base(container)
        {
            Text = local.GetText("Interface_Edit_Text");
            ToolTipText = local.GetText("Interface_Edit_ToolTip");
        }
    }
}
