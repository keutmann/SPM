using System;
using System.Windows.Forms;
using System.Collections;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Workflow;
using Microsoft.SharePoint.Administration;


using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    public class WorkflowNode : ExplorerNodeBase
    {
        public SPWorkflow Workflow
        {
            get
            {
                return this.Tag as SPWorkflow;
            }
        }

        public WorkflowNode(object parent, SPWorkflow workflow)
        {
            this.Tag = workflow;
            this.SPParent = parent;

            Setup();

        }

        public override void Setup()
        {
            this.Text = Workflow.ParentAssociation.Name;
            this.ToolTipText = Workflow.ParentAssociation.Description;
            this.Name = Workflow.InstanceId.ToString();

            int index = Program.Window.Explorer.AddImage(this.ImageUrl());
            this.ImageIndex = index;
            this.SelectedImageIndex = index;

            this.Nodes.Add(new ExplorerNodeBase("Dummy"));
        }

        public override void LoadNodes()
        {
            base.LoadNodes();

            if (this.Workflow.Modifications.Count > 0)
            {
                this.Nodes.Add(new WorkflowModificationCollectionNode(this.Tag, this.Workflow.Modifications));
            }
            this.Nodes.Add(new WorkflowTaskCollectionNode(this.Tag, this.Workflow.Tasks));
        }

        public override string ImageUrl()
        {
            return SPMPaths.ImageDirectory + "MARR.GIF";
        }

        public override TabPage[] GetTabPages()
        {
            ArrayList alPages = new ArrayList();

            alPages.AddRange(base.GetTabPages());
            alPages.Add(TabPages.GetXmlPage("Xml", Workflow.Xml));

            return (TabPage[])alPages.ToArray(typeof(TabPage));
        }
    }
}
