using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;


using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    class AlertNode : ExplorerNodeBase
    {
        public SPAlert Alert
        {
            get
            {
                return this.Tag as SPAlert;
            }
        }

        public AlertNode(object parent, SPAlert alert)
        {
            this.Tag = alert;
            this.SPParent = parent;

            Setup();

            this.Nodes.Add(new ExplorerNodeBase("Dummy"));
        }

        public override void Setup()
        {
            this.Text = Alert.Title;
            this.ToolTipText = Alert.Status.ToString();
            this.Name = Alert.ID.ToString();

            int index = Program.Window.Explorer.AddImage(this.ImageUrl());
            this.ImageIndex = index;
            this.SelectedImageIndex = index;
        }

        public override void LoadNodes()
        {
            base.LoadNodes();

            if (!(this.SPParent is SPUser))
            {
                if(this.Alert.User != null)
                {
                this.Nodes.Add(new UserNode(this.Tag, this.Alert.User));
                }
            }
        }

        public override string ImageUrl()
        {
            return SPMPaths.ImageDirectory + "AIF16.GIF";
        }

    }
}
