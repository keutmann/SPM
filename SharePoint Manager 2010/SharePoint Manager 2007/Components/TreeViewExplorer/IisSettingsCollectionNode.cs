using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint.Administration;
using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    class IisSettingsCollectionNode : ExplorerNodeBase
    {

        public Dictionary<SPUrlZone, SPIisSettings> IisSettings
        {
            get
            {
                return this.Tag as Dictionary<SPUrlZone, SPIisSettings>;
            }
        }
        public SPWebApplication WebApplication
        { get; set; }

        public IisSettingsCollectionNode(SPWebApplication app)
        {
            this.Text = SPMLocalization.GetString("IisSettings_Text");
            this.ToolTipText = SPMLocalization.GetString("IisSettings_ToolTip");
            this.Name = "Iis settings";
            this.Tag = app.IisSettings;
            this.WebApplication = app;
            this.ImageIndex = 2;
            this.SelectedImageIndex = 2;

            this.Nodes.Add(new ExplorerNodeBase("Dummy"));
        }
        public override void LoadNodes()
        {
            base.LoadNodes();

            foreach (KeyValuePair<SPUrlZone, SPIisSettings> setting in this.IisSettings)
            {
                this.Nodes.Add(new IisSettingNode(WebApplication, setting));
            }

        }
    }
}
