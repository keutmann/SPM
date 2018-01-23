using System;
using System.Windows.Forms;
using System.Collections;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    class ListItemNode : ExplorerNodeBase
    {
        public bool ShowVersions = true;
        public string CustomName = string.Empty;

        public SPListItem Item
        {
            get
            {
                return this.Tag as SPListItem;
            }
        }

       
        public ListItemNode(SPListItem item) : this(item, item.DisplayName)
        {
        }

        public ListItemNode(SPListItem item, string name) : this(item, name, true)
        {
        }

        public ListItemNode(SPListItem item, bool showVersions) : this(item, item.DisplayName, showVersions)
        {
        }

        public ListItemNode(SPListItem item, string name, bool showVersions)
        {
            this.CustomName = name;
            this.Tag = item;
            this.SPParent = item.ParentList;
            this.ShowVersions = showVersions;

            this.Setup();

            this.Nodes.Add(new ExplorerNodeBase("Dummy"));
        }

        public override void Setup()
        {
            this.Text = this.CustomName;
            this.ToolTipText = Item.Url;
            this.Name = Item.Url;
            //this.BrowserUrl = Item.Url;
            //Item.ParentList.BaseTemplate

            int index = Program.Window.Explorer.AddImage(this.ImageUrl());
            this.ImageIndex = index;
            this.SelectedImageIndex = index;

        }



        public override void LoadNodes()
        {
            base.LoadNodes();

            this.AddNode(NodeDisplayLevelType.Medium, new ContentTypeNode(this.Item.ContentType));
            this.AddNode(NodeDisplayLevelType.Medium, new PropertyCollectionNode(this.Tag, Item.Properties));

            SPList list = this.SPParent as SPList;

            if (this.ShowVersions)
            {
                if (list.EnableVersioning || Item.Versions.Count > 1)
                {
                    this.AddNode(NodeDisplayLevelType.Medium, new ListItemVersionCollectionNode(this.Item));
                }
            }

            this.AddNode(NodeDisplayLevelType.Medium, new WorkflowCollectionNode(this.Item, this.Item.Workflows));
            //this.Nodes.Add(new FieldCollectionNode(this.Item, this.Item.Fields));

        }

        public override string ImageUrl()
        {
            return SPMPaths.ImageDirectory + "TFALLT.GIF";
        }

        public override TabPage[] GetTabPages()
        {
            ArrayList alPages = new ArrayList();

            alPages.AddRange(base.GetTabPages());
            
            TabXmlPage xmlPage = TabPages.GetXmlPage("Xml", this.Item.Xml);
            xmlPage.Text = xmlPage.Text.Replace("ows_", "\r\nows_");
            alPages.Add(xmlPage);

            return (TabPage[])alPages.ToArray(typeof(TabPage));
        }
    }
}
