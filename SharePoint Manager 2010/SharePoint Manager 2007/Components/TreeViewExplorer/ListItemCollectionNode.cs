using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    class ListItemCollectionNode : ExplorerNodeBase
    {
        public SPList List
        {
            get
            {
                return this.SPParent as SPList;
            }
        }

        public ListItemCollectionNode(SPList list)
        {
            this.Tag = list.Items;
            this.SPParent = list;
            
            this.Setup();

            this.Nodes.Add(new ExplorerNodeBase("Dummy"));
        }


        public override void Setup()
        {
            this.Text = SPMLocalization.GetString("Items_Text");
            this.ToolTipText = SPMLocalization.GetString("Items_ToolTip");
            this.Name = "Items";
            //this.BrowserUrl = this.List.ParentWebUrl + "_layouts/viewlsts.aspx";

            int index = Program.Window.Explorer.AddImage(this.ImageUrl());
            this.ImageIndex = index;
            this.SelectedImageIndex = index;
        }

        public override void LoadNodes()
        {
            base.LoadNodes();

            if (List is SPDocumentLibrary)
            {
                foreach (SPListItem item in List.Items)
                {
                    this.AddNode(NodeDisplayLevelType.Simple, new FileNode(item.File));
                }
            }
            else
            {

                foreach (SPListItem item in List.Items)
                {
                    this.AddNode(NodeDisplayLevelType.Simple, new ListItemNode(item));
                }
            }

            TreeViewExplorer exp = this.TreeView as TreeViewExplorer;

            foreach (SPFolder folder in List.RootFolder.SubFolders)
            {
                if (exp.DisplayLevel != NodeDisplayLevelType.Simple || folder.Name != "Forms")
                {
                    this.AddNode(NodeDisplayLevelType.Simple, new FolderNode(folder));
                }
            }
        }


        public override string ImageUrl()
        {
            return SPMPaths.ImageDirectory + "list.gif";
        }
        
    }
}
