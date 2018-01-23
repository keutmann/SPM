using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    class ServiceNode : ExplorerNodeBase
    {
        public SPService Service 
        {
            get
            {
                return this.Tag as SPService;
            }
        }

        public ServiceNode(SPService service)
        {
            this.Tag = service;
            this.SPParent = service.Farm;

            this.Setup();

            if (Service.Properties.Count > 0 || Service.JobDefinitions.Count > 0)
            {
                this.Nodes.Add(new ExplorerNodeBase("Dummy"));
            }
        }

        public override void Setup()
        {
            this.Text = Service.TypeName;
            this.ToolTipText = Service.GetType().Name;
            this.Name = Service.Id.ToString();

            int index = Program.Window.Explorer.AddImage(this.ImageUrl());
            this.ImageIndex = index;
            this.SelectedImageIndex = index;

        }

        public override void LoadNodes()
        {
            base.LoadNodes();

            if (this.Service.JobDefinitions.Count > 0)
            {
                this.AddNode(NodeDisplayLevelType.Advanced, new JobDefinitionCollectionNode(this.Tag, Service.JobDefinitions));
            }

            if (Service.Properties.Count > 0)
            {
                this.AddNode(NodeDisplayLevelType.Advanced, new PropertyCollectionNode(Service, Service.Properties));
            }
        }

        public override string ImageUrl()
        {
            return SPMPaths.ImageDirectory + "SETTINGS.GIF";
        }

    }
}
