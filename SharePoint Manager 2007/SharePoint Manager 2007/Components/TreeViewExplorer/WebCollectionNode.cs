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
    class WebCollectionNode : ExplorerNodeBase
    {
        public SPWebCollection Webs
        {
            get
            {
                return this.Tag as SPWebCollection;
            }
        }


        public WebCollectionNode(SPWeb web)
        {
            this.Name = "Web Collection";
            this.Tag = web.Webs;
            this.SPParent = web;

            int index = Program.Window.Explorer.AddImage(this.ImageUrl());
            this.ImageIndex = index;
            this.SelectedImageIndex = index;

            Setup();

            if (web.Webs.Count > 0)
            {
                this.Nodes.Add(new ExplorerNodeBase("Dummy"));
            }
            else
            {
                this.HasChildrenLoaded = true;
            }
        }

        public override void Setup()
        {
            this.Text = SPMLocalization.GetString("Webs_Text");
            this.ToolTipText = SPMLocalization.GetString("Webs_ToolTip");
        }

        public override void LoadNodes()
        {
            base.LoadNodes();
        
            foreach (SPWeb childweb in this.Webs)
            {
                this.Nodes.Add(new WebNode(childweb));
            }

        }

        public override string ImageUrl()
        {
            return SPMPaths.ImageDirectory + "titlegraphic.gif";
        }



    }
}
