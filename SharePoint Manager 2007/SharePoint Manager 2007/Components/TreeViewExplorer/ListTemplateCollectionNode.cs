using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    public class ListTemplateCollectionNode : ExplorerNodeBase
    {
        public WebNode WebTreeNode = null;

        public ListTemplateCollectionNode(WebNode webTreeNode, SPWeb web)
        {
            this.Text = SPMLocalization.GetString("ListTemplates_Text");
            this.ToolTipText = SPMLocalization.GetString("ListTemplates_ToolTip");
            this.Name = "ListTemplates";
            this.Tag = web.ListTemplates;
            this.SPParent = web;
            this.WebTreeNode = webTreeNode;

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
            foreach (SPListTemplate template in web.ListTemplates)
            {
                if (!template.Hidden)
                {
                    this.AddNode(NodeDisplayLevelType.Simple, new ListTemplateNode(this.WebTreeNode, template));
                }
                else
                {
                    this.AddNode(NodeDisplayLevelType.Medium, new ListTemplateNode(this.WebTreeNode, template));
                }
            }
        }


        public override string ImageUrl()
        {
            return SPMPaths.ImageDirectory + "itgen.GIF";
        }
        
    }
}
