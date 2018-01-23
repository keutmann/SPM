using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    class ListItemVersionNode : ExplorerNodeBase
    {

        public SPListItemVersion Version
        {
            get
            {
                return this.Tag as SPListItemVersion;
            }
        }

        public ListItemVersionNode(SPListItemVersion version)
        {
            this.Tag = version;
            this.SPParent = version.ListItem.ParentList;

            this.Setup();

            this.Nodes.Add(new ExplorerNodeBase("Dummy"));
        }

        public override void Setup()
        {
            this.Text = this.Version.VersionLabel;
            this.ToolTipText = Version.ListItem.Url;
            this.Name = Version.ListItem.Url;

            int index = Program.Window.Explorer.AddImage(this.ImageUrl());
            this.ImageIndex = index;
            this.SelectedImageIndex = index;
        }


        public override void LoadNodes()
        {
            base.LoadNodes();

            this.Nodes.Add(new ListItemNode(Version.ListItem, false));
            this.Nodes.Add(new FieldCollectionNode(this.Version, this.Version.Fields));

        }
        public override string ImageUrl()
        {
            return SPMPaths.ImageDirectory + "ICGEN.GIF";
        }
    }
}
