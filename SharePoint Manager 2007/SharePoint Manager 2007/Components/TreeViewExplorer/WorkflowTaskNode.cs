using System;
using System.Collections;
using System.Windows.Forms;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Workflow;
using Microsoft.SharePoint.Administration;


using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    public class WorkflowTaskNode : ExplorerNodeBase
    {
        public SPWorkflowTask WorkflowTask
        {
            get
            {
                return this.Tag as SPWorkflowTask;
            }
        }

        public WorkflowTaskNode(object parent, SPWorkflowTask task)
        {
            this.Tag = task;
            this.SPParent = parent;

            Setup();

        }

        public override void Setup()
        {
            this.Text = WorkflowTask.Title;
            this.ToolTipText = "Workflow Task";
            this.Name = WorkflowTask.ID.ToString();

            int index = Program.Window.Explorer.AddImage(this.ImageUrl());
            this.ImageIndex = index;
            this.SelectedImageIndex = index;

            //this.Nodes.Add(new ExplorerNodeBase("Dummy"));
        }

        //public override void LoadNodes()
        //{
        //    base.LoadNodes();

        //    if (this.Workflow.Modifications.Count > 0)
        //    {
        //        this.Nodes.Add(new WorkflowModificationCollectionNode(this.Tag, this.Workflow.Modifications));
        //    }
        //}

        public override string ImageUrl()
        {
            return SPMPaths.ImageDirectory + "TASKDONE.GIF";
        }

        public override TabPage[] GetTabPages()
        {
            ArrayList alPages = new ArrayList();

            alPages.AddRange(base.GetTabPages());
            alPages.Add(TabPages.GetXmlPage("Xml", WorkflowTask.Xml));

            return (TabPage[])alPages.ToArray(typeof(TabPage));
        }

    }
}
