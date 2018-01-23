using System;
using System.Reflection;
using System.IO;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Components;
using Keutmann.SharePointManager.Library;


namespace Keutmann.SharePointManager.Forms
{
    public partial class MainWindow : Form
    {
        private bool CancelActive = false;

        public Dictionary<ExplorerNodeBase, bool> ChangedNodes = new Dictionary<ExplorerNodeBase, bool>();

        public Dictionary<ExplorerNodeBase, Hashtable> ChangedPropertyItems = new Dictionary<ExplorerNodeBase, Hashtable>();
 

        public MainWindow()
        {
            InitializeComponent();
        }


 
        private void MainWindow_Load(object sender, EventArgs e)
        {
            //Initialize Culture
            if (SPMRegistry.GetValue(SPMLocalization.C_REGKEY_CULTURE, SPMLocalization.C_REGKEY_CULTUREID) == null)
            {
                SPMRegistry.SetValue(SPMLocalization.C_REGKEY_CULTURE, SPMLocalization.C_REGKEY_CULTUREID, SPMLocalization.C_CULTURE_EN);
            }
            else
            {
                /* NEW LANGUAGE INSTRUCTIONS
                 * - Add a new constant in Library-SPMLocalization.cs  (public const string C_CULTURE_XX = "XX";)
                 * - Add a new sub-menu ("Xxxxx") in the MainForm.cs under "Languages", and his Click Event
                 * - Add two rows code to the Event of the sub-menu:
                 *             SPMRegistry.SetValue(SPMLocalization.C_REGKEY_CULTURE, SPMLocalization.C_REGKEY_CULTUREID, SPMLocalization.C_CULTURE_XX);
                 *             this.MainWindow_Load(null, null);
                 * - Add a new case in the switch statement in the Load event of MainForm.cs (from row 57)
                 *                     case SPMLocalization.C_CULTURE_XX:
                 *                         xxxxxToolStripMenuItem.Checked = true;
                 *                         break;
                 * - Add a row in the function InitializeInterfaceStrings (MainForm.cs):
                 *                  xxxxxToolStripMenuItem.Text = SPMLocalization.GetString("Interface_xxxxxLanguage");
                 * - Add a row in each SPManagerLanguage.xx.resx file:
                 *                  Interface_xxxxxLanguage	    NameOfLanguageIn-resx-File	    MainForm
                 * - Add a new resources file to the project ("SPManagerLanguage.xx.resx")
                 * - Copy all from SPManagerLanguage.resx to the new SPManagerLanguage.xx.resx file
                 * - Change the "Value" of each string in the new file
                 */

                //Uncheck everything in the Language Menu
                foreach (ToolStripMenuItem myItem in languageToolStripMenuItem.DropDownItems)
                {
                    myItem.Checked = false;
                }

                //Select the correct one
                switch ((string)SPMRegistry.GetValue(SPMLocalization.C_REGKEY_CULTURE, SPMLocalization.C_REGKEY_CULTUREID))
                {
                    case SPMLocalization.C_CULTURE_EN:
                        englishToolStripMenuItem.Checked = true;
                        break;
                    case SPMLocalization.C_CULTURE_ES:
                        spanishToolStripMenuItem.Checked = true;
                        break;
                    case SPMLocalization.C_CULTURE_NL:
                        dutchToolStripMenuItem.Checked = true;
                        break;
                    case SPMLocalization.C_CULTURE_SV:
                        swedishToolStripMenuItem.Checked = true;
                        break;
                }
            }
            InitializeInterfaceStrings();

            Explorer.Build();

            // Call default expand after Explorer.Build();
            ExplorerClick(Explorer.SelectedNode as ExplorerNodeBase);
            TabPropertyPage propertyPage = TabPages.GetPropertyPage(TabPages.PROPERTIES, null);
            propertyPage.Grid.PropertyValueChanged += new PropertyValueChangedEventHandler(Grid_PropertyValueChanged);
        }



