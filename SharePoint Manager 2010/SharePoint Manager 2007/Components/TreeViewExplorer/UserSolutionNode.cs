using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    class UserSolutionNode : ExplorerNodeBase
    {
        public SPUserSolution UserSolution
        {
            get
            {
                return this.Tag as SPUserSolution;
            }
        }

        public UserSolutionNode(SPUserSolutionCollection parten, SPUserSolution solution)
        {
            this.Tag = solution;
            this.SPParent = parten;

            this.Setup();
        }

        public override void Setup()
        {
            this.Text = UserSolution.Name;
            this.Name = UserSolution.SolutionId.ToString();

            this.ImageIndex = 4;
            this.SelectedImageIndex = 4;

        }
    }
}
