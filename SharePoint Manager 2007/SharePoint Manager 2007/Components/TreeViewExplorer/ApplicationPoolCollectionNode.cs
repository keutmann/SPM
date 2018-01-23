using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    class ApplicationPoolCollectionNode : ExplorerNodeBase
    {
        public SPApplicationPoolCollection ApplicationPools
        {
            get
            {
                return this.Tag as SPApplicationPoolCollection;
            }
        }

        public ApplicationPoolCollectionNode(Object parent, SPApplicationPoolCollection collection)
        {
            this.Text = SPMLocalization.GetString("ApplicationPools_Text");
            this.ToolTipText = SPMLocalization.GetString("ApplicationPools_ToolTip");
            this.Name = "ApplicationPools";
            this.Tag = collection;
            this.SPParent = parent;

            this.ImageIndex = 7;
            this.SelectedImageIndex = 7;

            this.Nodes.Add(new ExplorerNodeBase("Dummy"));
        }


        public override void LoadNodes()
        {
            base.LoadNodes();

            foreach (SPApplicationPool pool in this.ApplicationPools)
            {
                this.Nodes.Add(new ApplicationPoolNode(pool));
            }

        }

        //public override string ImageUrl()
        //{
        //    return global::Keutmann.SharePointManager.Properties.Resources.AppPool;
        //}


    }
}
