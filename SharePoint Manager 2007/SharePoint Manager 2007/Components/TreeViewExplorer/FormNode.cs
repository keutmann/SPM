using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    class FormNode : ExplorerNodeBase
    {

        public SPForm Form
        {
            get
            {
                return this.Tag as SPForm;
            }
        }


        public FormNode(SPForm form)
        {
            this.Tag = form;
            this.SPParent = form.ParentList;

            int index = Program.Window.Explorer.AddImage(this.ImageUrl());
            this.ImageIndex = index;
            this.SelectedImageIndex = index;

            this.Setup();

            this.Nodes.Add(new ExplorerNodeBase("Dummy"));
        }

        public override void Setup()
        {
            this.Text = Form.Url.Substring(Form.Url.LastIndexOf("/")+1);

            this.ToolTipText = Form.Url;
            this.Name = Form.ID.ToString();
            //this.BrowserUrl = Form.Url;
        }


        public override void LoadNodes()
        {
            base.LoadNodes();

            this.Nodes.Add(new WebPartCollectionNode(Form.ParentList.ParentWeb, Form, Form.Url));
        }

        public override string ImageUrl()
        {
            return SPMPaths.ImageDirectory + "ASPX16.GIF";
        }
    }
}
