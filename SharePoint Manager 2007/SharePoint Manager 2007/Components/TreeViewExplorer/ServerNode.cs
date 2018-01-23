using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    class ServerNode : ExplorerNodeBase
    {
        public SPServer Server
        {
            get
            {
                return this.Tag as SPServer;
            }
        }

        public ServerNode(SPServer server)
        {
            this.Tag = server;

            this.Setup();

            this.Nodes.Add(new ExplorerNodeBase("Dummy"));
        }

        public override void Setup()
        {
            this.Text = Server.DisplayName;
            this.Name = Server.Id.ToString();

            this.ImageIndex = 4;
            this.SelectedImageIndex = 4;

        }

        public override void LoadNodes()
        {
            base.LoadNodes();

            this.Nodes.Add(new PropertyCollectionNode(Server, Server.Properties));
        }


    }
}
