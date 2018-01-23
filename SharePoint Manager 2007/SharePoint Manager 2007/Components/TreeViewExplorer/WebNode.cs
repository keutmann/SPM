using System;
using System.Xml;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.Web.UI;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    public class WebNode : ExplorerNodeBase
    {
        private string _publishingName = null;

        public string PublishingName
        {
            get
            {
                if (_publishingName == null)
                {
                    _publishingName = this.Web.RootFolder.WelcomePage;
                    int index = _publishingName.IndexOf("/");
                    if (index > 0)
                    {
                        _publishingName = _publishingName.Substring(0, index);
                    }
                }
                return _publishingName;
            }
        }

        public SPWeb Web = null;

        public WebNode(SPWeb web)
        {
            this.SPParent = web.Site;
            this.Tag = web;
            this.Web = web;

            this.Setup();

            this.Nodes.Add(new ExplorerNodeBase("Dummy"));
        }

        public override void Setup()
        {
            this.Text = Web.Title;
            this.ToolTipText = Web.Description;
            this.Name = Web.ID.ToString();
            this.BrowserUrl = Web.Url;

            int index = Program.Window.Explorer.AddImage(this.ImageUrl());
            this.ImageIndex = index;
            this.SelectedImageIndex = index;
        }


        public override void LoadNodes()
        {
            base.LoadNodes();

            SPWeb web = this.Tag as SPWeb;

            this.AddNode(NodeDisplayLevelType.Simple, new WebCollectionNode(web));
            this.AddNode(NodeDisplayLevelType.Simple, new ListCollectionNode(this, web));
            this.AddNode(NodeDisplayLevelType.Advanced, new ListTemplateCollectionNode(this, web));
            this.AddNode(NodeDisplayLevelType.Medium, new FeatureCollectionNode(web));
            this.AddNode(NodeDisplayLevelType.Advanced, new PropertyCollectionNode(web, web.AllProperties));
            this.AddNode(NodeDisplayLevelType.Medium, new RecycleBinItemCollectionNode(web, web.RecycleBin));
            this.AddNode(NodeDisplayLevelType.Medium, new ContentTypeCollectionNode(this.Web, this.Web.ContentTypes));
            this.AddNode(NodeDisplayLevelType.Medium, new FieldCollectionNode(this.Web, this.Web.Fields));
            this.AddNode(NodeDisplayLevelType.Medium, new AlertCollectionNode(this.Web, this.Web.Alerts));
            this.AddNode(NodeDisplayLevelType.Medium, new UserCollectionNode(this.Tag, this.Web.Users));

            this.AddNode(NodeDisplayLevelType.Advanced, new FolderNode(web.RootFolder));
            this.AddNode(NodeDisplayLevelType.Advanced, new PropertyBagCollection(web, web.Properties));

            this.AddNode(NodeDisplayLevelType.Advanced, new EventReceiverDefinitionCollectionNode(web, web.EventReceivers));
        }


        public override string ImageUrl()
        {
            string path = null;
            if (PublishingName.Length > 0)
            {
                path = SPMPaths.ImageDirectory + "CAT.GIF"; 
            }
            else
            {
                Pair obj = SPUtility.MapWebToIcon(this.Web);
                path = SPMPaths.ImageDirectory + (string)obj.First;
            }
            return path;
        }

    }
}
