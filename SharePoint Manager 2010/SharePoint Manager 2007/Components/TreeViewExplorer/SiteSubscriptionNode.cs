using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    class SiteSubscriptionNode : ExplorerNodeBase
    {
        public SPSiteSubscription SiteSubscription
        {
            get
            {
                return this.Tag as SPSiteSubscription;
            }
        }

        public SiteSubscriptionNode(SPSiteSubscriptionCollection parten, SPSiteSubscription siteSubscription)
        {
            this.Tag = siteSubscription;
            this.SPParent = parten;
            this.Nodes.Add("Dummy");
            
            this.Setup();
        }
        public override void LoadNodes()
        {
            base.LoadNodes();
            foreach (SPSite site in SiteSubscription.Sites)
            {
                this.Nodes.Add(new SiteNode(site));
            }
        }
        public override void Setup()
        {
            this.Text = SiteSubscription.Id.Id.ToString();
            this.Name = SiteSubscription.Id.Id.ToString();

            this.ImageIndex = 4;
            this.SelectedImageIndex = 4;            
        }
    }
}
