using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    public class GroupCollectionNode : ExplorerNodeBase
    {
        public SPGroupCollection Groups
        {
            get
            {
                return this.Tag as SPGroupCollection;
            }
        }

        public GroupCollectionNode(SPWeb web)
        {
            this.Text = SPMLocalization.GetString("GroupCollection_Text");
            this.ToolTipText = SPMLocalization.GetString("GroupCollection_ToolTip");
            this.Name = "SiteGroups";
            this.Tag = web.SiteGroups;
            this.SPParent = web;
            //this.WebNode = webNode;

            int index = Program.Window.Explorer.AddImage(this.ImageUrl());
            this.ImageIndex = index;
            this.SelectedImageIndex = index;

            //this.ContextMenuStrip = SPMMenu.Strips.Refresh;
            if (web.SiteGroups.Count > 0)
            {
                this.Nodes.Add(new ExplorerNodeBase("Dummy"));
            }
            else
            {
                this.HasChildrenLoaded = true;
            }
        }

        public GroupCollectionNode(SPUser user)
        {
            this.Text = SPMLocalization.GetString("GroupCollection_Text");
            this.ToolTipText = SPMLocalization.GetString("GroupCollection_ToolTip");
            this.Name = "OwnedGroups";
            this.Tag = user.OwnedGroups;
            this.SPParent = user;
            //this.WebNode = webNode;

            int index = Program.Window.Explorer.AddImage(this.ImageUrl());
            this.ImageIndex = index;
            this.SelectedImageIndex = index;

            //this.ContextMenuStrip = SPMMenu.Strips.Refresh;
            if (user.OwnedGroups.Count > 0)
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

            foreach (SPGroup group in this.Groups)
            {
                this.AddNode(NodeDisplayLevelType.Advanced, new GroupNode(group));
            }
        }


        public override string ImageUrl()
        {
            return SPMPaths.ImageDirectory + "MYSHRPTS.GIF";
        }
        
    }
}
