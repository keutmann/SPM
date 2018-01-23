using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    class FormCollectionNode : ExplorerNodeBase
    {
        

        public SPFormCollection Forms
        {
            get
            {
                return this.Tag as SPFormCollection;
            }
        }

        public FormCollectionNode(SPList list)
        {
            this.Tag = list.Forms;
            this.SPParent = list;

            this.Setup();

            this.Nodes.Add(new ExplorerNodeBase("Dummy"));
        }


        public override void Setup()
        {
            this.Text = SPMLocalization.GetString("Forms_Text");
            this.ToolTipText = SPMLocalization.GetString("Forms_ToolTip");
            this.Name = "Forms";
            //this.BrowserUrl = this.List.ParentWebUrl + "_layouts/viewlsts.aspx";

            int index = Program.Window.Explorer.AddImage(this.ImageUrl());
            this.ImageIndex = index;
            this.SelectedImageIndex = index;
        }

        public override void LoadNodes()
        {
            base.LoadNodes();

            foreach (SPForm form in Forms)
            {
                this.Nodes.Add(new FormNode(form));
            }
            
        }


        public override string ImageUrl()
        {
            return SPMPaths.ImageDirectory + "ASA16.GIF";
        }
        
    }
}
