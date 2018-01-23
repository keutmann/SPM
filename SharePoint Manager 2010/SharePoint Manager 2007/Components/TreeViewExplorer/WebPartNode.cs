using System;
using System.Web.UI.WebControls.WebParts;

using Microsoft.SharePoint;

using Keutmann.SharePointManager.Library;
using System.Collections;
using System.Windows.Forms;
using Microsoft.SharePoint.WebPartPages;
using System.IO;
using System.Xml;

namespace Keutmann.SharePointManager.Components
{
    class WebPartNode : ExplorerNodeBase
    {

        public System.Web.UI.WebControls.WebParts.WebPart ASPWebPart
        {
            get
            {
                return this.Tag as System.Web.UI.WebControls.WebParts.WebPart;
            }
        }

        public bool IsSharePointWebPart
        {
            get
            {
                return this.ASPWebPart is Microsoft.SharePoint.WebPartPages.WebPart;
            }
        }


        public WebPartNode(object spParent, System.Web.UI.WebControls.WebParts.WebPart webpart)
        {
            this.Tag = webpart;
            this.SPParent = spParent;

            int index = Program.Window.Explorer.AddImage(this.ImageUrl());
            this.ImageIndex = index;
            this.SelectedImageIndex = index;

            this.Setup();

        }

        public override void Setup()
        {

            string title = this.ASPWebPart.Title;
            if (title.Length == 0)
            {
                title = this.ASPWebPart.GetType().Name;
            }
            this.Text = title;

            this.ToolTipText = this.ASPWebPart.Description;
            this.Name = this.ASPWebPart.ID.ToString();
        }


        public override void LoadNodes()
        {
            
            base.LoadNodes();
        }

        public override string ImageUrl()
        {
            return SPMPaths.TemplateDirectory + ASPWebPart.CatalogIconImageUrl;
        }


        public override TabPage[] GetTabPages()
        {
            ArrayList alPages = new ArrayList();

            alPages.AddRange(base.GetTabPages());

            
            if(this.Parent.Tag != null)
            {
                string xml = string.Empty;

                SPLimitedWebPartManager manager = (SPLimitedWebPartManager)this.Parent.Tag;
                using (StringWriter writer = new StringWriter())
                {
                    XmlTextWriter xtw = new XmlTextWriter(writer);
                    //this.ASPWebPart.ExportMode == WebPartExportMode.All;
                    manager.ExportWebPart(this.ASPWebPart, xtw);
                    xml = writer.ToString();
                }
                TabXmlPage xmlPage = TabPages.GetXmlPage("Xml", xml);
                alPages.Add(xmlPage);
            }

            return (TabPage[])alPages.ToArray(typeof(TabPage));
        }

        // TODO Fix that normal Update function do not work with webparts. Create a override function for this.
        // However on the ListViewWebPart, not all properties can be saved.
    }
}
