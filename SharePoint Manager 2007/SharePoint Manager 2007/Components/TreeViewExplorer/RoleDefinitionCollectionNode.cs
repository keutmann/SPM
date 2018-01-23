using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    public class RoleDefinitionCollectionNode : ExplorerNodeBase
    {
        public SPRoleDefinitionCollection RoleDefinitions
        {
            get
            {
                return this.Tag as SPRoleDefinitionCollection;
            }
        }

        public RoleDefinitionCollectionNode(SPWeb web)
        {
            this.Text = SPMLocalization.GetString("RoleDefinitionCollection_Text");
            this.ToolTipText = SPMLocalization.GetString("RoleDefinitionCollection_ToolTip");
            this.Name = "RoleDefinitionCollection";
            this.Tag = web.RoleDefinitions;
            this.SPParent = web;

            int index = Program.Window.Explorer.AddImage(this.ImageUrl());
            this.ImageIndex = index;
            this.SelectedImageIndex = index;

            if (web.SiteGroups.Count > 0)
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

            foreach (SPRoleDefinition roleDef in this.RoleDefinitions)
            {
                this.AddNode(NodeDisplayLevelType.Advanced, new RoleDefinitionNode(roleDef));
            }
        }


        public override string ImageUrl()
        {
            return SPMPaths.ImageDirectory + "TASKPANE.GIF";
        }
        
    }
}
