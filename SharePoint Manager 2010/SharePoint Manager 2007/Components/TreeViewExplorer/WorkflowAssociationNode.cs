using System;
using System.Windows.Forms;
using System.Collections;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Workflow;
using Microsoft.SharePoint.Administration;


using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    public class WorkflowAssociationNode : ExplorerNodeBase
    {
        public SPWorkflowAssociation WorkflowAssociation
        {
            get
            {
                return this.Tag as SPWorkflowAssociation;
            }
        }

        public WorkflowAssociationNode(object parent, SPWorkflowAssociation workflowAssociation)
        {
            this.Tag = workflowAssociation;
            this.SPParent = parent;

            Setup();

            //if (workflowAssociation.p .SPParent this.Definition.Properties.Count > 0)
            //{
            //    this.Nodes.Add(new ExplorerNodeBase("Dummy"));
            //}
        }

        public override void Setup()
        {
            this.Text = WorkflowAssociation.Name;
            this.ToolTipText = WorkflowAssociation.Description;
            this.Name = WorkflowAssociation.Id.ToString();

            int index = Program.Window.Explorer.AddImage(this.ImageUrl());
            this.ImageIndex = index;
            this.SelectedImageIndex = index;
        }

        //public override void LoadNodes()
        //{
        //    base.LoadNodes();

        //    if (this.Definition.Properties.Count > 0)
        //    {
        //        this.Nodes.Add(new PropertyCollectionNode(this.Definition, this.Definition.Properties));
        //    }
        //}

        public override string ImageUrl()
        {
            return SPMPaths.ImageDirectory + "MARR.GIF";
        }

        public override TabPage[] GetTabPages()
        {
            ArrayList alPages = new ArrayList();

            alPages.AddRange(base.GetTabPages());
            alPages.Add(TabPages.GetXmlPage("Soap Xml", WorkflowAssociation.SoapXml));

            return (TabPage[])alPages.ToArray(typeof(TabPage));
        }
    }
}
