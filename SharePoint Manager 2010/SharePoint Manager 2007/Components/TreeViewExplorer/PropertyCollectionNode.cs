using System;
using System.Collections;
using System.Text;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;


namespace Keutmann.SharePointManager.Components
{
    class PropertyCollectionNode : ExplorerNodeBase
    {
        public Hashtable Properties
        {
            get
            {
                return this.Tag as Hashtable;
            }
        }

        public PropertyCollectionNode(object parent, Hashtable properties)
        {
            this.Text = SPMLocalization.GetString("Properties_Text");
            this.ToolTipText = SPMLocalization.GetString("Properties_ToolTip");
            this.Name = "Properties";
            this.Tag = properties;

            this.SPParent = parent;

            int index = Program.Window.Explorer.AddImage(this.ImageUrl());
            this.ImageIndex = index;
            this.SelectedImageIndex = index;

            this.Nodes.Add("Dummy");

        }

        public override void LoadNodes()
        {
            base.LoadNodes();

            // Property icon
            int index = 6; 

            foreach (DictionaryEntry entry in this.Properties)
            {

                ExplorerNodeBase node = new ExplorerNodeBase(entry.Key.ToString());
                node.ToolTipText = "";
                node.Name = entry.Key.ToString();
                node.Tag = entry;
                node.SPParent = this.SPParent;

                node.ImageIndex = index;
                node.SelectedImageIndex = index;

                this.Nodes.Add(node);
            }
        }

        public override string ImageUrl()
        {
            return SPMPaths.ImageDirectory + "EXITGRID.GIF";
        }
    }
}
