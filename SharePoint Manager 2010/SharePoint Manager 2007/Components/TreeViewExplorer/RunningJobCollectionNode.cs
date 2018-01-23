using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    public class RunningJobCollectionNode : ExplorerNodeBase
    {
        public SPRunningJobCollection Jobs
        {
            get
            {
                return this.Tag as SPRunningJobCollection;
            }
        }

        public RunningJobCollectionNode(SPRunningJobCollection collection)
        {
            this.Text = SPMLocalization.GetString("RunningJobs_Text");
            this.ToolTipText = SPMLocalization.GetString("RunningJobs_ToolTip");
            this.Name = "Running jobs";
            this.Tag = collection;
            this.SPParent = collection.Parent;

            int index = Program.Window.Explorer.AddImage(this.ImageUrl());
            this.ImageIndex = index;
            this.SelectedImageIndex = index;

            this.Nodes.Add(new ExplorerNodeBase("Dummy"));
        }


        public override void LoadNodes()
        {
            base.LoadNodes();

            foreach (SPRunningJob job in this.Jobs)
            {
                this.Nodes.Add(new RunningJobNode(job));
            }

        }

        public override string ImageUrl()
        {
            return SPMPaths.ImageDirectory + "SCT16.GIF";
        }


    }
}
