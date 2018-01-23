using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint.WebPartPages;
using SPM2.Framework;

namespace SPM2.SharePoint.Model
{

    [AdapterItemType("Microsoft.SharePoint.WebPartPages.WebPart, Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c")]
    [ExportToNode("SPM2.SharePoint.Model.SPLimitedWebPartCollectionNode")]
    public class SPWebPartNode : SPNode
    {
        public WebPart ASPWebPart
        {
            get
            {
                return this.SPObject as WebPart;
            }
        }

        public SPLimitedWebPartManager WebPartManager
        {
            get { return (SPLimitedWebPartManager)this.Parent.SPObject; }
        }
        

        public bool IsSharePointWebPart
        {
            get
            {
                return this.ASPWebPart is WebPart;
            }
        }


        public override void Setup(ISPNode parent)
        {
            base.Setup(parent);

            string title = this.ASPWebPart.Title;
            if (title.Length == 0)
            {
                title = this.ASPWebPart.GetType().Name;
            }
            this.Text = title;

            this.ToolTipText = this.ASPWebPart.Description;

            this.IconUri = SharePointContext.TemplatePath + ASPWebPart.CatalogIconImageUrl;
        }


        public void GetXml()
        {
            string xml = string.Empty;

            //SPLimitedWebPartManager manager = (SPLimitedWebPartManager)this.Parent.Tag;
            //using (StringWriter writer = new StringWriter())
            //{
            //    XmlTextWriter xtw = new XmlTextWriter(writer);
            //    //this.ASPWebPart.ExportMode == WebPartExportMode.All;
            //    manager.ExportWebPart(this.ASPWebPart, xtw);
            //    xml = writer.ToString();
            //}
        }
    }
}
