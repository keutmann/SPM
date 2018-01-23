using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    class SolutionCollectionNode : ExplorerNodeBase
    {
        private SPFarm CurrentFarm;

        public SolutionCollectionNode(SPFarm farm)
        {
            this.CurrentFarm = farm;

            this.Text = SPMLocalization.GetString("Solutions_Text");
            this.ToolTipText = SPMLocalization.GetString("Solutions_ToolTip");
            this.Name = "Solutions";
            this.Tag = farm.Solutions;
            this.SPParent = CurrentFarm;
            this.Nodes.Add("Dummy");
        }

        public override void LoadNodes()
        {
            base.LoadNodes();

            foreach (SPSolution solution in CurrentFarm.Solutions)
            {
                this.Nodes.Add(new SolutionNode(solution));
            }
        }
    }
}
