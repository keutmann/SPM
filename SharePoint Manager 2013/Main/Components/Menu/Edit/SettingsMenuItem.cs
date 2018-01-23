using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPM2.Framework.IoC.Windows.Forms;
using SPM2.Framework.IoC;
using Keutmann.SharePointManager.Library;
using System.Windows.Forms;
using SPM2.Framework.Menu;
using Keutmann.SharePointManager.Forms;
using SPM2.Framework.Configuration;

namespace Keutmann.SharePointManager.Components.Menu.Edit
{
    [IoCBind(typeof(EditMenu), 30000)]
    public class SettingsMenuItem : ToolStripMenuItem, IMenuItem
    {
        public IContainerAdapter IoCContainer;

        public SettingsMenuItem(IContainerAdapter container, ISPMLocalization local)
        {
            IoCContainer = container;
            Text = local.GetText("Interface_Settings_Text");
            ToolTipText = local.GetText("Interface_Settings_ToolTip");
        }

        protected override void OnClick(EventArgs e)
        {
            var form = IoCContainer.Resolve<SettingsForm>();
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                // Save the stuff
                var provider = IoCContainer.Resolve<SettingsProvider>();
                provider.Save();
            }
            else
            {
                form.UndoChanges();
            }

        }
    }
}
