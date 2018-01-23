using System;
using System.Windows.Forms;
using System.Collections;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Workflow;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    public class EventReceiverDefinitionCollectionNode : ExplorerNodeBase
    {
        public SPEventReceiverDefinitionCollection EventReceiverCollection
        {
            get
            {
                return this.Tag as SPEventReceiverDefinitionCollection;
            }
        }

        public EventReceiverDefinitionCollectionNode(object parent, SPEventReceiverDefinitionCollection eventReceiverCollection)
        {
            this.Tag = eventReceiverCollection;
            this.SPParent = parent;
            
            this.Setup();

            this.Nodes.Add(new ExplorerNodeBase("Dummy"));
        }


        public override void Setup()
        {
            this.Text = SPMLocalization.GetString("EventReceiverDefinitionCollection_Text");
            this.ToolTipText = SPMLocalization.GetString("EventReceiverDefinitionCollection_ToolTip");
            this.Name = "EventReceiverDefinitionCollection";
            //this.BrowserUrl = this.List.ParentWebUrl + "_layouts/viewlsts.aspx";

            int index = Program.Window.Explorer.AddImage(this.ImageUrl());
            this.ImageIndex = index;
            this.SelectedImageIndex = index;
        }

        public override void LoadNodes()
        {
            base.LoadNodes();

            foreach (SPEventReceiverDefinition def in this.EventReceiverCollection)
            {
                this.Nodes.Add(new EventReceiverDefinitionNode(this.SPParent, def));
            }
        }


        public override string ImageUrl()
        {
            return SPMPaths.ImageDirectory + "TBSPRDSH.GIF";
        }
       
    }
}
