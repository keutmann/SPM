using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    class JobDefinitionCollectionNode : ExplorerNodeBase
    {
        public SPJobDefinitionCollection JobDefinitions
        {
            get
            {
                return this.Tag as SPJobDefinitionCollection;
            }
        }

        public JobDefinitionCollectionNode(Object parent, SPJobDefinitionCollection collection)
        {
            this.Text = SPMLocalization.GetString("JobDefinitions_Text");
            this.ToolTipText = SPMLocalization.GetString("JobDefinitions_ToolTip");
            this.Name = "Job Definitions";
            this.Tag = collection;
            this.SPParent = parent;

            this.ImageIndex = 9;
            this.SelectedImageIndex = 9;

            this.Nodes.Add(new ExplorerNodeBase("Dummy"));
        }


        public override void LoadNodes()
        {
            base.LoadNodes();

            foreach (SPJobDefinition def in this.JobDefinitions)
            {
                this.Nodes.Add(new JobDefinitionNode(def));
            }

        }


    }
}