        private void ExplorerClick(ExplorerNodeBase node)
        {
            Cursor.Current = Cursors.WaitCursor;

            this.toolStripStatusLabel.Text = node.ToolTipText;
            UpdateMenu(node);

            ArrayList nodeColl = new ArrayList(node.GetTabPages());

            int i = 0;
            while (i < tabControl.TabPages.Count)
            {
                TabPage page = tabControl.TabPages[i];
                if (nodeColl.Contains(page))
                {
                    i++;
                }
                else
                {
                    tabControl.TabPages.Remove(page);
                }
            }

            foreach (TabPage page in nodeColl)
            {
                if (!tabControl.Contains(page))
                {
                    tabControl.TabPages.Add(page);
                }
            }

            

            //tabControl.Update();
            Cursor.Current = Cursors.Default;
        }


        private void Explorer_Click(object sender, EventArgs e)
        {
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();

            aboutForm.ShowDialog();
        }


        public void UpdateMenu(ExplorerNodeBase node)
        {
            toolStripSave.Enabled = ChangedNodes.ContainsKey(node);
            toolStripSaveAll.Enabled = ChangedNodes.Count > 0;
            toolStripCancel.Enabled = ChangedNodes.Count > 0;
            toolStripRefresh.Enabled = true;

            saveallToolStripMenuItem.Enabled = ChangedNodes.Count > 0;
            saveToolStripMenuItem.Enabled = ChangedNodes.ContainsKey(node);
            cancelToolStripMenuItem.Enabled = ChangedNodes.Count > 0;
            refreshToolStripMenuItem.Enabled = true;

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //foreach(ExplorerNodeBase node in Explorer.

            this.Close();
        }

        void Grid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if (!CancelActive)
            {
                ExplorerNodeBase node = (ExplorerNodeBase)Explorer.SelectedNode;
                
                Hashtable propertyItems = null;
                if (!ChangedPropertyItems.ContainsKey(node))
                {
                    propertyItems = new Hashtable();
                    ChangedPropertyItems[node] = propertyItems;
                }
                else
                {
                    propertyItems = ChangedPropertyItems[node];
                }
                propertyItems[e.ChangedItem] = e;

                ChangedNodes[node] = true;

                UpdateMenu(node);
            }
        }


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ExplorerNodeBase node = Explorer.SelectedNode as ExplorerNodeBase;
            this.toolStripStatusLabel.Text = SPMLocalization.GetString("Saving_Changes");

