using System;
using System.Collections;
using System.Windows.Forms;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    class FolderNode : ExplorerNodeBase
    {
        public SPFolder Folder
        {
            get
            {
                return this.Tag as SPFolder;
            }
        }


        public FolderNode(SPFolder folder)
        {
            this.Tag = folder;
            if (folder.ParentListId != Guid.Empty)
            {
                this.SPParent = folder.ParentWeb.Lists[folder.ParentListId];
            }

            this.Setup();

            this.Nodes.Add(new ExplorerNodeBase("Dummy"));
        }

        public override void Setup()
        {
            this.Text = (String.IsNullOrEmpty(Folder.Name)) ? "RootFolder" : Folder.Name;

            this.ToolTipText = Folder.Url;
            this.Name = Folder.UniqueId.ToString();

            int index = Program.Window.Explorer.AddImage(this.ImageUrl());
            this.ImageIndex = index;
            this.SelectedImageIndex = index;

        }

        public override void LoadNodes()
        {
            base.LoadNodes();

            SPFolder folder = this.Tag as SPFolder;
            
            //SPList list = this.SPParent as SPList;

            
            //if (list is SPDocumentLibrary)
            //{
            //    foreach (SPListItem item in list.Items)
            //    {
            //        this.Nodes.Add(new FileNode(item.File));
            //    }
            //}
            //else
            //{
            //    foreach (SPListItem item in list.Items)
            //    {
            //        this.Nodes.Add(new ListItemNode(item));
            //    }
            //}

            try
            {
                if (folder.Item != null)
                {
                    this.AddNode(NodeDisplayLevelType.Advanced, new ListItemNode(folder.Item, SPMLocalization.GetString("File_Item"), true));
                }
            }
            catch 
            {
                // Do nothing                
            }


            foreach (SPFile file in folder.Files)
            {
                this.AddNode(NodeDisplayLevelType.Simple, new FileNode(file));
            }

            foreach (SPFolder childFolder in folder.SubFolders)
            {
                this.AddNode(NodeDisplayLevelType.Simple, new FolderNode(childFolder));
            }

            this.AddNode(NodeDisplayLevelType.Medium, new PropertyCollectionNode(folder, folder.Properties));
        }

        public override string ImageUrl()
        {
            return SPMPaths.ImageDirectory + "folder.gif";
        }

        //public override TabPage[] GetTabPages()
        //{
        //    ArrayList alPages = new ArrayList();

        //    alPages.AddRange(base.GetTabPages());

        //    return (TabPage[])alPages.ToArray(typeof(TabPage));
            
        //}


    }
}
