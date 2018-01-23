using Keutmann.SharePointManager.Components;

namespace Keutmann.SharePointManager.Forms
{
    public partial class MainWindow
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.objectModelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mediumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemStandardBarVisible = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemStatusBarVisible = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spanishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dutchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.SMToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SPMimageList = new System.Windows.Forms.ImageList(this.components);
            this.toolStripToolBarStandard = new System.Windows.Forms.ToolStrip();
            this.toolStripDBConnection = new System.Windows.Forms.ToolStripButton();
            this.toolStripSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSaveAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripRefresh = new System.Windows.Forms.ToolStripButton();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.swedishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Explorer = new Keutmann.SharePointManager.Components.TreeViewExplorer();
            this.tabControl = new Keutmann.SharePointManager.Components.SPMTabControl();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.toolStripToolBarStandard.SuspendLayout();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripProgressBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 489);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(872, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripProgressBar.Enabled = false;
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar.Visible = false;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.languageToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(872, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openDatabaseToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveallToolStripMenuItem,
            this.toolStripMenuItem2,
            this.cancelToolStripMenuItem,
            this.toolStripMenuItem3,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openDatabaseToolStripMenuItem
            // 
            this.openDatabaseToolStripMenuItem.Image = global::Keutmann.SharePointManager.Properties.Resources.dbconnection;
            this.openDatabaseToolStripMenuItem.Name = "openDatabaseToolStripMenuItem";
            this.openDatabaseToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.openDatabaseToolStripMenuItem.Text = "Open Database";
            this.openDatabaseToolStripMenuItem.ToolTipText = "Open Databse Connection";
            this.openDatabaseToolStripMenuItem.Visible = false;
            this.openDatabaseToolStripMenuItem.Click += new System.EventHandler(this.toolStripDBConnection_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = global::Keutmann.SharePointManager.Properties.Resources.save;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.ToolTipText = "Save changes to SharePoint";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveallToolStripMenuItem
            // 
            this.saveallToolStripMenuItem.Image = global::Keutmann.SharePointManager.Properties.Resources.saveall;
            this.saveallToolStripMenuItem.Name = "saveallToolStripMenuItem";
            this.saveallToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.saveallToolStripMenuItem.Text = "Save &all";
            this.saveallToolStripMenuItem.ToolTipText = "Save all changes to SharePoint";
            this.saveallToolStripMenuItem.Click += new System.EventHandler(this.saveallToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(157, 6);
            // 
            // cancelToolStripMenuItem
            // 
            this.cancelToolStripMenuItem.Image = global::Keutmann.SharePointManager.Properties.Resources.undo;
            this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            this.cancelToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.cancelToolStripMenuItem.Text = "&Cancel";
            this.cancelToolStripMenuItem.ToolTipText = "Cancel all changes";
            this.cancelToolStripMenuItem.Click += new System.EventHandler(this.cancelToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(157, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.ToolTipText = "Close program";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Image = global::Keutmann.SharePointManager.Properties.Resources.refresh3;
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.toolStripRefresh_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.objectModelToolStripMenuItem,
            this.toolStripMenuItem4,
            this.MenuItemStandardBarVisible,
            this.MenuItemStatusBarVisible});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // objectModelToolStripMenuItem
            // 
            this.objectModelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.minimalToolStripMenuItem,
            this.mediumToolStripMenuItem,
            this.fullToolStripMenuItem});
            this.objectModelToolStripMenuItem.Name = "objectModelToolStripMenuItem";
            this.objectModelToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.objectModelToolStripMenuItem.Text = "Object Model";
            // 
            // minimalToolStripMenuItem
            // 
            this.minimalToolStripMenuItem.Name = "minimalToolStripMenuItem";
            this.minimalToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.minimalToolStripMenuItem.Tag = "1";
            this.minimalToolStripMenuItem.Text = "&Minimal";
            this.minimalToolStripMenuItem.Click += new System.EventHandler(this.OMViewSelectToolStripMenuItem_Click);
            // 
            // mediumToolStripMenuItem
            // 
            this.mediumToolStripMenuItem.Name = "mediumToolStripMenuItem";
            this.mediumToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.mediumToolStripMenuItem.Tag = "3";
            this.mediumToolStripMenuItem.Text = "Me&dium";
            this.mediumToolStripMenuItem.Click += new System.EventHandler(this.OMViewSelectToolStripMenuItem_Click);
            // 
            // fullToolStripMenuItem
            // 
            this.fullToolStripMenuItem.Checked = true;
            this.fullToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fullToolStripMenuItem.Name = "fullToolStripMenuItem";
            this.fullToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.fullToolStripMenuItem.Tag = "7";
            this.fullToolStripMenuItem.Text = "&Full";
            this.fullToolStripMenuItem.Click += new System.EventHandler(this.OMViewSelectToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(145, 6);
            // 
            // MenuItemStandardBarVisible
            // 
            this.MenuItemStandardBarVisible.Checked = true;
            this.MenuItemStandardBarVisible.CheckOnClick = true;
            this.MenuItemStandardBarVisible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MenuItemStandardBarVisible.Name = "MenuItemStandardBarVisible";
            this.MenuItemStandardBarVisible.Size = new System.Drawing.Size(148, 22);
            this.MenuItemStandardBarVisible.Text = "Tool Bar";
            this.MenuItemStandardBarVisible.Click += new System.EventHandler(this.toolBarToolStripMenuItem_Click);
            // 
            // MenuItemStatusBarVisible
            // 
            this.MenuItemStatusBarVisible.Checked = true;
            this.MenuItemStatusBarVisible.CheckOnClick = true;
            this.MenuItemStatusBarVisible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MenuItemStatusBarVisible.Name = "MenuItemStatusBarVisible";
            this.MenuItemStatusBarVisible.Size = new System.Drawing.Size(148, 22);
            this.MenuItemStatusBarVisible.Text = "Status Bar";
            this.MenuItemStatusBarVisible.Click += new System.EventHandler(this.MenuItemStatusBarVisible_Click);
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.spanishToolStripMenuItem,
            this.dutchToolStripMenuItem,
            this.swedishToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            this.languageToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.languageToolStripMenuItem.Text = "Language";
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Checked = true;
            this.englishToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.englishToolStripMenuItem.Text = "English";
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // spanishToolStripMenuItem
            // 
            this.spanishToolStripMenuItem.Name = "spanishToolStripMenuItem";
            this.spanishToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.spanishToolStripMenuItem.Text = "Spanish";
            this.spanishToolStripMenuItem.Click += new System.EventHandler(this.spanishToolStripMenuItem_Click);
            // 
            // dutchToolStripMenuItem
            // 
            this.dutchToolStripMenuItem.Name = "dutchToolStripMenuItem";
            this.dutchToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.dutchToolStripMenuItem.Text = "Dutch";
            this.dutchToolStripMenuItem.Click += new System.EventHandler(this.dutchToolStripMenuItem_Click);
            // 
            // swedishToolStripMenuItem
            // 
            this.swedishToolStripMenuItem.Name = "swedishToolStripMenuItem";
            this.swedishToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.swedishToolStripMenuItem.Text = "Swedish";
            this.swedishToolStripMenuItem.Click += new System.EventHandler(swedishToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::Keutmann.SharePointManager.Properties.Resources.about;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.ToolTipText = "About SharePoint Manager 2007";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(122, 6);
            // 
            // SMToolTip
            // 
            this.SMToolTip.AutomaticDelay = 300;
            // 
            // SPMimageList
            // 
            this.SPMimageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("SPMimageList.ImageStream")));
            this.SPMimageList.TransparentColor = System.Drawing.Color.Transparent;
            this.SPMimageList.Images.SetKeyName(0, "");
            this.SPMimageList.Images.SetKeyName(1, "");
            this.SPMimageList.Images.SetKeyName(2, "");
            this.SPMimageList.Images.SetKeyName(3, "");
            this.SPMimageList.Images.SetKeyName(4, "");
            this.SPMimageList.Images.SetKeyName(5, "");
            this.SPMimageList.Images.SetKeyName(6, "");
            this.SPMimageList.Images.SetKeyName(7, "AppPool.gif");
            this.SPMimageList.Images.SetKeyName(8, "WebAppPool.gif");
            this.SPMimageList.Images.SetKeyName(9, "Jobs16.gif");
            // 
            // toolStripToolBarStandard
            // 
            this.toolStripToolBarStandard.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDBConnection,
            this.toolStripSave,
            this.toolStripSaveAll,
            this.toolStripCancel,
            this.toolStripSeparator1,
            this.toolStripRefresh});
            this.toolStripToolBarStandard.Location = new System.Drawing.Point(0, 24);
            this.toolStripToolBarStandard.Name = "toolStripToolBarStandard";
            this.toolStripToolBarStandard.Size = new System.Drawing.Size(872, 25);
            this.toolStripToolBarStandard.TabIndex = 5;
            this.toolStripToolBarStandard.Text = "toolStrip1";
            // 
            // toolStripDBConnection
            // 
            this.toolStripDBConnection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDBConnection.Image = global::Keutmann.SharePointManager.Properties.Resources.dbconnection;
            this.toolStripDBConnection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDBConnection.Name = "toolStripDBConnection";
            this.toolStripDBConnection.Size = new System.Drawing.Size(23, 22);
            this.toolStripDBConnection.Text = "Open Database Connection";
            this.toolStripDBConnection.Visible = false;
            this.toolStripDBConnection.Click += new System.EventHandler(this.toolStripDBConnection_Click);
            // 
            // toolStripSave
            // 
            this.toolStripSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSave.Image = global::Keutmann.SharePointManager.Properties.Resources.save;
            this.toolStripSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSave.Name = "toolStripSave";
            this.toolStripSave.Size = new System.Drawing.Size(23, 22);
            this.toolStripSave.ToolTipText = "Save changes to SharePoint";
            this.toolStripSave.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSaveAll
            // 
            this.toolStripSaveAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSaveAll.Image = global::Keutmann.SharePointManager.Properties.Resources.saveall;
            this.toolStripSaveAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSaveAll.Name = "toolStripSaveAll";
            this.toolStripSaveAll.Size = new System.Drawing.Size(23, 22);
            this.toolStripSaveAll.ToolTipText = "Save all changes to SharePoint";
            this.toolStripSaveAll.Click += new System.EventHandler(this.saveallToolStripMenuItem_Click);
            // 
            // toolStripCancel
            // 
            this.toolStripCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripCancel.Image = global::Keutmann.SharePointManager.Properties.Resources.undo;
            this.toolStripCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripCancel.Name = "toolStripCancel";
            this.toolStripCancel.Size = new System.Drawing.Size(23, 22);
            this.toolStripCancel.ToolTipText = "Cancel all changes";
            this.toolStripCancel.Click += new System.EventHandler(this.cancelToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripRefresh
            // 
            this.toolStripRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripRefresh.Image = global::Keutmann.SharePointManager.Properties.Resources.refresh3;
            this.toolStripRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripRefresh.Name = "toolStripRefresh";
            this.toolStripRefresh.Size = new System.Drawing.Size(23, 22);
            this.toolStripRefresh.ToolTipText = "Refresh current node";
            this.toolStripRefresh.Click += new System.EventHandler(this.toolStripRefresh_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 49);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.Explorer);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.tabControl);
            this.splitContainer.Size = new System.Drawing.Size(872, 440);
            this.splitContainer.SplitterDistance = 408;
            this.splitContainer.TabIndex = 2;
            // 
            // Explorer
            // 
            this.Explorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Explorer.HideSelection = false;
            this.Explorer.Location = new System.Drawing.Point(0, 0);
            this.Explorer.Name = "Explorer";
            this.Explorer.ShowNodeToolTips = true;
            this.Explorer.Size = new System.Drawing.Size(408, 440);
            this.Explorer.TabIndex = 0;
            this.Explorer.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Explorer_KeyUp);
            this.Explorer.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.Explorer_NodeMouseClick);
            this.Explorer.Click += new System.EventHandler(this.Explorer_Click);
            // 
            // tabControl
            // 
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(460, 440);
            this.tabControl.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 511);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.toolStripToolBarStandard);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainWindow";
            this.Text = "SharePoint Manager 2010";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStripToolBarStandard.ResumeLayout(false);
            this.toolStripToolBarStandard.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer;
        public TreeViewExplorer Explorer;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        public System.Windows.Forms.ToolTip SMToolTip;
        public System.Windows.Forms.ImageList SPMimageList;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStripToolBarStandard;
        private System.Windows.Forms.ToolStripButton toolStripSave;
        private System.Windows.Forms.ToolStripButton toolStripSaveAll;
        private System.Windows.Forms.ToolStripButton toolStripCancel;
        private System.Windows.Forms.ToolStripButton toolStripRefresh;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveallToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripDBConnection;
        private System.Windows.Forms.ToolStripMenuItem openDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        public System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem objectModelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minimalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mediumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fullToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem MenuItemStandardBarVisible;
        private System.Windows.Forms.ToolStripMenuItem MenuItemStatusBarVisible;
        private SPMTabControl tabControl;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spanishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dutchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem swedishToolStripMenuItem;
    }
}

