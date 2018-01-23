using System;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;
using System.Drawing;

namespace Keutmann.SharePointManager.Components
{
    class UserSolutionCollectionNode : ExplorerNodeNew2010Feature
    {

        public SPUserSolutionCollection UserSolutionCollection
        {
            get
            {
                return this.Tag as SPUserSolutionCollection;
            }
        }

        public UserSolutionCollectionNode()
        {
            this.ImageIndex = 4;
            this.SelectedImageIndex = 4;

            this.Nodes.Add("Dummy");
        }

        public UserSolutionCollectionNode(SPSite site)
            : this()
        {
            this.Text = SPMLocalization.GetString("UserSolutionCollection_Text");
            this.ToolTipText = SPMLocalization.GetString("UserSolutionCollection_ToolTip");
            this.Name = "UserSolutionCollection";
            this.Tag = site.Solutions;
            this.SPParent = site;
        }

        public override void LoadNodes()
        {
            base.LoadNodes();

            foreach (SPUserSolution solution in UserSolutionCollection)
            {
                this.Nodes.Add(new UserSolutionNode(UserSolutionCollection, solution));
            }
            
        }

        public override string ImageUrl()
        {
            return SPMPaths.ImageDirectory + "GenericFeature.gif";
        }
    }
}
