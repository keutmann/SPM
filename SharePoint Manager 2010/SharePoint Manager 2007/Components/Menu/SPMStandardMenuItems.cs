using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    public class SPMStandardMenuItems
    {


        public ExplorerNodeBase CurrentNode
        {
            get
            {
                return Program.Window.Explorer.SelectedNode as ExplorerNodeBase;
            }
        }

        //public ToolStripMenuItem Refresh;
        //public ToolStripSeparator Separator;

        public ToolStripSeparator CreateSeparator()
        {
            ToolStripSeparator separator = new ToolStripSeparator();
            //separator.Name = "Separator";
            //separator.Size = new System.Drawing.Size(122, 6);
            return separator;
        }

        public ToolStripMenuItem CreateCopy()
        {
            ToolStripMenuItem item = new ToolStripMenuItem();
            item.Text = SPMLocalization.GetString("Copy_Text");
            item.Name = "Copy";
            item.Image = global::Keutmann.SharePointManager.Properties.Resources.copy;
            item.Enabled = false;
            item.Click += new EventHandler(Copy_Click);

            return item;
        }

        public ToolStripMenuItem CreateCut()
        {
            ToolStripMenuItem item = new ToolStripMenuItem();
            item.Text = SPMLocalization.GetString("Cut");
            item.Name = "Cut_Text";
            item.Image = global::Keutmann.SharePointManager.Properties.Resources.cut;
            item.Enabled = false;
            item.Click += new EventHandler(Cut_Click);

            return item;
        }

        public ToolStripMenuItem CreatePaste()
        {
            ToolStripMenuItem item = new ToolStripMenuItem();
            item.Text = SPMLocalization.GetString("Paste_Text");
            item.Name = "Paste";
            item.Image = global::Keutmann.SharePointManager.Properties.Resources.paste;
            item.Enabled = false;
            item.Click += new EventHandler(Paste_Click);

            return item;
        }

        public ToolStripMenuItem CreateDelete()
        {
            ToolStripMenuItem delete = new ToolStripMenuItem();
            delete.Text = SPMLocalization.GetString("Delete_Text");
            delete.Name = "Delete";
            delete.Size = new System.Drawing.Size(125, 22);
            delete.Image = global::Keutmann.SharePointManager.Properties.Resources.delete;
            delete.Click += new EventHandler(Delete_Click);
            return delete;
        }

        public ToolStripMenuItem CreateTasks()
        {
            ToolStripMenuItem item = new ToolStripMenuItem();
            item.Text = "Tasks_Text";
            item.Name = "Tasks";
            item.Size = new System.Drawing.Size(125, 22);
            //delete.Image = global::Keutmann.SharePointManager.Properties.Resources.refresh3;
            //item.Click += new EventHandler(delete_Click);
            return item;
        }

        public ToolStripMenuItem CreateRefresh()
        {
            ToolStripMenuItem refresh = new ToolStripMenuItem();
            refresh.Text = SPMLocalization.GetString("Refresh_Text");
            refresh.Name = "Refresh";
            refresh.Size = new System.Drawing.Size(125, 22);
            refresh.Image = global::Keutmann.SharePointManager.Properties.Resources.refresh3;
            refresh.Click += new EventHandler(Refresh_Click);
            return refresh;
        }

        public SPMStandardMenuItems()
        {
            //this.Refresh = CreateRefresh();
            // 
            // ToolStripSeparator
            // 
        }


        //private void RefreshFunction()
        //{
        //    if (CurrentNode.Parent != null)
        //    {
        //        CurrentNode.Refresh();
        //    }
        //    else
        //    {

        //        // Reload the TreeView, because there is no parent to the node.
        //        // It is properly the root that haven been selected.
        //        Program.Window.Explorer.DisposeObjectModel();
        //        Program.Window.Explorer.Build();
        //    }
        //}


        public void Copy_Click(object sender, EventArgs e)
        {
            this.CurrentNode.CopyToClipboard();
        }

        public void Cut_Click(object sender, EventArgs e)
        {
            this.CurrentNode.CutToClipboard();
        }

        public void Paste_Click(object sender, EventArgs e)
        {
            this.CurrentNode.PasteFromClipboard();
        }

        public void Delete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(String.Format(SPMLocalization.GetString("Message_DeleteWarning"), CurrentNode.Text), SPMLocalization.GetString("Delete_Text"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                CurrentNode.Delete(); // Delete the SP object
                CurrentNode.Remove(); // Remove the TreeNode object
            }
        }

        public void Refresh_Click(object sender, EventArgs e)
        {
            //RefreshFunction();
            if (CurrentNode != null)
            {
                CurrentNode.Refresh();
                Program.Window.ChangedNodes.Remove(CurrentNode);
                Program.Window.UpdateMenu(CurrentNode);
            }
            else
            {
                MessageBox.Show(
                    "Could not load any nodes in this context. Make sure Sharepoint Manager is running on a Sharepoint server and in administrative mode.");
            }
        }
    }
}
