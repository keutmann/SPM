using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    class ServiceProxyCollectionNode : ExplorerNodeNew2010Feature
    {
        public SPServiceProxyCollection ServiceProxies = null;

        public ServiceProxyCollectionNode(SPFarm farm)
        {
            this.Text = SPMLocalization.GetString("ServiceProxies_Text");
            this.ToolTipText = SPMLocalization.GetString("ServiceProxies_ToolTip");
            this.Name = "ServiceProxies";
            this.Tag = farm.ServiceProxies;
            this.ServiceProxies = farm.ServiceProxies;
            this.SPParent = farm;

            int index = Program.Window.Explorer.AddImage(this.ImageUrl());
            this.ImageIndex = index;
            this.SelectedImageIndex = index;

            this.Nodes.Add(new ExplorerNodeBase("Dummy"));
        }

        public override void LoadNodes()
        {
            base.LoadNodes();

            foreach (SPServiceProxy serviceProxy in this.ServiceProxies)
            {
                this.Nodes.Add(new ServiceProxyNode(serviceProxy));
            }
        }

        public override string ImageUrl()
        {
            return SPMPaths.ImageDirectory + "SERVICES.GIF";
        }

    }
}
