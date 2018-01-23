using System;
using System.Xml;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    class FieldCollectionNode : ExplorerNodeBase
    {
        public SPFieldCollection Fields
        {
            get
            {
                return this.Tag as SPFieldCollection;
            }
        }


        public FieldCollectionNode(Object parent, SPFieldCollection collection)
        {
            this.Text = SPMLocalization.GetString("Fields_Text");
            this.ToolTipText = SPMLocalization.GetString("Fields_ToolTip");
            this.Name = "Fields";
            this.Tag = collection;
            this.SPParent = parent;

            int index = Program.Window.Explorer.AddImage(this.ImageUrl());
            this.ImageIndex = index;
            this.SelectedImageIndex = index;

            this.Nodes.Add(new ExplorerNodeBase("Dummy"));
        }


        public override void LoadNodes()
        {
            base.LoadNodes();

            Program.Window.toolStripStatusLabel.Text = SPMLocalization.GetString("LoadingFieldColumns");
            Program.Window.toolStripProgressBar.Visible = true;
            Program.Window.toolStripProgressBar.ToolTipText = SPMLocalization.GetString("LoadingFieldColumns");
            Program.Window.toolStripProgressBar.Value = 0;
            Program.Window.toolStripProgressBar.Maximum = this.Fields.Count;

            int i = 0;
            foreach (SPField field in this.Fields)
            {
                this.Nodes.Add(new FieldNode(field));
                
                Program.Window.toolStripProgressBar.Value = ++i;
            }
            Program.Window.toolStripProgressBar.Visible = false;
        }

        public override string ImageUrl()
        {
            return SPMPaths.ImageDirectory + "ICSMRTPG.GIF";
        }

        /// <summary>
        /// Implementes the paste functionality.
        /// If a valid xml string is in clipboard then
        /// create a new site column in the collection.
        /// </summary>
        public override void PasteFromClipboard()
        {
            string xml = Clipboard.GetText();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            XmlElement root = doc.DocumentElement;
            root.Attributes.RemoveNamedItem("ID");
            root.Attributes.RemoveNamedItem("SourceID");

            xml = root.OuterXml;

            Fields.AddFieldAsXml(xml);
        }

    }
}
