using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    class ServiceProxyNode : ExplorerNodeBase
    {
        public SPServiceProxy Proxy 
        {
            get
            {
                return this.Tag as SPServiceProxy;
            }
        }

        public ServiceProxyNode(SPServiceProxy proxy)
        {
            this.Tag = proxy;
            this.SPParent = proxy.Farm;

            this.Setup();
        }

        public override void Setup()
        {
            this.Text = Proxy.TypeName;
            this.ToolTipText = Proxy.GetType().Name;
            this.Name = Proxy.Id.ToString();

            int index = Program.Window.Explorer.AddImage(this.ImageUrl());
            this.ImageIndex = index;
            this.SelectedImageIndex = index;
            if (this.Proxy.ApplicationProxies.Count > 0)
            {
                this.Nodes.Add(new ExplorerNodeBase("Dummy"));
            }
        }

        public override void LoadNodes()
        {
            base.LoadNodes();

            if (this.Proxy.ApplicationProxies.Count > 0)
            {
                this.AddNode(NodeDisplayLevelType.Advanced, new ApplicationProxyCollectionNode(this.Tag, Proxy.ApplicationProxies));
            }
        }

        public override string ImageUrl()
        {
            return SPMPaths.ImageDirectory + "SETTINGS.GIF";
        }

    }
}
