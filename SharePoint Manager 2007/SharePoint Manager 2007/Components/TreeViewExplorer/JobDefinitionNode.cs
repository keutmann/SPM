using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;


using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    class JobDefinitionNode : ExplorerNodeBase
    {
        public SPJobDefinition Definition
        {
            get
            {
                return this.Tag as SPJobDefinition;
            }
        }

        public JobDefinitionNode(SPJobDefinition definition)
        {
            this.Tag = definition;
            this.SPParent = definition.Parent;
            //this.ContextMenuStrip = new SiteMenuStrip();

            Setup();

            if (this.Definition.Properties.Count > 0)
            {
                this.Nodes.Add(new ExplorerNodeBase("Dummy"));
            }
        }

        public override void Setup()
        {
            this.Text = Definition.Title;
            this.ToolTipText = Definition.DisplayName;
            this.Name = Definition.Id.ToString();

            int index = Program.Window.Explorer.AddImage(this.ImageUrl());
            this.ImageIndex = index;
            this.SelectedImageIndex = index;
        }

        public override void LoadNodes()
        {
            base.LoadNodes();

            if (this.Definition.Properties.Count > 0)
            {
                this.Nodes.Add(new PropertyCollectionNode(this.Definition, this.Definition.Properties));
            }
        }

        public override string ImageUrl()
        {
            return SPMPaths.ImageDirectory + "MARR.GIF";
        }

    }
}
