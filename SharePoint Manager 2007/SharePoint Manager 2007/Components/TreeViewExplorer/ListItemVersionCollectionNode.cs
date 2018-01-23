using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    class ListItemVersionCollectionNode : ExplorerNodeBase
    {

        public SPListItemVersionCollection VersionCollection
        {
            get
            {
                return this.Tag as SPListItemVersionCollection;
            }
        }

        public ListItemVersionCollectionNode(SPListItem item)
        {
            this.Tag = item.Versions;
            this.SPParent = item;

            this.Setup();

            this.Nodes.Add(new ExplorerNodeBase("Dummy"));
        }

        public override void Setup()
        {
            this.Text = SPMLocalization.GetString("VersionHistory_ListItem_Text");
            this.ToolTipText = SPMLocalization.GetString("VersionHistory_ListItem_ToolTip");
            this.Name = "Version History";

            int index = Program.Window.Explorer.AddImage(this.ImageUrl());
            this.ImageIndex = index;
            this.SelectedImageIndex = index;
        }

        public override void LoadNodes()
        {
            base.LoadNodes();

            foreach (SPListItemVersion version in this.VersionCollection)
            {
                this.Nodes.Add(new ListItemVersionNode(version));
            }
        }

        public override string ImageUrl()
        {
            return SPMPaths.ImageDirectory + "versions.gif";
        }

    }
}
