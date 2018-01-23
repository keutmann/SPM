using System;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;
using System.Drawing;

namespace Keutmann.SharePointManager.Components
{
    public class FeatureNode : ExplorerNodeBase
    {
        private ToolStripItem ActivateMenuItem;
        private ToolStripItem DeActivateMenuItem;

        private string _Text = string.Empty;
        private string _ToolTip = string.Empty;
        private string _Name = string.Empty;

        public bool IsInstalled = false;

        private SPFeatureCollection _featureCollection = null;


        public SPFeatureDefinition Definition
        {
            get
            {
                return this.Tag as SPFeatureDefinition;
            }
        }

        public SPFeatureCollection FeatureCollection
        {
            get
            {
                if (_featureCollection == null)
                {
                    if (this.SPParent is SPWebApplication)
                    {
                        _featureCollection = ((SPWebApplication)this.SPParent).Features;
                    }
                    else
                        if (this.SPParent is SPSite)
                        {
                            _featureCollection = ((SPSite)this.SPParent).Features;
                        }
                        else
                        {
                            _featureCollection = ((SPWeb)this.SPParent).Features;
                        }
                }
                return _featureCollection;
            }
        }

        public override ContextMenuStrip ContextMenuStrip
        {
            get
            {
                if (base.ContextMenuStrip == MenuStripBase)
                {
                    MenuStripRefresh menu = new MenuStripRefresh();
                    menu.Opening += new System.ComponentModel.CancelEventHandler(menu_Opening);

                    ActivateMenuItem = menu.Insert(0, SPMLocalization.GetString("Feature_Activate"), null, new EventHandler(ActivateMenuItem_Click));
                    DeActivateMenuItem = menu.Insert(1, SPMLocalization.GetString("Feature_Deactivate"), null, new EventHandler(DeActivateMenuItem_Click));
                    menu.Insert(2, new ToolStripSeparator());

                    base.ContextMenuStrip = menu;
                }
                return base.ContextMenuStrip;
            }
            set
            {
                base.ContextMenuStrip = value;
            }
        }

        public FeatureNode(object spParent, SPFeatureDefinition definition, int imageIndex, bool installed)
        {
            this.Tag = definition;
            this.SPParent = spParent;
            this.ImageIndex = imageIndex;
            this.SelectedImageIndex = imageIndex;
            this.IsInstalled = installed;

            try
            {
                if (definition.Hidden)
                {
                    _Text = definition.GetTitle(SPMConfig.Instance.CultureInfo) + " (Hidden)";
                    this.ForeColor = Color.DarkGray;
                }
                else
                {
                    _Text = definition.GetTitle(SPMConfig.Instance.CultureInfo);
                }

                _ToolTip = definition.GetDescription(SPMConfig.Instance.CultureInfo);
                _Name = definition.Id.ToString();

                this.Setup();

                this.Nodes.Add(new ExplorerNodeBase("Dummy"));
            }
            catch(Exception ex) 
            {
                this.ForeColor = Color.DarkRed;
                if (definition != null)
                {
                    _Text = definition.RootDirectory.ToLower() + " (error)";
                    _ToolTip = ex.Message;
                    _Name = definition.Id.ToString();
                }
                else
                {
                    _Text = "(Error: Can not find feature definition)";
                    _ToolTip = ex.Message;
                    _Name = Guid.Empty.ToString();
                }

            }

        }
        //: this(spParent, feature.Definition, imageIndex, installed)
        public FeatureNode(object spParent, SPFeature feature, int imageIndex, bool installed) 
        {

            this.SPParent = spParent;
            this.ImageIndex = imageIndex;
            this.SelectedImageIndex = imageIndex;
            this.IsInstalled = installed;

            Color nodeColor = this.ForeColor;
            string addText = string.Empty;

            try
            {

                if (feature.Definition != null)
                {
                    this.Tag = feature.Definition;

                    if (feature.Definition.Hidden)
                    {
                        nodeColor = Color.DarkGray;
                        addText = " (Hidden)";
                    }

                    _Text = feature.Definition.GetTitle(SPMConfig.Instance.CultureInfo) + addText;
                    _ToolTip = feature.Definition.GetDescription(SPMConfig.Instance.CultureInfo);
                    _Name = feature.Definition.Id.ToString();

                    this.ForeColor = nodeColor;
                }
                else
                {
                    this.Tag = null;

                    _Text = SPMLocalization.GetString("Feature_Message01");
                    _ToolTip = SPMLocalization.GetString("Feature_Message02");
                    _Name = feature.DefinitionId.ToString();
                }
            }
            catch(Exception ex)
            {
                
                this.ForeColor = Color.DarkRed;
                _Text = "(Error: Feature missing)";
                _ToolTip = ex.Message;
                _Name = feature.DefinitionId + string.Empty;
            }

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
            ActivateMenuItem.Enabled = !IsInstalled;
            DeActivateMenuItem.Enabled = IsInstalled;
        }

        void ActivateMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            SPFeature feature = FeatureCollection.Add(Definition.Id, true);

            FeatureCollectionNode nodeCollection = (FeatureCollectionNode)this.Parent;
            this.ImageIndex = nodeCollection.InstalledIndex;
            this.SelectedImageIndex = nodeCollection.InstalledIndex;
            this.IsInstalled = true;

            //Program.Window.Explorer.SelectedNode = null;
            //Program.Window.Explorer.SelectedNode = this;

            Cursor.Current = Cursors.Default;
        }


        void DeActivateMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;


            FeatureCollection.Remove(Definition.Id, true);

            FeatureCollectionNode nodeCollection = (FeatureCollectionNode)this.Parent;
            this.ImageIndex = nodeCollection.UnInstalledIndex;
            this.SelectedImageIndex = nodeCollection.UnInstalledIndex;
            this.IsInstalled = false;

            //Program.Window.Explorer.SelectedNode = null;
            //Program.Window.Explorer.SelectedNode = this;

            Cursor.Current = Cursors.Default;
        }
    }
}
