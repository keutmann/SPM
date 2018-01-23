using System;
using System.IO;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using System.Windows.Forms;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager;
using Keutmann.SharePointManager.Forms;

namespace Keutmann.SharePointManager.Components
{
    public partial class SiteCollectionMenuStrip : ContextMenuStripBase
    {
        private ToolStripMenuItem TasksMenuItem;
        private ToolStripMenuItem RestoreMenuItem;

        public SiteCollectionMenuStrip()
        {
            Init();
        }

        public SiteCollectionMenuStrip(IContainer container)
        {
            container.Add(this);

            Init();
        }

        private void Init()
        {
            // 
            // RestoreMenuItem
            // 
            this.RestoreMenuItem = new ToolStripMenuItem();
            this.RestoreMenuItem.Name = "RestoreMenuItem";
            //this.RestoreMenuItem.Size = new System.Drawing.Size(125, 22);
            this.RestoreMenuItem.Text = "Restore site";
            this.RestoreMenuItem.Click += new EventHandler(RestoreMenuItem_Click);
            //
            // Tasks MenuStrip
            //
            TasksMenuItem = SPMMenu.Items.CreateTasks();
            TasksMenuItem.DropDownItems.AddRange(
                new ToolStripItem[] {
                    this.RestoreMenuItem,
                });
            
            // 
            // SiteCollectionMenuStrip
            // 
            //this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            //this.TasksMenuItem,
            //SPMMenu.Items.CreateSeparator(),
            //SPMMenu.Items.CreateRefresh()

            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            SPMMenu.Items.CreateRefresh()
            });
            this.Name = "SiteCollectionMenuStrip";
            this.Size = new System.Drawing.Size(126, 52);

        }

        private void RestoreMenuItem_Click(object sender, EventArgs e)
        {
            RestoreForm restoreForm = new RestoreForm();

            DialogResult result = restoreForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                SPSiteCollection collection = CurrentNode.Tag as SPSiteCollection;

                Cursor.Current = Cursors.WaitCursor;

                collection.Restore(
                    restoreForm.tbSiteName.Text,
                    restoreForm.tbFilename.Text,
                    restoreForm.cbOverride.Checked,
                    restoreForm.cbHostHeader.Checked);

                Cursor.Current = Cursors.Default;
            }
        }


        /*private void Export_Click(object sender, EventArgs e)
        {
            SPExportSettings exportSettings = new SPExportSettings();
            exportSettings.SiteUrl =
"http://PortalServer/sitedirectory/test";
            exportSettings.ExportMethod = SPExportMethodType.ExportAll;

            exportSettings.BaseFileName = "Testmigrationfile";
            exportSettings.FileLocation = @"c:\";


            SPExport export = new SPExport(exportSettings);

            export.Run();

        }

private void Import_Click(object sender, EventArgs e)
        {

            SPImportSettings importSettings = new SPImportSettings();

                importSettings.BaseFileName = "Testmigrationfile";
                importSettings.FileLocation = @"c:\";
                //'importSettings.UpdateVersions


                importSettings.SiteUrl = "http://Portalserver/";

                SPImport import = new SPImport(importSettings);
                import.Run();

            }
*/
 
    }
}
