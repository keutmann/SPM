using System;
using System.Collections.Generic;
using System.Text;


using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;


using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    class SiteNode : ExplorerNodeBase
    {
        public SPSite Site
        {
            get
            {
                return this.Tag as SPSite;
            }
        }

        public SiteNode(SPSite site)
        {
            this.Tag = site;
            this.SPParent = site.WebApplication.Sites;
            //this.ContextMenuStrip = new SiteMenuStrip();

            Setup();

            this.Nodes.Add(new ExplorerNodeBase("Dummy"));
        }

        public override void Setup()
        {
            this.Text = Site.Url;
            this.ToolTipText = SPMLocalization.GetString("SiteCollection_Site_ToolTip");
            this.Name = Site.ID.ToString();

            int index = Program.Window.Explorer.AddImage(this.ImageUrl());
            this.ImageIndex = index;
            this.SelectedImageIndex = index;
        }

        public override void LoadNodes()
        {
            base.LoadNodes();

            SPSite site = this.Tag as SPSite;

            this.AddNode(NodeDisplayLevelType.Simple, new WebNode(site.RootWeb));
            this.AddNode(NodeDisplayLevelType.Medium, new FeatureCollectionNode(site));
            this.AddNode(NodeDisplayLevelType.Medium, new RecycleBinItemCollectionNode(site, site.RecycleBin));
            
            
        }

        public override string ImageUrl()
        {
            return SPMPaths.ImageDirectory + "ITS16.GIF";
        }

        
    }
}
