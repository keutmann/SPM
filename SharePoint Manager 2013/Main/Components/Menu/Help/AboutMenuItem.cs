using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPM2.Framework.Menu;
using SPM2.Framework.IoC;
using SPM2.Framework.IoC.Windows.Forms;
using Keutmann.SharePointManager.Library;
using Keutmann.SharePointManager.Forms;
using System.Windows.Forms;

namespace Keutmann.SharePointManager.Components.Menu.Help
{
    [IoCBind(typeof(HelpMenu))]
    public class AboutMenuItem : ToolStripMenuItem, IMenuItem
    {
        public IContainerAdapter IoCContainer;

        public AboutMenuItem(IContainerAdapter container, ISPMLocalization local)
        {
            IoCContainer = container;
            Text = local.GetText("Interface_About_Text");
            ToolTipText = local.GetText("Interface_About_ToolTip");
            Image = global::Keutmann.SharePointManager.Properties.Resources.about;
        }

        protected override void OnClick(EventArgs e)
        {
            var aboutForm = IoCContainer.Resolve<AboutForm>();

            aboutForm.ShowDialog();
        }
    }
}
