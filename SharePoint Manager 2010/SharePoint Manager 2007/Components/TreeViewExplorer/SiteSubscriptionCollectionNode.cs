using System;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;
using System.Drawing;

namespace Keutmann.SharePointManager.Components
{
    class SiteSubscriptionCollectionNode : ExplorerNodeNew2010Feature
    {

        public SPSiteSubscriptionCollection SiteSubscription
        {
            get
            {
                return this.Tag as SPSiteSubscriptionCollection;
            }
        }

        public SiteSubscriptionCollectionNode()
        {
            this.ImageIndex = 4;
            this.SelectedImageIndex = 4;

            this.Nodes.Add("Dummy");
        }

        public SiteSubscriptionCollectionNode(SPFarm farm)
            : this()
        {
            this.Text = SPMLocalization.GetString("SiteSubscriptionCollection_Text");
            this.ToolTipText = SPMLocalization.GetString("SiteSubscriptionCollection_ToolTip");
            this.Name = "SiteSubscriptionCollection";
            this.Tag = farm.SiteSubscriptions;
            this.SPParent = farm;
        }

        public override void LoadNodes()
        {
            base.LoadNodes();

            foreach (SPSiteSubscription siteSubscription in SiteSubscription)
            {
                this.Nodes.Add(new SiteSubscriptionNode(SiteSubscription, siteSubscription));
            }            
        }

        public override string ImageUrl()
        {
            return SPMPaths.ImageDirectory + "GenericFeature.gif";
        }
    }
}
