using System;
using System.Web.UI.WebControls.WebParts;

using Microsoft.SharePoint;
using Microsoft.SharePoint.WebPartPages;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    class WebPartCollectionNode : ExplorerNodeBase
    {

        public SPLimitedWebPartManager Manager
        {
            get
            {
                return this.Tag as SPLimitedWebPartManager;
            }
        }

        public WebPartCollectionNode(SPWeb web, object spParent, string url)
        {
            SPLimitedWebPartManager manager = web.GetLimitedWebPartManager(url, System.Web.UI.WebControls.WebParts.PersonalizationScope.Shared);
            Init(spParent, manager);
        }

        public WebPartCollectionNode(object spParent, SPLimitedWebPartManager manager)
        {
            Init(spParent, manager);
        }

        public void Init(object spParent, SPLimitedWebPartManager manager)
        {
            this.Tag = manager;
            
            this.SPParent = spParent;

            int index = Program.Window.Explorer.AddImage(this.ImageUrl());
            this.ImageIndex = index;
            this.SelectedImageIndex = index;

            this.Setup();

            this.Nodes.Add(new ExplorerNodeBase("Dummy"));
        }

        public override void Setup()
        {
            this.Text = SPMLocalization.GetString("WebParts_Text");

            this.ToolTipText = SPMLocalization.GetString("WebParts_ToolTip");
            this.Name = "WebParts";
        }


        public override void LoadNodes()
        {
            base.LoadNodes();
            foreach (System.Web.UI.WebControls.WebParts.WebPart webpart in Manager.WebParts)
            {
                this.Nodes.Add(new WebPartNode(this.SPParent, webpart));
            }
        }

        public override string ImageUrl()
        {
            return SPMPaths.ImageDirectory + "itgen.GIF";
        }
    }
}