            if (ChangedNodes.ContainsKey(node))
            {
                node.Update();
                node.Setup();
                ChangedNodes.Remove(node);
            }
            UpdateMenu(node);
            this.toolStripStatusLabel.Text = SPMLocalization.GetString("Changes_Saved");
            Cursor.Current = Cursors.Default;
        }

        private void saveallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ExplorerNodeBase selectedNode = Explorer.SelectedNode as ExplorerNodeBase;

            this.toolStripStatusLabel.Text = SPMLocalization.GetString("Saving_All_Changes");
            foreach (ExplorerNodeBase node in ChangedNodes.Keys)
            {
                node.Update();
                node.Setup();
            }
            ChangedNodes.Clear();

            UpdateMenu(selectedNode);

            this.toolStripStatusLabel.Text = SPMLocalization.GetString("Changes_Saved");
            Cursor.Current = Cursors.Default;
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            CancelActive = true;
            ExplorerNodeBase selectedNode = Explorer.SelectedNode as ExplorerNodeBase;

            this.toolStripStatusLabel.Text = SPMLocalization.GetString("Cancel_All_Modifications");

            foreach (ExplorerNodeBase node in ChangedNodes.Keys)
            {
                Hashtable propertyItem = ChangedPropertyItems[node];

                foreach (PropertyValueChangedEventArgs pvEventArgs in propertyItem.Values)
                {
                    PropertyDescriptor pd = pvEventArgs.ChangedItem.PropertyDescriptor;

                    Type nodeType = node.Tag.GetType();
                    FieldInfo myField = nodeType.GetField(pd.Name, BindingFlags.Instance | BindingFlags.Public);
                    if (myField != null)
                    {
                        myField.SetValue(node.Tag, pvEventArgs.OldValue);
                    }
                    else
                    {
                        PropertyInfo myProperty = nodeType.GetProperty(pd.Name, BindingFlags.Instance | BindingFlags.Public);
                        if (myProperty != null)
                        {
                            myProperty.SetValue(node.Tag, pvEventArgs.OldValue, null);
                        }
                    }
                }

                ChangedPropertyItems.Remove(node);
            }

            
            foreach (TabPage page in tabControl.TabPages)
            {
                if (page is TabPropertyPage)
                {
                    ((TabPropertyPage)page).Grid.Refresh();
                }
            }

            ChangedNodes.Clear();

            UpdateMenu(selectedNode);

            //this.toolStripStatusLabel.Text = "All modifications has been canceled";
            CancelActive = false;
            Cursor.Current = Cursors.Default;
        }

        private void toolStripRefresh_Click(object sender, EventArgs e)
        {
            SPMMenu.Items.Refresh_Click(sender, e);
        }

        private void toolStripDBConnection_Click(object sender, EventArgs e)
        {
            OpenDBConnection connectionForm = new OpenDBConnection();
            SPMFarmHelper farmHelper = new SPMFarmHelper(Explorer.CurrentFarm);

            connectionForm.ConnectionString = "";// farmHelper.GetConnectionString();
            //contentService.Instances[0]
            DialogResult result = connectionForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                SPFarm newFarm = SPFarm.Open(connectionForm.ConnectionString);

                Explorer.DisposeObjectModel();
                Explorer.CurrentFarm = newFarm;
                Explorer.Build();
            }

        }

        private void OMViewSelectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;

            minimalToolStripMenuItem.Checked = false;
            mediumToolStripMenuItem.Checked = false;
            fullToolStripMenuItem.Checked = false;

            item.Checked = true;

            int filter = int.Parse(item.Tag as string);
            Explorer.DisplayLevel = (NodeDisplayLevelType)filter;
            Explorer.Build();
        }

        private void toolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripToolBarStandard.Visible = MenuItemStandardBarVisible.Checked;
        }

        private void MenuItemStatusBarVisible_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = MenuItemStatusBarVisible.Checked;
        }

        private void InitializeInterfaceStrings()
        {
            fileToolStripMenuItem.Text                  = SPMLocalization.GetString("Interface_File_Text");
            fileToolStripMenuItem.ToolTipText           = SPMLocalization.GetString("Interface_File_ToolTip");
            openDatabaseToolStripMenuItem.Text          = SPMLocalization.GetString("Interface_OpenDatabase_Text");
            openDatabaseToolStripMenuItem.ToolTipText   = SPMLocalization.GetString("Interface_OpenDatabase_ToolTip");
            saveToolStripMenuItem.Text                  = SPMLocalization.GetString("Interface_Save_Text");
            saveToolStripMenuItem.ToolTipText           = SPMLocalization.GetString("Interface_Save_ToolTip");
            saveallToolStripMenuItem.Text               = SPMLocalization.GetString("Interface_SaveAll_Text");
            saveallToolStripMenuItem.ToolTipText        = SPMLocalization.GetString("Interface_SaveAll_ToolTip");
            cancelToolStripMenuItem.Text                = SPMLocalization.GetString("Interface_Cancel_Text");
            cancelToolStripMenuItem.ToolTipText         = SPMLocalization.GetString("Interface_Cancel_ToolTip");
            exitToolStripMenuItem.Text                  = SPMLocalization.GetString("Interface_Exit_Text");
            exitToolStripMenuItem.ToolTipText           = SPMLocalization.GetString("Interface_Exit_ToolTip");
            editToolStripMenuItem.Text                  = SPMLocalization.GetString("Interface_Edit_Text");
            editToolStripMenuItem.ToolTipText           = SPMLocalization.GetString("Interface_Edit_ToolTip");
            refreshToolStripMenuItem.Text               = SPMLocalization.GetString("Interface_Refresh_Text");
            refreshToolStripMenuItem.ToolTipText        = SPMLocalization.GetString("Interface_Refresh_ToolTip");
            viewToolStripMenuItem.Text                  = SPMLocalization.GetString("Interface_View_Text");
            viewToolStripMenuItem.ToolTipText           = SPMLocalization.GetString("Interface_View_ToolTip");
            objectModelToolStripMenuItem.Text           = SPMLocalization.GetString("Interface_ObjectModel_Text");
            objectModelToolStripMenuItem.ToolTipText    = SPMLocalization.GetString("Interface_ObjectModel_ToolTip");
            minimalToolStripMenuItem.Text               = SPMLocalization.GetString("Interface_Minimal_Text");
            minimalToolStripMenuItem.ToolTipText        = SPMLocalization.GetString("Interface_Minimal_ToolTip");
            mediumToolStripMenuItem.Text                = SPMLocalization.GetString("Interface_Medium_Text");
            mediumToolStripMenuItem.ToolTipText         = SPMLocalization.GetString("Interface_Medium_ToolTip");
            fullToolStripMenuItem.Text                  = SPMLocalization.GetString("Interface_Full_Text");
            fullToolStripMenuItem.ToolTipText           = SPMLocalization.GetString("Interface_Full_ToolTip");
            MenuItemStandardBarVisible.Text             = SPMLocalization.GetString("Interface_ToolBar_Text");
            MenuItemStandardBarVisible.ToolTipText      = SPMLocalization.GetString("Interface_ToolBar_ToolTip");
            MenuItemStatusBarVisible.Text               = SPMLocalization.GetString("Interface_StatusBar_Text");
            MenuItemStatusBarVisible.ToolTipText        = SPMLocalization.GetString("Interface_StatusBar_ToolTip");
            helpToolStripMenuItem.Text                  = SPMLocalization.GetString("Interface_Help_Text");
            helpToolStripMenuItem.ToolTipText           = SPMLocalization.GetString("Interface_Help_ToolTip");
            aboutToolStripMenuItem.Text                 = SPMLocalization.GetString("Interface_About_Text");
            aboutToolStripMenuItem.ToolTipText          = SPMLocalization.GetString("Interface_About_ToolTip");
            toolStripDBConnection.Text                  = SPMLocalization.GetString("Interface_OpenDataBaseConn_Text");
            toolStripDBConnection.ToolTipText           = SPMLocalization.GetString("Interface_OpenDataBaseConn_ToolTip");
            toolStripRefresh.Text                       = SPMLocalization.GetString("Interface_RefreshNode_Text");
            toolStripRefresh.ToolTipText                = SPMLocalization.GetString("Interface_RefreshNode_ToolTip");
            languageToolStripMenuItem.Text              = SPMLocalization.GetString("Interface_Languages");
            englishToolStripMenuItem.Text               = SPMLocalization.GetString("Interface_EnglishLanguage");
            spanishToolStripMenuItem.Text               = SPMLocalization.GetString("Interface_SpanishLanguage");
            dutchToolStripMenuItem.Text                 = SPMLocalization.GetString("Interface_DutchLanguage");
            swedishToolStripMenuItem.Text               = SPMLocalization.GetString("Interface_SwedishLanguage");
            saveToolStripMenuItem.Text                  = SPMLocalization.GetString("Interface_Save_ToolTip");
            saveallToolStripMenuItem.Text               = SPMLocalization.GetString("Interface_SaveAll_ToolTip");
            cancelToolStripMenuItem.Text                = SPMLocalization.GetString("Interface_Cancel_ToolTip");
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //SPMRegistry.SetValue(SPMLocalization.C_REGKEY_CULTURE, SPMLocalization.C_REGKEY_CULTUREID, SPMLocalization.C_CULTURE_EN);
            SPMLocalization.SelectedLanguage = SPMLocalization.C_CULTURE_EN;
            this.MainWindow_Load(null, null);
        }

        private void spanishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //SPMRegistry.SetValue(SPMLocalization.C_REGKEY_CULTURE, SPMLocalization.C_REGKEY_CULTUREID, SPMLocalization.C_CULTURE_ES);
            SPMLocalization.SelectedLanguage = SPMLocalization.C_CULTURE_ES;
            this.MainWindow_Load(null, null);
        }

        private void dutchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SPMLocalization.SelectedLanguage = SPMLocalization.C_CULTURE_NL;
            //SPMRegistry.SetValue(SPMLocalization.C_REGKEY_CULTURE, SPMLocalization.C_REGKEY_CULTUREID, SPMLocalization.C_CULTURE_NL);
            this.MainWindow_Load(null, null);
        }

        void swedishToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            SPMLocalization.SelectedLanguage = SPMLocalization.C_CULTURE_SV;
            this.MainWindow_Load(null, null);
        }

        void Explorer_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Return)
            {
                ExplorerClick(Explorer.SelectedNode as ExplorerNodeBase);
            }
        }
        void Explorer_NodeMouseClick(object sender, System.Windows.Forms.TreeNodeMouseClickEventArgs e)
        {
            ExplorerClick(e.Node as ExplorerNodeBase);
        }
    }
}
