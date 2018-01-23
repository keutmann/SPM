using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;
using System.Globalization;

namespace Keutmann.SharePointManager.Components
{
    class FileNode : ExplorerNodeBase
    {
        public bool ShowVersions = true;

        public override ContextMenuStrip ContextMenuStrip
        {
            get
            {
                if (base.ContextMenuStrip == MenuStripBase)
                {
                    MenuStripStandard menu = new MenuStripStandard();
                    menu.Insert(0, SPMLocalization.GetString("Download"), null, new EventHandler(DownloadMenuItem_Click));
                    menu.Insert(1, new ToolStripSeparator());
                    menu.Insert(2, SPMLocalization.GetString("Recycle"), null, new EventHandler(RecycleMenuItem_Click));
                    menu.Insert(3, new ToolStripSeparator());

                    base.ContextMenuStrip = menu;
                }
                return base.ContextMenuStrip;
            }
            set
            {
                base.ContextMenuStrip = value;
            }
        }


        public SPFile File
        {
            get
            {
                return this.Tag as SPFile;
            }
        }

        public FileNode(SPFile file)
            : this(file, true)
        {
        }




        public FileNode(SPFile file, bool showVersions)
        {
            this.Tag = file;
            this.ShowVersions = showVersions;

            int index = Program.Window.Explorer.AddImage(this.ImageUrl());
            this.ImageIndex = index;
            this.SelectedImageIndex = index;

            this.Setup();

            this.Nodes.Add(new ExplorerNodeBase("Dummy"));

            try
            {
                if (file.Item != null)
                {
                    this.SPParent = file.Item.ParentList;
                }
            }
            catch
            {
                // Do nothing
                // sometimes the file.Item throws an exception
            }


        }

        public override void Setup()
        {
            this.Text = File.Name;

            this.ToolTipText = File.Url;
            this.Name = File.Url;

            if (this.Name.EndsWith(".aspx", true, CultureInfo.InvariantCulture))
            {

                this.BrowserUrl = SPUrlUtility.CombineUrl(File.ParentFolder.ParentWeb.Url, File.Url);
            }
        }



        public override void LoadNodes()
        {
            base.LoadNodes();

            SPFile file = this.Tag as SPFile;

            try
            {
                if (file.Item != null)
                {
                    this.AddNode(NodeDisplayLevelType.Simple, new ListItemNode(file.Item, SPMLocalization.GetString("File_Item"), this.ShowVersions));
                }
            }
            catch
            {
                // Do nothing
                // sometimes the file.Item throws an exception
            }            

            this.AddNode(NodeDisplayLevelType.Medium, new PropertyCollectionNode(file, file.Properties));

            TreeViewExplorer exp = this.TreeView as TreeViewExplorer;
            if (((int)exp.DisplayLevel & (int)NodeDisplayLevelType.Advanced) >= 1)
            {
                if (file.Name.EndsWith(".aspx", true, System.Globalization.CultureInfo.InvariantCulture))
                {
                    try
                    {
                        this.Nodes.Add(new WebPartCollectionNode(file, file.GetLimitedWebPartManager(System.Web.UI.WebControls.WebParts.PersonalizationScope.Shared)));
                    }
                    catch
                    {
                        // Do nothing
                    }
                }
            }

            if (this.SPParent != null && this.ShowVersions)
            {
                SPList list = this.SPParent as SPList;

                if (list.EnableVersioning || File.Versions.Count > 1)
                {
                    this.AddNode(NodeDisplayLevelType.Medium, new FileVersionCollectionNode(this.File));
                }
            }

            this.AddNode(NodeDisplayLevelType.Advanced, new EventReceiverDefinitionCollectionNode(this.File, this.File.EventReceivers));
        }

        public override string ImageUrl()
        {
            string path = SPMPaths.ImageDirectory + this.File.IconUrl;
            return path;
        }


        public override void Delete()
        {
            File.Delete();
        }

        void RecycleMenuItem_Click(object sender, EventArgs e)
        {
            File.Recycle();
        }

        private void CopyStream(Stream input, Stream output)
        {
            byte[] bytes = new byte[4096];

            int i;
            while ((i = input.Read(bytes, 0, bytes.Length)) != 0)
            {
                output.Write(bytes, 0, i);
            }
        }


        void DownloadMenuItem_Click(object sender, EventArgs e)
        {
            Stream saveStream = null;
            Stream spFileStream = null;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.FileName = File.Name;
                DialogResult result = saveDialog.ShowDialog();
                if (result == DialogResult.OK)
                {

                    saveStream = saveDialog.OpenFile();
                    if (saveStream != null)
                    {
                        spFileStream = File.OpenBinaryStream(); ;
                        spFileStream.Position = 0;

                        CopyStream(spFileStream, saveStream);
                    }
                }
            }
            finally
            {
                if (saveStream != null)
                {
                    saveStream.Close();
                }
                if (spFileStream != null)
                {
                    spFileStream.Close();
                }

                Cursor.Current = Cursors.Default;
            }

        }

    }
}
