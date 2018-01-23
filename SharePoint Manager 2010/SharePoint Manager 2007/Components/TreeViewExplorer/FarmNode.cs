using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Text;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    class FarmNode : ExplorerNodeBase
    {
        public SPFarm Farm
        {
            get
            {
                return this.Tag as SPFarm;
            }
        }

        public FarmNode(SPFarm farm)
        {
            this.Tag = farm;
            this.DefaultExpand = true;

            this.Setup();

            this.Nodes.Add(new ExplorerNodeBase("Dummy"));
        }

        public override void Setup()
        {
            this.Text = Farm.DisplayName;
            this.Name = Farm.Id.ToString();

            this.ImageIndex = 5;
            this.SelectedImageIndex = 5;

        }

        public override void LoadNodes()
        {
            base.LoadNodes();

            this.AddNode(NodeDisplayLevelType.Medium, new FeatureCollectionDefinitionNode(Farm, Farm.FeatureDefinitions));
            this.AddNode(NodeDisplayLevelType.Advanced, new SolutionCollectionNode(Farm));
            this.AddNode(NodeDisplayLevelType.Advanced, new ServerCollectionNode(Farm));
            this.AddNode(NodeDisplayLevelType.Advanced, new ServiceCollectionNode(Farm));
            this.AddNode(NodeDisplayLevelType.Advanced, new ServiceProxyCollectionNode(Farm));
            this.AddNode(NodeDisplayLevelType.Advanced, new PropertyCollectionNode(Farm, Farm.Properties));
            this.AddNode(NodeDisplayLevelType.Advanced, new SiteSubscriptionCollectionNode(Farm));
            SPMFarmHelper farmHelper = new SPMFarmHelper(Farm);

            this.AddNode(NodeDisplayLevelType.Simple, new WebServiceNode(SPMLocalization.GetString("ContentService"), farmHelper.ContentWebService, true));
            this.AddNode(NodeDisplayLevelType.Simple, new WebServiceNode(SPMLocalization.GetString("AdministrationService"), farmHelper.AdministrationWebService, false));
        }


    }
}
