using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    class FileVersionCollectionNode : ExplorerNodeBase
    {
        public SPFileVersionCollection VersionCollection
        {
            get
            {
                return this.Tag as SPFileVersionCollection;
            }
        }

        public FileVersionCollectionNode(SPFile file)
        {
            this.Tag = file.Versions;
            this.SPParent = file;

            this.Setup();

            this.Nodes.Add(new ExplorerNodeBase("Dummy"));
        }

        public override void Setup()
        {
            this.Text = SPMLocalization.GetString("VersionHistory_File_Text");
            this.ToolTipText = SPMLocalization.GetString("VersionHistory_File_ToolTip");
            this.Name = "Version History";

            int index = Program.Window.Explorer.AddImage(this.ImageUrl());
            this.ImageIndex = index;
            this.SelectedImageIndex = index;
        }

        public override void LoadNodes()
        {
            base.LoadNodes();

            foreach (SPFileVersion version in this.VersionCollection)
            {
                this.Nodes.Add(new FileVersionNode(version));
            }
        }

        public override string ImageUrl()
        {
            return SPMPaths.ImageDirectory + "versions.gif";
        }

    }
}
