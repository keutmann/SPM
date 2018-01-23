using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    class ApplicationProxyNode : ExplorerNodeBase
    {
        public SPServiceApplicationProxy Proxy 
        {
            get
            {
                return this.Tag as SPServiceApplicationProxy;
            }
        }

        public ApplicationProxyNode(SPServiceApplicationProxy proxy)
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

        }

        public override void LoadNodes()
        {
            base.LoadNodes();
        }

        public override string ImageUrl()
        {
            return SPMPaths.ImageDirectory + "SETTINGS.GIF";
        }

    }
}
