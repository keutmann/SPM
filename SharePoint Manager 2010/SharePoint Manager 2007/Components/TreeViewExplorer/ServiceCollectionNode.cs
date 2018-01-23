using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    class ServiceCollectionNode : ExplorerNodeBase
    {
        public SPServiceCollection Services = null;

        public ServiceCollectionNode(SPFarm farm)
        {
            this.Text = SPMLocalization.GetString("Services_Text");
            this.ToolTipText = SPMLocalization.GetString("Services_ToolTip");
            this.Name = "ServiceCollection";
            this.Tag = farm.Services;
            this.Services = farm.Services;
            this.SPParent = farm;

            int index = Program.Window.Explorer.AddImage(this.ImageUrl());
            this.ImageIndex = index;
            this.SelectedImageIndex = index;

            this.Nodes.Add(new ExplorerNodeBase("Dummy"));
        }

        public override void LoadNodes()
        {
            base.LoadNodes();

            foreach (SPService service in this.Services)
            {
                this.Nodes.Add(new ServiceNode(service));
            }
        }

        public override string ImageUrl()
        {
            return SPMPaths.ImageDirectory + "SERVICES.GIF";
        }

    }
}
