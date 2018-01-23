using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint.Administration;

namespace Keutmann.SharePointManager.Components
{
    class IisSettingNode : ExplorerNodeBase
    {
        public SPIisSettings IisSettings
        {
            get
            {
                return this.Tag as SPIisSettings;
            }
        }
        public IisSettingNode(SPWebApplication app, KeyValuePair<SPUrlZone, SPIisSettings> iisSettings)
        {
            this.Tag = iisSettings.Value;
            this.Name = iisSettings.Key.ToString();
            this.Text = iisSettings.Key.ToString();
            this.ToolTipText = iisSettings.Key.ToString();
            this.BrowserUrl = app.GetResponseUri(iisSettings.Key).ToString();
            this.Setup();
        }
        public override void LoadNodes()
        {
            base.LoadNodes();
        }
    }
}
