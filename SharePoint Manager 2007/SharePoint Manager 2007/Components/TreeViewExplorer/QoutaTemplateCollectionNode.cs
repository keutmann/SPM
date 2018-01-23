using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    class QuotaTemplateCollectionNode : ExplorerNodeBase
    {

        public SPQuotaTemplateCollection QuotaTemplates
        {
            get
            {
                return this.Tag as SPQuotaTemplateCollection;
            }
        }

        public QuotaTemplateCollectionNode(SPWebService webService)
        {
            this.Tag = webService.QuotaTemplates;
            this.SPParent = webService.Farm;

            Setup();

            int index = Program.Window.Explorer.AddImage(this.ImageUrl());
            this.ImageIndex = index;
            this.SelectedImageIndex = index;

            this.Nodes.Add(new ExplorerNodeBase("Dummy"));
        }


        public override void Setup()
        {
            this.Text = SPMLocalization.GetString("QuotaTemplatesCollection_Text");

            this.ToolTipText = SPMLocalization.GetString("QuotaTemplatesCollection_ToolTip");
            this.Name = "QuotaTemplates";
        }

        
        public override void LoadNodes()
        {
            base.LoadNodes();

            foreach (SPQuotaTemplate template in QuotaTemplates)
            {
                this.Nodes.Add(new QuotaTemplateNode(this.SPParent, template));
            }
        }


        public override string ImageUrl()
        {
            return SPMPaths.ImageDirectory + "TABDISP.GIF";
        }
        
    }
}
