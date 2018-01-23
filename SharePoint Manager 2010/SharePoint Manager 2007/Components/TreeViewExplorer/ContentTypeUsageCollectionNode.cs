using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    class ContentTypeUsageCollectionNode : ExplorerNodeBase
    {
        public IList<SPContentTypeUsage> ContentTypeUsages
        {
            get
            {
                return this.Tag as IList<SPContentTypeUsage>;
            }
        }

        public ContentTypeUsageCollectionNode(SPContentType parent, IList<SPContentTypeUsage> collection)
        {
            this.Text = SPMLocalization.GetString("ContentTypeUsages_Text");
            this.ToolTipText = SPMLocalization.GetString("ContentTypeUsages_ToolTip");
            this.Name = "ContentTypeUsages Collection";
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

            Dictionary<Guid, SPListItem> usedItems = new Dictionary<Guid, SPListItem>();
            
            SPContentType parentCT = (SPContentType)this.SPParent;

            foreach (SPContentTypeUsage usage in this.ContentTypeUsages)
            {
                //if (usage.IsUrlToList)
                //{
                //    //int index = usage.Url.IndexOf("Pages", StringComparison.InvariantCultureIgnoreCase);
                //    //string url = (index > 0) ? usage.Url.Substring(0, index) : usage.Url;
                //    //using (SPWeb currentWeb = parentCT.ParentWeb.Site.OpenWeb(url))
                //    //{
                //    //    if (currentWeb.Exists)
                //    //    {
                //    //        string relativeUrl = usage.Url.Substring(currentWeb.ServerRelativeUrl.Length+1);
                //    //        SPFolder folder = currentWeb.GetFolder(relativeUrl);

                //    //        //SPList list = parentCT.ParentWeb.GetListFromUrl(usage.Url);
                //    //        bool found = false;

                //    //        foreach (SPFile file in folder.Files)
                //    //        {
                //    //            SPListItem item = file.Item;
                //    //            if (item != null)
                //    //            {
                //    //                if (parentCT.Name.Equals(item.ContentType.Name, StringComparison.InvariantCultureIgnoreCase))
                //    //                {
                //    //                    if (!usedItems.ContainsKey(item.UniqueId))
                //    //                    {
                //    //                        usedItems.Add(item.UniqueId, item);
                //    //                        this.Nodes.Add(new ContentTypeUsageNode(this.SPParent, usage, item));
                //    //                        found = true;
                //    //                    }
                //    //                }
                //    //            }
                //    //        }

                //    //        if(!found)
                //    //        {
                //    //            this.Nodes.Add(new ContentTypeUsageNode(this.SPParent, usage));
                //    //        }
                //    //    }
                //    //}
                //}
                //else
                //{
                    this.Nodes.Add(new ContentTypeUsageNode(this.SPParent, usage));
                //}
            }

        }

        //public override string ImageUrl()
        //{
        //    return SPMPaths.ImageDirectory + "ICSMRTPG.GIF";
        //}

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
