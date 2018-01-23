using System;
using System.Windows.Forms;
using System.Collections;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Workflow;
using Microsoft.SharePoint.Administration;


using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    public class EventReceiverDefinitionNode : ExplorerNodeBase
    {
        public SPEventReceiverDefinition EventReceiverDefinition
        {
            get
            {
                return this.Tag as SPEventReceiverDefinition;
            }
        }

        public EventReceiverDefinitionNode(object parent, SPEventReceiverDefinition eventReceiverDefinition)
        {
            this.Tag = eventReceiverDefinition;
            this.SPParent = parent;

            Setup();

        }

        public override void Setup()
        {
            this.Text = this.EventReceiverDefinition.Name;
            if (string.IsNullOrEmpty(this.Text))
            {
                this.Text = this.EventReceiverDefinition.Id.ToString();
            }

            this.ToolTipText = "SPEventReceiverDefinition";
            this.Name = this.EventReceiverDefinition.Id.ToString();

            int index = Program.Window.Explorer.AddImage(this.ImageUrl());
            this.ImageIndex = index;
            this.SelectedImageIndex = index;

            //this.Nodes.Add(new ExplorerNodeBase("Dummy"));
        }

        public override void LoadNodes()
        {
            base.LoadNodes();
        }

        public override string ImageUrl()
        {
            return SPMPaths.ImageDirectory + "MARR.gif";
        }
    }
}
