using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;


using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    class ApplicationPoolNode : ExplorerNodeBase
    {
        public SPApplicationPool ApplicationPool
        {
            get
            {
                return this.Tag as SPApplicationPool;
            }
        }

        public ApplicationPoolNode(SPApplicationPool appPool)
        {
            this.Tag = appPool;
            this.SPParent = appPool.Parent;
            //this.ContextMenuStrip = new SiteMenuStrip();

            Setup();

            //this.Nodes.Add(new ExplorerNodeBase("Dummy"));
        }

        public override void Setup()
        {
            this.Text = ApplicationPool.DisplayName;
            this.ToolTipText = ApplicationPool.Name;
            this.Name = ApplicationPool.Id.ToString();

            this.ImageIndex = 8;
            this.SelectedImageIndex = 8;
        }

        public override void LoadNodes()
        {
            base.LoadNodes();

        }

    }
}
