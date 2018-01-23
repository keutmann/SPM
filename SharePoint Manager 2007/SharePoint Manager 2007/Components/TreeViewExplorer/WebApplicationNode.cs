using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    class WebApplicationNode : ExplorerNodeBase
    {
        public WebApplicationNode(SPWebService service, SPWebApplication app)
        {
            this.SPParent = service;
            this.Tag = app;
            this.DefaultExpand = true;

            this.Setup();

            this.Nodes.Add(new ExplorerNodeBase("Dummy"));
        }

        public override void Setup()
        {
            SPWebApplication app = this.Tag as SPWebApplication;

            string name = app.DisplayName;
            if (name.Length == 0)
            {
                name = app.Id.ToString();
            }
            this.Text = name;
            this.ToolTipText = SPMLocalization.GetString("WebApplication_ToolTip");
            this.Name = app.Id.ToString();

            this.ImageIndex = 3;
            this.SelectedImageIndex = 3;
        }

        public override void LoadNodes()
        {
            base.LoadNodes();

            SPWebApplication app = this.Tag as SPWebApplication;

            this.AddNode(NodeDisplayLevelType.Simple, new SiteCollectionNode(app));
            this.AddNode(NodeDisplayLevelType.Medium, new FeatureCollectionNode(app));
            this.AddNode(NodeDisplayLevelType.Medium, new PropertyCollectionNode(app, app.Properties));
            this.AddNode(NodeDisplayLevelType.Advanced, new RunningJobCollectionNode(app.RunningJobs));
            this.AddNode(NodeDisplayLevelType.Advanced, new ApplicationPoolNode(app.ApplicationPool));
            this.AddNode(NodeDisplayLevelType.Advanced, new JobDefinitionCollectionNode(app, app.JobDefinitions));
        }
    }

}
