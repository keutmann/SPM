using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Workflow;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    public class WorkflowModificationCollectionNode : ExplorerNodeBase
    {


        public SPWorkflowModificationCollection WorkflowModificationCollection 
        {
            get
            {
                return this.Tag as SPWorkflowModificationCollection;
            }
        }

        public WorkflowModificationCollectionNode(object parent, SPWorkflowModificationCollection modificationCollection)
        {
            this.Tag = modificationCollection;
            this.SPParent = parent;
            
            this.Setup();

            this.Nodes.Add(new ExplorerNodeBase("Dummy"));
        }


        public override void Setup()
        {
            this.Text = SPMLocalization.GetString("WorkflowModifications_Text");
            this.ToolTipText = SPMLocalization.GetString("WorkflowModifications_ToolTip");
            this.Name = "WorkflowCollection";
            //this.BrowserUrl = this.List.ParentWebUrl + "_layouts/viewlsts.aspx";

            int index = Program.Window.Explorer.AddImage(this.ImageUrl());
            this.ImageIndex = index;
            this.SelectedImageIndex = index;
        }

        public override void LoadNodes()
        {
            base.LoadNodes();

            foreach (SPWorkflowModification modification in WorkflowModificationCollection)
            {
                this.Nodes.Add(new WorkflowModificationNode(this.SPParent, modification));
            }
        }


        public override string ImageUrl()
        {
            return SPMPaths.ImageDirectory + "VARIATION.GIF";
        }
        
    }
}
