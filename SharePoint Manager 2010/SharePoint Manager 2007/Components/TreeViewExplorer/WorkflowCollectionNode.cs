using System;
using System.Windows.Forms;
using System.Collections;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Workflow;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    public class WorkflowCollectionNode : ExplorerNodeBase
    {
        public SPWorkflowCollection WorkflowCollection 
        {
            get
            {
                return this.Tag as SPWorkflowCollection;
            }
        }

        public WorkflowCollectionNode(object parent, SPWorkflowCollection workFlowCollection)
        {
            this.Tag = workFlowCollection;
            this.SPParent = parent;
            
            this.Setup();

            this.Nodes.Add(new ExplorerNodeBase("Dummy"));
        }


        public override void Setup()
        {
            this.Text = SPMLocalization.GetString("Workflows_Text");
            this.ToolTipText = SPMLocalization.GetString("Workflows_ToolTip");
            this.Name = "WorkflowCollection";
            //this.BrowserUrl = this.List.ParentWebUrl + "_layouts/viewlsts.aspx";

            int index = Program.Window.Explorer.AddImage(this.ImageUrl());
            this.ImageIndex = index;
            this.SelectedImageIndex = index;
        }

        public override void LoadNodes()
        {
            base.LoadNodes();

            foreach (SPWorkflow workflow in WorkflowCollection)
            {
                this.Nodes.Add(new WorkflowNode(this.SPParent, workflow));
            }
        }


        public override string ImageUrl()
        {
            return SPMPaths.ImageDirectory + "workflows.gif";
        }

        public override TabPage[] GetTabPages()
        {
            ArrayList alPages = new ArrayList();

            alPages.AddRange(base.GetTabPages());
            alPages.Add(TabPages.GetXmlPage("Xml", WorkflowCollection.Xml));

            return (TabPage[])alPages.ToArray(typeof(TabPage));
        }
        
    }
}
