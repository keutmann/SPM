using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    class ContentTypeCollectionNode : ExplorerNodeBase
    {
        public SPContentTypeCollection ContentTypes
        {
            get
            {
                return this.Tag as SPContentTypeCollection;
            }
        }

        public ContentTypeCollectionNode(Object parent, SPContentTypeCollection collection)
        {
            this.Text = SPMLocalization.GetString("ContentTypes_Text");
            this.ToolTipText = SPMLocalization.GetString("ContentTypes_ToolTip");
            this.Name = "ContentType Collection";
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

            foreach (SPContentType type in this.ContentTypes)
            {
                this.Nodes.Add(new ContentTypeNode(type));
            }

        }

        public override string ImageUrl()
        {
            return SPMPaths.ImageDirectory + "ICSMRTPG.GIF";
        }

        //public override void PasteFromClipboard()
        //{
        //    string xml = Clipboard.GetText();

        //    XmlDocument doc = new XmlDocument();
        //    doc.LoadXml(xml);

        //    XmlElement root = doc.DocumentElement;
        //    root.Attributes.RemoveNamedItem("ID");
        //    root.Attributes.RemoveNamedItem("SourceID");

        //    xml = root.OuterXml;

        //    SPConte
        //    SPContentType contentType = new SPContentType(
        //     .AddFieldAsXml(xml);            
        //}

    }
}
