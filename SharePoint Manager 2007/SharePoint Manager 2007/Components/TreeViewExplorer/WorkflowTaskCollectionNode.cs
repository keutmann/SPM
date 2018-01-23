using System;
using System.Windows.Forms;
using System.Collections;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Workflow;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    public class WorkflowTaskCollectionNode : ExplorerNodeBase
    {
        public SPWorkflowTaskCollection WorkflowTaskCollection
        {
            get
            {
                return this.Tag as SPWorkflowTaskCollection;
            }
        }

        public WorkflowTaskCollectionNode(object parent, SPWorkflowTaskCollection workFlowTaskCollection)
        {
            this.Tag = workFlowTaskCollection;
            this.SPParent = parent;
            
            this.Setup();

            this.Nodes.Add(new ExplorerNodeBase("Dummy"));
        }


        public override void Setup()
        {
            this.Text = SPMLocalization.GetString("WorkflowsTasks_Text");
            this.ToolTipText = SPMLocalization.GetString("WorkflowsTasks_ToolTip");
            this.Name = "WorkflowsTaskCollection"; 
            //this.BrowserUrl = this.List.ParentWebUrl + "_layouts/viewlsts.aspx";

            int index = Program.Window.Explorer.AddImage(this.ImageUrl());
            this.ImageIndex = index;
            this.SelectedImageIndex = index;
        }

        public override void LoadNodes()
        {
            base.LoadNodes();

            foreach (SPWorkflowTask task in WorkflowTaskCollection)
            {
                this.Nodes.Add(new WorkflowTaskNode(this.SPParent, task));
            }
        }


        public override string ImageUrl()
        {
            return SPMPaths.ImageDirectory + "TASKPANE.GIF";
        }

        public override TabPage[] GetTabPages()
        {
            ArrayList alPages = new ArrayList();

            alPages.AddRange(base.GetTabPages());
            alPages.Add(TabPages.GetXmlPage("Xml", WorkflowTaskCollection.Xml));

            return (TabPage[])alPages.ToArray(typeof(TabPage));
        }
    }
}
