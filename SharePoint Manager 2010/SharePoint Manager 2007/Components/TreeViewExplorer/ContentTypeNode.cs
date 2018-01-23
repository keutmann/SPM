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
    class ContentTypeNode : ExplorerNodeBase
    {
        public SPContentType ContentType
        {
            get
            {
                return this.Tag as SPContentType;
            }
        }

 
        public ContentTypeNode(SPContentType contentType)
        {
            this.Tag = contentType;
            try
            {
                this.SPParent = contentType.Parent;
            }
            catch 
            {
                // Do nothing
            }

            //this.ContextMenuStrip = new SiteMenuStrip();

            Setup();
        }

        public override void Setup()
        {
            if (ContentType != null)
            {
                if (ContentType.Hidden)
                {
                    this.Text = ContentType.Name + " (Hidden)";
                    this.ForeColor = Color.DarkGray;
                }
                else
                {
                    this.Text = ContentType.Name;
                }

                this.ToolTipText = ContentType.Description;
                this.Name = ContentType.Id.ToString();

                int index = Program.Window.Explorer.AddImage(this.ImageUrl());
                this.ImageIndex = index;
                this.SelectedImageIndex = index;

                this.Nodes.Add(new ExplorerNodeBase("Dummy"));
            }
            else
            {
                Remove();
            }
        }

        public override void LoadNodes()
        {
            base.LoadNodes();

            this.Nodes.Add(new FieldCollectionNode(this.ContentType, this.ContentType.Fields));
            this.Nodes.Add(new WorkflowAssociationCollectionNode(this.ContentType, this.ContentType.WorkflowAssociations));
            this.Nodes.Add(new ContentTypeUsageCollectionNode(this.ContentType, SPContentTypeUsage.GetUsages(this.ContentType)));
        }

        public override string ImageUrl()
        {
            return SPMPaths.ImageDirectory + "MARR.GIF";
        }

        public override void CopyToClipboard()
        {
            Clipboard.SetText(ContentType.SchemaXml);
        }
    }
}
    