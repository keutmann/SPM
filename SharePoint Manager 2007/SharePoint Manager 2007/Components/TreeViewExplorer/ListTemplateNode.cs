using System;
using System.IO;
using System.Xml;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    public class ListTemplateNode : ExplorerNodeBase
    {

        public WebNode WebTreeNode = null;

        public SPListTemplate Template
        {
            get
            {
                return this.Tag as SPListTemplate;
            }
        }


        public ListTemplateNode(WebNode webTreeNode, SPListTemplate template)
        {
            this.Tag = template;
            this.SPParent = webTreeNode.Web;
            this.WebTreeNode = webTreeNode;

            this.Setup();
        }

        public override void Setup()
        {
            this.Text = this.Template.Name;
            this.ToolTipText = this.Template.Description;
            this.Name = this.Template.Name;

            int index = Program.Window.Explorer.AddImage(this.ImageUrl());
            this.ImageIndex = index;
            this.SelectedImageIndex = index;
        }


        public override string ImageUrl()
        {
            string path = this.Template.ImageUrl;
            path = path.Substring(path.LastIndexOf("/") + 1);
            path = SPMPaths.ImageDirectory + path;

            return path;
        }

    }
}
