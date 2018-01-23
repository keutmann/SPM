using System;
using System.IO;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using System.Windows.Forms;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Deployment;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager;
using Keutmann.SharePointManager.Forms;
using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    public partial class SiteMenuStrip : ContextMenuStripBase
    {
        private ToolStripMenuItem TasksMenuItem;
        private ToolStripMenuItem BackupMenuItem;

        public SiteMenuStrip()
        {
            Init();
        }

        public SiteMenuStrip(IContainer container)
        {
            container.Add(this);

            Init();
        }

        private void Init()
        {
            // 
            // RestoreMenuItem
            // 
            this.BackupMenuItem = new ToolStripMenuItem();
            this.BackupMenuItem.Name = "BackupMenuItem";
            //this.RestoreMenuItem.Size = new System.Drawing.Size(125, 22);
            this.BackupMenuItem.Text = SPMLocalization.GetString("BackupSite_Text");
            this.BackupMenuItem.Click += new EventHandler(BackupMenuItem_Click);
            //
            // Tasks MenuStrip
            //
            TasksMenuItem = SPMMenu.Items.CreateTasks();
            TasksMenuItem.DropDownItems.AddRange(
                new ToolStripItem[] {
                    this.BackupMenuItem,
                });
            
            //this.TasksMenuItem,
            //SPMMenu.Items.CreateSeparator(),
            // 
            // SiteCollectionMenuStrip
            // 
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.TasksMenuItem,
            SPMMenu.Items.CreateRefresh()
            });
            this.Name = "SiteMenuStrip";
            this.Size = new System.Drawing.Size(126, 52);

        }

        private void BackupMenuItem_Click(object sender, EventArgs e)
        {
            //SaveFileDialog fileDialog = new SaveFileDialog();

            //DialogResult result = fileDialog.ShowDialog();
            //if (result == DialogResult.OK)
            //{
                Cursor.Current = Cursors.WaitCursor;

                SPSite site = CurrentNode.Tag as SPSite;
                SPSiteCollection collection = CurrentNode.SPParent as SPSiteCollection;

                string siteurl = site.Url;

                SPExportSettings exportSettings = new SPExportSettings();
                exportSettings.SiteUrl = site.Url;
                Guid id = new Guid("d151035f-a876-4d34-8f58-7b6cfdd3ace3");
                SPExportObject edf = new SPExportObject();
                edf.Id = id;
                edf.IncludeDescendants = SPIncludeDescendants.All;
                edf.Type = SPDeploymentObjectType.File;
                edf.ExcludeChildren = false;
                
                //exportSettings.ExportMethod = SPExportMethodType.ExportAll;

                exportSettings.BaseFileName = "MyFile";
                exportSettings.FileLocation = @"c:\test\";
                exportSettings.FileCompression = true;
                exportSettings.ExportObjects.Add(edf);

                SPExport export = new SPExport(exportSettings);
                export.Run();


                SPImportSettings importSettings = new SPImportSettings();
                importSettings.SiteUrl = siteurl;
                importSettings.BaseFileName = "MyFile";
                importSettings.FileLocation = @"c:\test\";
                importSettings.FileCompression = true;
                importSettings.WebUrl = siteurl+"/PublishingImages/";

                //SPImportObject imp = new SPImportObject();
                //imp.Type = SPDeploymentObjectType.File;
                //imp.

                SPImport import = new SPImport();
                import.Run();


                //collection.Backup(site.Url, fileDialog.FileName, true);

                Cursor.Current = Cursors.Default;
//            }
        }

 
    }
}
