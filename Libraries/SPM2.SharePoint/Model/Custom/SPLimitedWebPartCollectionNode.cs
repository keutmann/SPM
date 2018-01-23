using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.SharePoint.WebPartPages;

using SPM2.Framework;
using Microsoft.SharePoint;
using System.Xml.Serialization;

namespace SPM2.SharePoint.Model
{
    [AdapterItemType("Microsoft.SharePoint.WebPartPages.SPLimitedWebPartCollection, Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c")]
    //[ExportToNode("SPM2.SharePoint.Model.SPFormNode")]
    public class SPLimitedWebPartCollectionNode : SPNodeCollection
    {
        public SPFile File { get; set; }
        public SPWeb Web { get; set; }
        public string PageUrl { get; set; }

        [XmlIgnore]
        public SPLimitedWebPartCollection WebParts
        {
            get
            {
                return (SPLimitedWebPartCollection)this.SPObject;
            }
            set
            {
                this.SPObject = value;
            }
        }

        private SPLimitedWebPartManager _manager = null;
        [XmlIgnore]
        public SPLimitedWebPartManager Manager
        {
            get
            {
                if (_manager == null)
                {
                    if (this.File != null)
                    {
                        _manager = this.File.GetLimitedWebPartManager(System.Web.UI.WebControls.WebParts.PersonalizationScope.Shared);
                    }
                    else
                    {
                        _manager = this.Web.GetLimitedWebPartManager(this.PageUrl, System.Web.UI.WebControls.WebParts.PersonalizationScope.Shared);
                    }
                }
                return _manager;
            }
            set
            {
                _manager = value;
            }
        }


        public SPLimitedWebPartCollectionNode(SPFile file)
        {
            this.File = file;
        }

        public SPLimitedWebPartCollectionNode(SPWeb web, string pageUrl)
        {
            this.Web = web;
            this.PageUrl = pageUrl;
        }


        public override void Setup(ISPNode parent)
        {
            base.Setup(parent);
            this.Text = "WebParts";
            this.IconUri = SharePointContext.GetImagePath("itgen.GIF");
        }

        public override object GetSPObject()
        {
            return this.Manager.WebParts;
        }

        public override void LoadChildren()
        {
            foreach (System.Web.UI.WebControls.WebParts.WebPart webpart in this.WebParts)
            {
                SPWebPartNode node = new SPWebPartNode();
                node.SPObject = webpart;
                node.Setup(this);
                this.Children.Add(node);
            } 
        }
    }
}
