using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    class SolutionNode : ExplorerNodeBase
    {
        public SPSolution Solution
        {
            get
            {
                return this.Tag as SPSolution;
            }
        }

        public SolutionNode(SPSolution solution)
        {
            this.Tag = solution;
            this.SPParent = solution.Farm;

            this.Setup();

            this.Nodes.Add(new ExplorerNodeBase("Dummy"));
        }

        public override void Setup()
        {
            this.Text = Solution.Name;
            this.Name = Solution.Id.ToString();

            this.ImageIndex = 4;
            this.SelectedImageIndex = 4;

        }

        public override void LoadNodes()
        {
            base.LoadNodes();

            this.Nodes.Add(new PropertyCollectionNode(Solution, Solution.Properties));
        }

    }
}
