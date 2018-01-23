namespace Keutmann.SharePointManager.Components.FileListView
{
    partial class FileListView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileListView));
            this.toolStripTop = new System.Windows.Forms.ToolStrip();
            this.toolStripUncheckAll = new System.Windows.Forms.ToolStripButton();
            this.SplitButtonFindfiles = new System.Windows.Forms.ToolStripSplitButton();
            this.MenuItemIncludeSubFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.checkOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.discardCheckOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkIndToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rejectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.approveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.publishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unpublishThisVersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripFilter = new System.Windows.Forms.ToolStripDropDownButton();
            this.allFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.checkedOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.draftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.publishedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pendingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rejectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.ItemView = new Keutmann.SharePointManager.Components.FileListView.SPMListView(this.components);
            this.ColumnName = new System.Windows.Forms.ColumnHeader();
            this.ColumnPath = new System.Windows.Forms.ColumnHeader();
            this.ColumnCheckOutTo = new System.Windows.Forms.ColumnHeader();
            this.toolStripTop.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripTop
            // 
            this.toolStripTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripUncheckAll,
            this.SplitButtonFindfiles,
            this.toolStripSplitButton1,
            this.toolStripFilter});
            this.toolStripTop.Location = new System.Drawing.Point(0, 0);
            this.toolStripTop.Name = "toolStripTop";
            this.toolStripTop.Size = new System.Drawing.Size(300, 25);
            this.toolStripTop.TabIndex = 0;
            this.toolStripTop.Text = "toolStrip1";
            // 
            // toolStripUncheckAll
            // 
            this.toolStripUncheckAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripUncheckAll.Image = ((System.Drawing.Image)(resources.GetObject("toolStripUncheckAll.Image")));
            this.toolStripUncheckAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripUncheckAll.Name = "toolStripUncheckAll";
            this.toolStripUncheckAll.Size = new System.Drawing.Size(23, 22);
            this.toolStripUncheckAll.ToolTipText = "Check / uncheck all";
            this.toolStripUncheckAll.Click += new System.EventHandler(this.toolStripUncheckAll_Click);
            // 
            // SplitButtonFindfiles
            // 
            this.SplitButtonFindfiles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SplitButtonFindfiles.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemIncludeSubFiles});
            this.SplitButtonFindfiles.Image = ((System.Drawing.Image)(resources.GetObject("SplitButtonFindfiles.Image")));
            this.SplitButtonFindfiles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SplitButtonFindfiles.Name = "SplitButtonFindfiles";
            this.SplitButtonFindfiles.Size = new System.Drawing.Size(65, 22);
            this.SplitButtonFindfiles.Text = "Find files";
            this.SplitButtonFindfiles.ButtonClick += new System.EventHandler(this.MenuItemFindFiles_Click);
            // 
            // MenuItemIncludeSubFiles
            // 
            this.MenuItemIncludeSubFiles.Name = "MenuItemIncludeSubFiles";
            this.MenuItemIncludeSubFiles.Size = new System.Drawing.Size(152, 22);
            this.MenuItemIncludeSubFiles.Text = "LoadSub";
            this.MenuItemIncludeSubFiles.Click += new System.EventHandler(this.MenuItemIncludeSubFiles_Click);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkOutToolStripMenuItem,
            this.discardCheckOutToolStripMenuItem,
            this.checkIndToolStripMenuItem,
            this.rejectToolStripMenuItem,
            this.approveToolStripMenuItem,
            this.publishToolStripMenuItem,
            this.unpublishThisVersionToolStripMenuItem});
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(58, 22);
            this.toolStripSplitButton1.Text = "Actions";
            this.toolStripSplitButton1.ToolTipText = "Actions";
            // 
            // checkOutToolStripMenuItem
            // 
            this.checkOutToolStripMenuItem.Name = "checkOutToolStripMenuItem";
            this.checkOutToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.checkOutToolStripMenuItem.Text = "Check out";
            // 
            // discardCheckOutToolStripMenuItem
            // 
            this.discardCheckOutToolStripMenuItem.Name = "discardCheckOutToolStripMenuItem";
            this.discardCheckOutToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.discardCheckOutToolStripMenuItem.Text = "Discard check out";
            // 
            // checkIndToolStripMenuItem
            // 
            this.checkIndToolStripMenuItem.Name = "checkIndToolStripMenuItem";
            this.checkIndToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.checkIndToolStripMenuItem.Text = "Check in";
            // 
            // rejectToolStripMenuItem
            // 
            this.rejectToolStripMenuItem.Name = "rejectToolStripMenuItem";
            this.rejectToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.rejectToolStripMenuItem.Text = "Reject";
            // 
            // approveToolStripMenuItem
            // 
            this.approveToolStripMenuItem.Name = "approveToolStripMenuItem";
            this.approveToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.approveToolStripMenuItem.Text = "Approve";
            // 
            // publishToolStripMenuItem
            // 
            this.publishToolStripMenuItem.Name = "publishToolStripMenuItem";
            this.publishToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.publishToolStripMenuItem.Text = "Publish";
            // 
            // unpublishThisVersionToolStripMenuItem
            // 
            this.unpublishThisVersionToolStripMenuItem.Name = "unpublishThisVersionToolStripMenuItem";
            this.unpublishThisVersionToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.unpublishThisVersionToolStripMenuItem.Text = "Unpublish this version";
            // 
            // toolStripFilter
            // 
            this.toolStripFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripFilter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allFilesToolStripMenuItem,
            this.toolStripSeparator1,
            this.checkedOutToolStripMenuItem,
            this.draftToolStripMenuItem,
            this.publishedToolStripMenuItem,
            this.pendingToolStripMenuItem,
            this.rejectedToolStripMenuItem});
            this.toolStripFilter.Image = ((System.Drawing.Image)(resources.GetObject("toolStripFilter.Image")));
            this.toolStripFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripFilter.Name = "toolStripFilter";
            this.toolStripFilter.Size = new System.Drawing.Size(44, 22);
            this.toolStripFilter.Text = "Filter";
            // 
            // allFilesToolStripMenuItem
            // 
            this.allFilesToolStripMenuItem.Name = "allFilesToolStripMenuItem";
            this.allFilesToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.allFilesToolStripMenuItem.Text = "All files";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(142, 6);
            // 
            // checkedOutToolStripMenuItem
            // 
            this.checkedOutToolStripMenuItem.Name = "checkedOutToolStripMenuItem";
            this.checkedOutToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.checkedOutToolStripMenuItem.Text = "Checked out";
            // 
            // draftToolStripMenuItem
            // 
            this.draftToolStripMenuItem.Name = "draftToolStripMenuItem";
            this.draftToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.draftToolStripMenuItem.Text = "Draft";
            // 
            // publishedToolStripMenuItem
            // 
            this.publishedToolStripMenuItem.Name = "publishedToolStripMenuItem";
            this.publishedToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.publishedToolStripMenuItem.Text = "Published";
            // 
            // pendingToolStripMenuItem
            // 
            this.pendingToolStripMenuItem.Name = "pendingToolStripMenuItem";
            this.pendingToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.pendingToolStripMenuItem.Text = "Pending";
            // 
            // rejectedToolStripMenuItem
            // 
            this.rejectedToolStripMenuItem.Name = "rejectedToolStripMenuItem";
            this.rejectedToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.rejectedToolStripMenuItem.Text = "Rejected";
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.btnCancel);
            this.panelBottom.Controls.Add(this.lblStatus);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 296);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(300, 23);
            this.panelBottom.TabIndex = 2;
            this.panelBottom.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(235, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(65, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(3, 5);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 0;
            // 
            // ItemView
            // 
            this.ItemView.CheckBoxes = true;
            this.ItemView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnName,
            this.ColumnPath,
            this.ColumnCheckOutTo});
            this.ItemView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ItemView.FullRowSelect = true;
            this.ItemView.Location = new System.Drawing.Point(0, 25);
            this.ItemView.MultiSelect = false;
            this.ItemView.Name = "ItemView";
            this.ItemView.Size = new System.Drawing.Size(300, 271);
            this.ItemView.TabIndex = 1;
            this.ItemView.UseCompatibleStateImageBehavior = false;
            this.ItemView.View = System.Windows.Forms.View.Details;
            // 
            // ColumnName
            // 
            this.ColumnName.Text = "Name";
            this.ColumnName.Width = 117;
            // 
            // ColumnPath
            // 
            this.ColumnPath.Text = "Path";
            // 
            // ColumnCheckOutTo
            // 
            this.ColumnCheckOutTo.Text = "Checked out to";
            this.ColumnCheckOutTo.Width = 119;
            // 
            // FileListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ItemView);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.toolStripTop);
            this.Name = "FileListView";
            this.Size = new System.Drawing.Size(300, 319);
            this.toolStripTop.ResumeLayout(false);
            this.toolStripTop.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripTop;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem checkOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem discardCheckOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkIndToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rejectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem approveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem publishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unpublishThisVersionToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader ColumnName;
        private System.Windows.Forms.ColumnHeader ColumnPath;
        private System.Windows.Forms.ColumnHeader ColumnCheckOutTo;
        private System.Windows.Forms.ToolStripDropDownButton toolStripFilter;
        private System.Windows.Forms.ToolStripMenuItem allFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkedOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem draftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem publishedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pendingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rejectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripUncheckAll;
        private SPMListView ItemView;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ToolStripSplitButton SplitButtonFindfiles;
        private System.Windows.Forms.ToolStripMenuItem MenuItemIncludeSubFiles;
    }
}
