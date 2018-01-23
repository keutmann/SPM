using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System.Windows.Forms;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    class WebApplicationCollectionNode : ExplorerNodeBase
    {
        public SPWebApplicationCollection WebApplications
        {
            get
            {
                return this.Tag as SPWebApplicationCollection;
            }
        }

        public WebApplicationCollectionNode(SPWebService service)
        {
            this.Text = SPMLocalization.GetString("WebApplications_Text");
            this.ToolTipText = SPMLocalization.GetString("WebApplications_ToolTip");
            this.Name = "WebApplications";
            this.Tag = service.WebApplications;
            this.SPParent = service;
            this.DefaultExpand = true;

            this.ImageIndex = 2;
            this.SelectedImageIndex = 2;
            
            this.Nodes.Add("Dummy");

        }

        public override void LoadNodes()
        {
            HasChildrenLoaded = true;
            this.Nodes.Clear();

            foreach (SPWebApplication app in WebApplications)
            {
                this.Nodes.Add(new WebApplicationNode(this.SPParent as SPWebService, app));
            }
        }

    }
}
