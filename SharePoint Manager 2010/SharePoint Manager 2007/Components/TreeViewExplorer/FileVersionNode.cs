using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    class FileVersionNode : ExplorerNodeBase
    {

        public SPFileVersion Version
        {
            get
            {
                return this.Tag as SPFileVersion;
            }
        }

        public FileVersionNode(SPFileVersion version)
        {
            this.Tag = version;

            this.Setup();

            if (version.File.Item != null)
            {
                this.SPParent = version.File.Item.ParentList;
            }
            this.Nodes.Add(new ExplorerNodeBase("Dummy"));
        }

        public override void Setup()
        {
            this.Text = Version.VersionLabel;
            this.ToolTipText = Version.File.Url;
            this.Name = Version.File.Url;

            int index = Program.Window.Explorer.AddImage(this.ImageUrl());
            this.ImageIndex = index;
            this.SelectedImageIndex = index;
        }

        public override void LoadNodes()
        {
            base.LoadNodes();
 
            this.Nodes.Add(new PropertyCollectionNode(Version, Version.Properties));
            this.Nodes.Add(new FileNode(Version.File, false));
        }

        public override string ImageUrl()
        {
            return SPMPaths.ImageDirectory + "ICGEN.GIF";
        }

    }
}
