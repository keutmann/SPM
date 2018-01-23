using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;


using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    class RunningJobNode : ExplorerNodeBase
    {
        public SPRunningJob Job
        {
            get
            {
                return this.Tag as SPRunningJob;
            }
        }

        public RunningJobNode(SPRunningJob job)
        {
            this.Tag = job;
            this.SPParent = job.Parent;
            //this.ContextMenuStrip = new SiteMenuStrip();

            Setup();

            this.Nodes.Add(new ExplorerNodeBase("Dummy"));
        }

        public override void Setup()
        {
            this.Text = Job.JobDefinitionTitle;
            this.ToolTipText = Job.Status.ToString();
            this.Name = Job.JobDefinitionId.ToString();

            int index = Program.Window.Explorer.AddImage(this.ImageUrl());
            this.ImageIndex = index;
            this.SelectedImageIndex = index;
        }

        public override void LoadNodes()
        {
            base.LoadNodes();

            this.Nodes.Add(new JobDefinitionNode(this.Job.JobDefinition));
        }

        public override string ImageUrl()
        {
            return SPMPaths.ImageDirectory + "MARR.GIF";
        }

    }
}
