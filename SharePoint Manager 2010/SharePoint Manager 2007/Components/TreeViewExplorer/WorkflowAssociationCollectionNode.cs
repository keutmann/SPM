using System;
using System.Windows.Forms;
using System.Collections;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Workflow;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    public class WorkflowAssociationCollectionNode : ExplorerNodeBase
    {
        public SPWorkflowAssociationCollection WorkflowAssociations 
        {
            get
            {
                return this.Tag as SPWorkflowAssociationCollection;
            }
        }

        public WorkflowAssociationCollectionNode(object parent, SPWorkflowAssociationCollection workFlowCollection)
        {
            this.Tag = workFlowCollection;
            this.SPParent = parent;
            
            this.Setup();

            this.Nodes.Add(new ExplorerNodeBase("Dummy"));
        }


        public override void Setup()
        {
            
            this.Text = SPMLocalization.GetString("WorkflowAssociations_Text");
            this.ToolTipText = SPMLocalization.GetString("WorkflowAssociations_ToolTip");
            this.Name = "WorkflowAssociations";
            //this.BrowserUrl = this.List.ParentWebUrl + "_layouts/viewlsts.aspx";

            int index = Program.Window.Explorer.AddImage(this.ImageUrl());
            this.ImageIndex = index;
            this.SelectedImageIndex = index;
        }

        public override void LoadNodes()
        {
            base.LoadNodes();

            foreach (SPWorkflowAssociation association in WorkflowAssociations)
            {
                this.Nodes.Add(new WorkflowAssociationNode(this.SPParent, association));
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
            alPages.Add(TabPages.GetXmlPage("Soap Xml", WorkflowAssociations.SoapXml));

            return (TabPage[])alPages.ToArray(typeof(TabPage));
        }
    }
}
