using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Workflow;
using Microsoft.SharePoint.Administration;


using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    public class WorkflowModificationNode : ExplorerNodeBase
    {

        public SPWorkflowModification WorkflowModification
        {
            get
            {
                return this.Tag as SPWorkflowModification;
            }
        }

        public WorkflowModificationNode(object parent, SPWorkflowModification workflowModification)
        {
            this.Tag = workflowModification;
            this.SPParent = parent;

            Setup();
        }

        public override void Setup()
        {
            this.Text = this.WorkflowModification.Id.ToString();
            this.ToolTipText = SPMLocalization.GetString("WorkflowModification_ToolTip");
            this.Name = WorkflowModification.Id.ToString();

            int index = Program.Window.Explorer.AddImage(this.ImageUrl());
            this.ImageIndex = index;
            this.SelectedImageIndex = index;

            //this.Nodes.Add(new ExplorerNodeBase("Dummy"));
        }

        //public override void LoadNodes()
        //{
        //    base.LoadNodes();

        //    //this.WorkflowModification.
        //    //if (this.Workflow.Modifications.Count > 0)
        //    //{
        //    //    this.Nodes.Add(new WorkflowModificationNode(this.SPParent this.Definition.Properties));
        //    //}
        //}

        public override string ImageUrl()
        {
            return SPMPaths.ImageDirectory + "MARR.GIF";
        }

    }
}
