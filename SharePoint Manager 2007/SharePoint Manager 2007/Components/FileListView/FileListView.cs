using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Keutmann.SharePointManager.Library;
using Keutmann.SharePointManager.Components;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components.FileListView
{
    public partial class FileListView : UserControl
    {
        private LoadWorker loadWorker;
        private bool allChecked = false;
        //private SPMObjectType spmObjectType = SPMObjectType.Unknown;

        private bool isSPObjectSite = false;
        private bool includeSubSites = false;
        private bool includeSubFolders = false;

        private ExplorerNodeBase _selectedNode = null;
        public ExplorerNodeBase SelectedNode
        {
            get
            {
                return _selectedNode;
            }
            set
            {
                _selectedNode = value;
                UpdateListView();
            }
        }


        public FileListView()
        {
            InitializeComponent();
        }


        private void UpdateListView()
        {
            ItemView.Items.Clear();

            if (SelectedNode != null && SelectedNode.Tag != null)
            {

                Type spType = SelectedNode.Tag.GetType();

                if (spType.Name == SPMObjectType.SPWeb.ToString())
                {
                    isSPObjectSite = true;
                    MenuItemIncludeSubFiles.Text = SPMLocalization.GetString("Include_Sub_Sites");
                }
                else
                    if (spType.Name == SPMObjectType.SPDocumentLibrary.ToString() ||
                        spType.Name == SPMObjectType.SPFolder.ToString() ||
                        spType.Name == SPMObjectType.SPFile.ToString())
                    {
                        isSPObjectSite = false;
                        MenuItemIncludeSubFiles.Text = SPMLocalization.GetString("Include_Sub_Folders");
                    }
                    else
                    {
                        toolStripTop.Enabled = false;
                        ItemView.Enabled = false;
                        return;
                    }

                toolStripTop.Enabled = true;
                ItemView.Enabled = true;

            }
            else
            {
                toolStripTop.Enabled = false;
                ItemView.Enabled = false;
            }
        }



        private void toolStripUncheckAll_Click(object sender, EventArgs e)
        {
            allChecked = !allChecked;
          
            foreach (ListViewItem item in ItemView.Items)
            {
                item.Checked = allChecked;
            }
        }

        private void MenuItemIncludeSubFiles_Click(object sender, EventArgs e)
        {
            if (isSPObjectSite)
            {
                includeSubSites = true;
                includeSubFolders = true;
            }
            else
            {
                includeSubSites = false;
                includeSubFolders = true;
            }

            FindFiles();
        }


        private void MenuItemFindFiles_Click(object sender, EventArgs e)
        {
            if (isSPObjectSite)
            {
                includeSubSites = false;
                includeSubFolders = true;
            }
            else
            {
                includeSubSites = false;
                includeSubFolders = false;
            }
            FindFiles();
        }

        private void FindFiles()
        {
            //object spObject = ((ExplorerNodeBase)Program.Window.Explorer.SelectedNode).Tag;

            ItemView.Items.Clear();
            ItemView.BeginUpdate();

            Program.Window.toolStripStatusLabel.Text = "Start load";
            Program.Window.toolStripStatusLabel.Text = String.Empty;

            toolStripTop.Enabled = false;
            ItemView.Enabled = false;
            panelBottom.Visible = true;

            this.loadWorker = new LoadWorker();
            //this.loadWorker.Add += new LoadWorker.AddEvent(this.loadWorker_Add);
            this.loadWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            this.loadWorker.ProgressChanged += new ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.loadWorker.WorkerSupportsCancellation = true;

            
            LoadWorkerParameters param = new LoadWorkerParameters();

            param.Url = SelectedNode.BrowserUrl;
            param.spType = SelectedNode.Tag.GetType();
            param.IncludeSubSites = includeSubSites;
            param.IncludeSubFolders = includeSubFolders;

            this.loadWorker.RunWorkerAsync(param);
        }

        private void btnExit_Click(object sender, System.EventArgs e)
        {
        }

        private void Load_Finished(object sender, EventArgs e)
        {
            ResetCtls();
            Program.Window.toolStripStatusLabel.Text= SPMLocalization.GetString("Finished");
        }
        private void Load_Cancelled(object sender, EventArgs e)
        {
            ResetCtls();
            Program.Window.toolStripStatusLabel.Text = SPMLocalization.GetString("Cancelled");
        }
        private void Load_Failed(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            ResetCtls();
            Program.Window.toolStripStatusLabel.Text = string.Format("Error ({0}): {1}", e.Exception.GetType().ToString(), e.Exception.Message);
        }
        
        private void ResetCtls()
        {
            toolStripTop.Enabled = true;
            ItemView.Enabled = true;

            // Disable the Cancel button.
            panelBottom.Visible = false;

            Cursor = Cursors.Default;
            ItemView.EndUpdate();
        }


        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Program.Window.toolStripStatusLabel.Text = DateTime.Now.TimeOfDay.Seconds.ToString();
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // First, handle the case where an exception was thrown.
            if (e.Error != null)
            {
                throw new ApplicationException(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                Program.Window.toolStripStatusLabel.Text = SPMLocalization.GetString("Cancelled");
            }

            ListView threadView = (ListView)e.Result;
            ListViewItem[] tempList = new ListViewItem[threadView.Items.Count];
            threadView.Items.CopyTo(tempList, 0);
            threadView.Items.Clear();
            ItemView.Items.AddRange(tempList);

            ResetCtls();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Cancel the asynchronous operation.
            this.loadWorker.CancelAsync();

            ResetCtls();
        }


        //private void loadWorker_Add(ArrayList )
        //{
        //    ListViewItem viewItem = ItemView.Items.Add(item.File.Name);
        //    viewItem.SubItems.Add("..missing.."); // Mangler url

        //    if (item.File.CheckedOutBy != null)
        //    {
        //        viewItem.SubItems.Add(item.File.CheckedOutBy.Name);
        //    }
        //    else
        //    {
        //        viewItem.SubItems.Add("");
        //    }
        //}


//        protected void OnDoWork()
//        {

//            SPSite site = new SPSite(url);

//            AddItemsFromWeb(site.OpenWeb());
//            //_sharepointObject = e.Argument;

//            // Stop if cancellation was requested
//            //if (!e.Cancel)
//            //{
//                //if (_sharepointObject is SPWeb)
//                //{
//                //    AddItemsFromWeb((SPWeb)_sharepointObject);
//                //}
//                //else
//                //    if (_sharepointObject is SPDocumentLibrary)
//                //    {
//                //        AddItemsFromList((SPDocumentLibrary)_sharepointObject);
//                //    }
//            //}
//        }

//        private void AddItemsFromWeb(SPWeb web)
//        {
//            foreach (SPList list in web.Lists)
//            {
//                //if (this.CancellationPending)
//                //{
//                //    break;
//                //}
//                //else
//                //{
//                    if (list is SPDocumentLibrary)
//                    {
//                        AddItemsFromList((SPDocumentLibrary)list);
//                    }
////                }
//            }
//        }

//        private void AddItemsFromList(SPDocumentLibrary docLib)
//        {
//            //string url = docLib.RootFolder.Url;
//            foreach (SPListItem item in docLib.Items)
//            {
//                //ItemView.BeginInvoke(new AddEvent(loadWorker_Add), new object[] { item });
//                //loadWorker_Add(item);
//                //if (this.CancellationPending)
//                //{
//                //    break;
//                //}
//                //else
//                //{
//                    //OnAdd(item);
//                    //worker.ReportProgress(0);
////                }
//            }
//        }


    }
}
