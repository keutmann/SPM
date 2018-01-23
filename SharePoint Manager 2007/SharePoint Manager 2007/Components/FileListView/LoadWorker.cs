using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;

using Microsoft.SharePoint;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components.FileListView
{
    public class LoadWorker : BackgroundWorker
    {
        private LoadWorkerParameters Param = null;
        private ListView itemView = new ListView();

        private SPSite site = null;
        private SPWeb web = null;



        public LoadWorker() : base()
        {
        }


        protected override void OnDoWork(DoWorkEventArgs e)
        {
            base.OnDoWork(e);

            try
            {
                Param = (LoadWorkerParameters)e.Argument;

                // Stop if cancellation was requested
                if (!e.Cancel)
                {
                    site = new SPSite(Param.Url);
                    web = site.OpenWeb();

                    object spObj = web.GetFileOrFolderObject(Param.Url);

                    SPMObjectType objType = SPMUtility.IdentifyObject(spObj);

                    switch (objType)
                    {
                        case SPMObjectType.SPWeb: AddItemsFromWeb(web); break;
                        case SPMObjectType.SPDocumentLibrary:
                            SPDocumentLibrary docLib = web.Lists[((SPFolder)spObj).ContainingDocumentLibrary] as SPDocumentLibrary;
                            AddItemsFromDocLib(docLib); 
                            break;
                        case SPMObjectType.SPFolder: AddItemsFromFolder((SPFolder)spObj); break;
                        case SPMObjectType.SPFile: AddItemsFromFile((SPFile)spObj); break;
                    }
                    e.Result = itemView;
                }
            }
            finally
            {
                if (web != null)
                    web.Dispose();
                if (site != null)
                    site.Dispose();
            }
        }

        private void AddItemsFromWeb(SPWeb web)
        {
            foreach (SPList list in web.Lists)
            {
                
                if (this.CancellationPending)
                {
                    break;
                }
                else
                {
                    if (list is SPDocumentLibrary)
                    {
                        AddItemsFromDocLib((SPDocumentLibrary)list);
                    }
                }
            }

            if (Param.IncludeSubSites && !this.CancellationPending)
            {
                foreach (SPWeb subweb in web.Webs)
                {
                    if (this.CancellationPending)
                    {
                        break;
                    }
                    else
                    {
                        AddItemsFromWeb(subweb);
                    }
                }
            }
        }

        private void AddItemsFromDocLib(SPDocumentLibrary docLib)
        {
            if (Param.IncludeSubFolders)
            {
                AddItemsFromList(docLib.Items);
            }
            else
            {
                SPQuery q = new SPQuery();
                q.Folder = docLib.RootFolder;
                
                AddItemsFromList(docLib.GetItems(q));
            }
        }

        private void AddItemsFromList(SPListItemCollection itemCollection)
        {
            foreach (SPListItem item in itemCollection)
            {
                if (this.CancellationPending)
                {
                    break;
                }
                else
                {
                    AddItem(item);
                }
            }
        }


        private void AddItemsFromFolder(SPFolder folder)
        {
            foreach (SPFile file in folder.Files)
            {
                if (this.CancellationPending)
                {
                    break;
                }
                else
                {
                    AddItem(file.Item);
                }
            }

            if (Param.IncludeSubFolders && !this.CancellationPending)
            {
                foreach (SPFolder subfolder in folder.SubFolders)
                {
                    if (this.CancellationPending)
                    {
                        break;
                    }
                    else
                    {
                        AddItemsFromFolder(subfolder);
                    }
                }
            }
        }

        private void AddItemsFromFile(SPFile file)
        {
            if (file.Item != null && file.Item.Folder != null)
            {
                AddItemsFromFolder(file.Item.Folder);
            }
        }

        private void AddItem(SPListItem item)
        {
            SPFile file = item.File;
            if (file != null)
            {
                //file = web.GetFile(item.Url);

                ListViewItem viewItem = itemView.Items.Add(file.Name);

                viewItem.SubItems.Add(file.ServerRelativeUrl);

                if (item.File.CheckedOutBy != null)
                {
                    viewItem.SubItems.Add(file.CheckedOutBy.Name);
                }
                else
                {
                    viewItem.SubItems.Add("");
                }

                this.OnProgressChanged(new ProgressChangedEventArgs(0, null));
            }
        }
    }
}
