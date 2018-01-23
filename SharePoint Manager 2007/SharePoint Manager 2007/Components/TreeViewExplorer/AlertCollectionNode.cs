

using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    public class AlertCollectionNode : ExplorerNodeBase
    {
        public SPAlertCollection Alerts
        {
            get
            {
                return this.Tag as SPAlertCollection;
            }
        }


        public AlertCollectionNode(Object parent, SPAlertCollection collection)
        {
            this.Text = SPMLocalization.GetString("AlertCollection_Text");
            this.ToolTipText = SPMLocalization.GetString("AlertCollection_ToolTip");
            this.Name = "AlertCollection";
            this.Tag = collection;
            this.SPParent = parent;

            int index = Program.Window.Explorer.AddImage(this.ImageUrl());
            this.ImageIndex = index;
            this.SelectedImageIndex = index;

            this.Nodes.Add(new ExplorerNodeBase("Dummy"));
        }


        public override void LoadNodes()
        {
            base.LoadNodes();

            foreach (SPAlert alert in this.Alerts)
            {
                this.Nodes.Add(new AlertNode(this.Tag, alert));
            }

        }

        public override string ImageUrl()
        {
            return SPMPaths.ImageDirectory + "AIF16.GIF";
        }


    }
}
