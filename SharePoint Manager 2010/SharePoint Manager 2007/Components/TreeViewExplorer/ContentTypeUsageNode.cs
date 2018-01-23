using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;


using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    public class ContentTypeUsageNode : ExplorerNodeBase
    {
        private string _imageUrl = string.Empty;

        public SPContentTypeUsage ContentTypeUsage
        {
            get
            {
                return this.Tag as SPContentTypeUsage;
            }
        }

        private SPListItem _item = null;
        public SPListItem Item
        {
            get { return _item; }
            set { _item = value; }
        }



        public ContentTypeUsageNode(object parent, SPContentTypeUsage contentTypeUsage)
        {
            this.Tag = contentTypeUsage;
            this.SPParent = parent;

            //this.ContextMenuStrip = new SiteMenuStrip();

            Setup();
        }


        public ContentTypeUsageNode(object parent, SPContentTypeUsage contentTypeUsage, SPListItem item) 
        {
            this.Tag = contentTypeUsage;
            this.SPParent = parent;
            this.Item = item;

            //this.ContextMenuStrip = new SiteMenuStrip();

            Setup();
        }




        public override void Setup()
        {
            this.Text = ContentTypeUsage.Url;
            if (Item != null)
            {
                if (Item.File != null)
                {
                    SPFile file = Item.File;
                    this.Text += "/" + file.Name;
                    _imageUrl = SPMPaths.ImageDirectory + file.IconUrl;
                }
                else
                {
                    this.Text += "/" + Item.Title;
                    _imageUrl = SPMPaths.ImageDirectory + "TFALLT.GIF";
                }
            }

            //this.Text = ContentTypeUsage.Url;
            this.ToolTipText = ContentTypeUsage.Url;
            this.Name = ContentTypeUsage.Id.ToString();

            int index = Program.Window.Explorer.AddImage(this.ImageUrl());
            this.ImageIndex = index;
            this.SelectedImageIndex = index;

            //this.Nodes.Add(new ExplorerNodeBase("Dummy"));
        }

        public override void LoadNodes()
        {
            base.LoadNodes();

            //this.Nodes.Add(new FieldCollectionNode(this.ContentType, this.ContentType.Fields));
            //this.Nodes.Add(new WorkflowAssociationCollectionNode(this.ContentType, this.ContentType.WorkflowAssociations));
        }

        public override string ImageUrl()
        {
            if(String.IsNullOrEmpty(_imageUrl))
            {
                return base.ImageUrl();
            }
            else
            {
                return _imageUrl;
            }
        }

        //public override void CopyToClipboard()
        //{
        //    Clipboard.SetText(ContentType.SchemaXml);
        //}
    }
}
    