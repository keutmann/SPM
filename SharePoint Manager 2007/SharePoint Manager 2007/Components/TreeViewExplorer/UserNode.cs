using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;


using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    class UserNode : ExplorerNodeBase
    {
        public SPUser User
        {
            get
            {
                return this.Tag as SPUser;
            }
        }

        public UserNode(object parent, SPUser user)
        {
            this.Tag = user;
            this.SPParent = parent;
            //this.ContextMenuStrip = new SiteMenuStrip();

            Setup();

            this.Nodes.Add(new ExplorerNodeBase("Dummy"));
        }

        public override void Setup()
        {
            this.Text = User.Name;
            this.ToolTipText = User.LoginName;
            this.Name = User.ID.ToString();

            int index = Program.Window.Explorer.AddImage(this.ImageUrl());
            this.ImageIndex = index;
            this.SelectedImageIndex = index;
        }

        public override void LoadNodes()
        {
            base.LoadNodes();

            if(!(this.SPParent is SPAlert) && this.User.Alerts.Count > 0)
            {
                this.Nodes.Add(new AlertCollectionNode(this.User, this.User.Alerts));
            }
        }

        public override string ImageUrl()
        {
            return SPMPaths.ImageDirectory + "ULS16.GIF";
        }

    }
}
