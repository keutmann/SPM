using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    class ListCollectionNode : ExplorerNodeBase
    {
        public WebNode WebNode = null;

        public ListCollectionNode(WebNode webNode, SPWeb web)
        {
            this.Text = SPMLocalization.GetString("Lists_Text");
            this.ToolTipText = SPMLocalization.GetString("Lists_ToolTip");
            this.Name = "Lists";
            this.Tag = web.Lists;
            this.SPParent = web;
            this.WebNode = webNode;

            int index = Program.Window.Explorer.AddImage(this.ImageUrl());
            this.ImageIndex = index;
            this.SelectedImageIndex = index;

            //this.ContextMenuStrip = SPMMenu.Strips.Refresh;
            if (web.Lists.Count > 0)
            {
                this.Nodes.Add(new ExplorerNodeBase("Dummy"));
            }
            else
            {
                this.HasChildrenLoaded = true;
            }
        }

        public override void LoadNodes()
        {
            base.LoadNodes();

            SPWeb web = this.SPParent as SPWeb;
            foreach (SPList list in web.Lists)
            {
                if (!list.Hidden)
                {
                    this.AddNode(NodeDisplayLevelType.Simple, new ListNode(WebNode, list));
                }
                else
                {
                    this.AddNode(NodeDisplayLevelType.Medium, new ListNode(WebNode, list)); 
                }
            }
        }


        public override string ImageUrl()
        {
            return SPMPaths.ImageDirectory + "itgen.GIF";
        }
        
    }
}
