using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    class WebServiceNode : ExplorerNodeBase
    {
        public string CustomName = string.Empty;

        public SPWebService Service
        {
            get
            {
                return this.Tag as SPWebService;
            }
        }

        public WebServiceNode(string name, SPWebService service, bool defaultExpand)
        {
            this.CustomName = name;
            this.ToolTipText = service.GetType().Name;
            this.Tag = service;
            this.DefaultExpand = defaultExpand;

            Setup();

            this.Nodes.Add(new ExplorerNodeBase("Dummy"));
        }

        public override void Setup()
        {
            this.Text = CustomName;
            this.Name = Service.Id.ToString();

            this.ImageIndex = 0;
            this.SelectedImageIndex = 0;
        }

        public override void LoadNodes()
        {
            base.LoadNodes();

            this.AddNode(NodeDisplayLevelType.Simple, new WebApplicationCollectionNode(this.Service));
            this.AddNode(NodeDisplayLevelType.Medium, new PropertyCollectionNode(Service, Service.Properties));
            this.AddNode(NodeDisplayLevelType.Advanced, new ApplicationPoolCollectionNode(this.Tag, this.Service.ApplicationPools));
            this.AddNode(NodeDisplayLevelType.Advanced, new QuotaTemplateCollectionNode(this.Service));

        }

    }
}
