using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    class ServerCollectionNode : ExplorerNodeBase
    {

        private SPFarm CurrentFarm;

        public ServerCollectionNode(SPFarm farm)
        {
            this.CurrentFarm = farm;

            this.Text = SPMLocalization.GetString("Servers_Text");
            this.ToolTipText = SPMLocalization.GetString("Servers_ToolTip");
            this.Name = "Servers";
            this.Tag = farm.Servers;
            this.SPParent = CurrentFarm;

            this.ImageIndex = 1;
            this.SelectedImageIndex = 1;
            
            this.Nodes.Add("Dummy");
        }

        public override void LoadNodes()
        {
            HasChildrenLoaded = true;
            this.Nodes.Clear();

            foreach (SPServer server in CurrentFarm.Servers)
            {
                this.Nodes.Add(new ServerNode(server));
            }
        }

    }
}
