using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    public class UserCollectionNode : ExplorerNodeBase
    {
        public SPUserCollection Users
        {
            get
            {
                return this.Tag as SPUserCollection;
            }
        }

        public UserCollectionNode(Object parent, SPUserCollection collection)
        {
            this.Text = SPMLocalization.GetString("Users_Text");
            this.ToolTipText = SPMLocalization.GetString("Users_ToolTip");
            this.Name = "User Collection";
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

            foreach (SPUser user in this.Users)
            {
                this.Nodes.Add(new UserNode(this.Tag, user));
            }

        }

        public override string ImageUrl()
        {
            return SPMPaths.ImageDirectory + "MNGATT.GIF";
        }


    }
}
