using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    class ApplicationProxyCollectionNode : ExplorerNodeBase
    {
        public SPServiceApplicationProxyCollection ApplicationProxyCollection
        {
            get
            {
                return this.Tag as SPServiceApplicationProxyCollection;
            }
        }

        public ApplicationProxyCollectionNode(Object parent, SPServiceApplicationProxyCollection collection)
        {
            this.Text = SPMLocalization.GetString("ApplicationProxes_Text");
            this.ToolTipText = SPMLocalization.GetString("ApplicationProxes_ToolTip");
            this.Name = "ServiceProxies";
            this.Tag = collection;
            this.SPParent = parent;

            int index = Program.Window.Explorer.AddImage(this.ImageUrl());
            this.ImageIndex = index;
            this.SelectedImageIndex = index;

            this.Nodes.Add(new ExplorerNodeBase("Dummy"));
        }

        public override void LoadNodes()
        {
            base.LoadNodes();

            foreach (SPServiceApplicationProxy applicationProxy in this.ApplicationProxyCollection)
            {
                this.Nodes.Add(new ApplicationProxyNode(applicationProxy));
            }
        }

        public override string ImageUrl()
        {
            return SPMPaths.ImageDirectory + "SERVICES.GIF";
        }

    }
}
