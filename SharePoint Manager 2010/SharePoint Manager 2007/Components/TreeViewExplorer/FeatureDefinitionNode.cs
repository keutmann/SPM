using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;
using System.Drawing;

namespace Keutmann.SharePointManager.Components
{
    public class FeatureDefinitionNode : ExplorerNodeBase
    {
        private ToolStripItem InstallMenuItem;
        private ToolStripItem UninstallMenuItem;

        private string _Text = string.Empty;
        private string _ToolTip = string.Empty;
        private string _Name = string.Empty;

        public int InstalledIndex = -1;
        public int UnInstalledIndex = -1;

        public bool IsInstalled = true;


        public TreeViewExplorer Explorer
        {
            get
            {
                return Program.Window.Explorer;
            }
        }


        public SPFeatureDefinition Definition
        {
            get
            {
                return this.Tag as SPFeatureDefinition;
            }
        }

        public override ContextMenuStrip ContextMenuStrip
        {
            get
            {
                if (base.ContextMenuStrip == MenuStripBase && !InReadOnlyMode)
                {
                    MenuStripRefresh menu = new MenuStripRefresh();

                    menu.Opening += new System.ComponentModel.CancelEventHandler(menu_Opening);

                    InstallMenuItem = menu.Insert(0, SPMLocalization.GetString("FeatureDefinition_Install"), null, new EventHandler(InstallMenuItem_Click));
                    UninstallMenuItem = menu.Insert(1, SPMLocalization.GetString("FeatureDefinition_Uninstall"), null, new EventHandler(UninstallMenuItem_Click));
                    menu.Insert(2, new ToolStripSeparator());

                    ContextMenuStrip = menu;

                    base.ContextMenuStrip = menu;
                }
                return base.ContextMenuStrip;
            }
            set
            {
                base.ContextMenuStrip = value;
            }
        }

        public FeatureDefinitionNode(object spParent, string path, string featureName, int installedIndex, int unInstalledIndex)
        {
            int index = featureName.IndexOf(@"\");
            index = (index > 0) ? index : featureName.Length;
            string name = featureName.Substring(0, index);

            this.Tag = path + name;
            this.SPParent = this.SPParent;
            this.InstalledIndex = installedIndex;
            this.UnInstalledIndex = unInstalledIndex;


            _Text = name + " " + SPMLocalization.GetString("FeatureDefinition_Message01");
            _ToolTip = _Text;
            _Name = featureName;

            this.ImageIndex = UnInstalledIndex;
            this.SelectedImageIndex = UnInstalledIndex;

            IsInstalled = false;

            this.Setup();
        }

        public FeatureDefinitionNode(object spParent, SPFeatureDefinition definition, int installedIndex, int unInstalledIndex)
        {
            this.Tag = definition;
            this.SPParent = spParent;
            this.InstalledIndex = installedIndex;
            this.UnInstalledIndex = unInstalledIndex;

            _Text = definition.GetTitle(SPMConfig.Instance.CultureInfo);
            _ToolTip = definition.GetDescription(SPMConfig.Instance.CultureInfo);
            _Name = definition.Id.ToString();

            if (definition.Status != SPObjectStatus.Online)
            {
                _Text += " (" + definition.Status.ToString() + ")";
            }

            this.ImageIndex = InstalledIndex;
            this.SelectedImageIndex = InstalledIndex;

            this.Setup();

            this.Nodes.Add(new ExplorerNodeBase("Dummy"));
        }


        public override void Setup()
        {
            this.Text = _Text;
            this.ToolTipText = _ToolTip;
            this.Name = _Name;
        }

        public override void LoadNodes()
        {
            base.LoadNodes();

        }

       private void menu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            InstallMenuItem.Enabled = !IsInstalled;
            UninstallMenuItem.Enabled = IsInstalled;
        }

      private void UninstallMenuItem_Click(object sender, EventArgs e)
       {
            Cursor.Current = Cursors.WaitCursor;
            Explorer.Update();

            Explorer.CurrentFarm.FeatureDefinitions.Remove(Definition.Id, true);

            this.Text = Definition.DisplayName;
            this.Name = "";
            this.Tag = Definition.RootDirectory;

            FeatureCollectionDefinitionNode nodeCollection = (FeatureCollectionDefinitionNode)this.Parent;
            this.ImageIndex = UnInstalledIndex;
            this.SelectedImageIndex = UnInstalledIndex;

            IsInstalled = false;

            Explorer.EndUpdate();
            Explorer.Refresh();
          
            //Program.Window.Explorer.SelectedNode = null;
            //Program.Window.Explorer.SelectedNode = this;

          Cursor.Current = Cursors.Default;
        }

        void InstallMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Explorer.Update();

            // Feature is not installed.
            string path = this.Tag as string;
            DirectoryInfo info = new DirectoryInfo(path);
            string featureName = info.Name + @"\feature.xml";

            SPFarm spFarm = Explorer.CurrentFarm;
            SPFeatureDefinition definition = spFarm.FeatureDefinitions.Add(featureName, Guid.Empty, true);
            SPFeatureDefinition dd = new SPFeatureDefinition();
            this.Text = definition.DisplayName;
            this.Name = definition.Id.ToString();
            this.Tag = definition;

            FeatureCollectionDefinitionNode nodeCollection = (FeatureCollectionDefinitionNode)this.Parent;
            this.ImageIndex = nodeCollection.InstalledIndex;
            this.SelectedImageIndex = nodeCollection.InstalledIndex;

            IsInstalled = true;

            Explorer.EndUpdate();
            Explorer.Refresh();

            //Program.Window.propertyGrid.SelectedObject = this.Tag;
            
            Cursor.Current = Cursors.Default;
        }
    }
}
