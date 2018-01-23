using System;
using System.Collections;
using System.Text;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    class PropertyBagCollection : ExplorerNodeBase
    {
        public SPPropertyBag PropertyBag 
        {
            get
            {
                return this.Tag as SPPropertyBag;
            }
        }

        public PropertyBagCollection(object parent, SPPropertyBag property)
        {
            this.Text = SPMLocalization.GetString("PropertyBag_Text");
            this.ToolTipText = SPMLocalization.GetString("PropertyBag_ToolTip");
            this.Name = "Property Bag";
            this.Tag = property;
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

            foreach (DictionaryEntry entry in this.PropertyBag)
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
