/* Review by Carsten Keutmann 11 feb. 2007
 * Setup() method has to be overridden so the "Refresh" menu system works properly.
 * 
 */
using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    class SiteCollectionNode : ExplorerNodeBase
    {
        public SPSiteCollection Sites
        {
            get
            {
                return this.Tag as SPSiteCollection;
            }
        }


        public SiteCollectionNode(SPWebApplication webApp)
        {
            this.Name = "Site Collection";
            this.Tag = webApp.Sites;
            this.SPParent = webApp;
            this.DefaultExpand = true;

            this.ContextMenuStrip = new SiteCollectionMenuStrip();

            int index = Program.Window.Explorer.AddImage(this.ImageUrl());
            this.ImageIndex = index;
            this.SelectedImageIndex = index;

            Setup();

            this.Nodes.Add(new ExplorerNodeBase("Dummy"));
        }

        public override void Setup()
        {
            this.Text = SPMLocalization.GetString("SiteCollection_SiteCollection_Text");
            this.ToolTipText = SPMLocalization.GetString("SiteCollection_SiteCollection_ToolTip");
        }

        public override void LoadNodes()
        {
            base.LoadNodes();

            foreach (SPSite site in Sites)
            {
                this.Nodes.Add(new SiteNode(site));
            }

        }

        public override string ImageUrl()
        {
            return SPMPaths.ImageDirectory + "coll_site.gif";
        }

    }
}
