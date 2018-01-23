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
    class ListNode : ExplorerNodeBase
    {

        public WebNode WebNode = null;

        public SPList List
        {
            get
            {
                return this.Tag as SPList;
            }
        }


        public override string BrowserUrl
        {
            get
            {

                return SPUtility.GetFullUrl(List.ParentWeb.Site, List.DefaultViewUrl);
            }
        }

        public ListNode(WebNode webNode, SPList list)
        {
            this.Tag = list;
            this.SPParent = list.ParentWeb;
            this.WebNode = webNode;

            this.Setup();

            this.Nodes.Add(new ExplorerNodeBase("Dummy"));
        }

        public override void Setup()
        {
            this.Text = List.Title + " ("+List.ItemCount+")";
            this.ToolTipText = List.Description;
            this.Name = List.ID.ToString();
            this.BrowserUrl = List.DefaultViewUrl;

            int index = Program.Window.Explorer.AddImage(this.ImageUrl());
            this.ImageIndex = index;
            this.SelectedImageIndex = index;

        }


        public override void LoadNodes()
        {
            base.LoadNodes();

            this.AddNode(NodeDisplayLevelType.Simple, new ListItemCollectionNode(this.List));
            this.AddNode(NodeDisplayLevelType.Medium, new ViewCollectionNode(this.List));
            this.AddNode(NodeDisplayLevelType.Medium, new ContentTypeCollectionNode(this.List, this.List.ContentTypes));
            this.AddNode(NodeDisplayLevelType.Medium, new FieldCollectionNode(this.List, this.List.Fields));
            this.AddNode(NodeDisplayLevelType.Medium, new WorkflowAssociationCollectionNode(this.List, this.List.WorkflowAssociations));
            this.AddNode(NodeDisplayLevelType.Advanced, new FormCollectionNode(this.List));

            this.AddNode(NodeDisplayLevelType.Advanced, new EventReceiverDefinitionCollectionNode(this.List, this.List.EventReceivers));
        }


        public override string ImageUrl()
        {
            string path = this.List.ImageUrl;
            path = path.Substring(path.LastIndexOf("/") + 1);
            path = SPMPaths.ImageDirectory + path;

            return path;
        }

        public override TabPage[] GetTabPages()
        {
            ArrayList alPages = new ArrayList();

            alPages.AddRange(base.GetTabPages());
            alPages.Add(TabPages.GetDataGridViewPage(SPMLocalization.GetString("GridView_List"), List.Items.GetDataTable()));

            return (TabPage[])alPages.ToArray(typeof(TabPage));

        }
    }
}
