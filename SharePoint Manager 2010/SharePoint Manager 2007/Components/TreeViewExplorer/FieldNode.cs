using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;


using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    class FieldNode : ExplorerNodeBase
    {
        public SPField Field
        {
            get
            {
                return this.Tag as SPField;
            }
        }

        public FieldNode(SPField field)
        {
            this.Tag = field;
            this.SPParent = field.ParentList;
            //this.ContextMenuStrip = SPMMenu.Strips.GetMenu(typeof(FieldMenuStrip));

            Setup();

            //this.Nodes.Add(new ExplorerNodeBase("Dummy"));
        }

        public override void Setup()
        {
            this.Text = Field.Title;
            this.ToolTipText = Field.Description;
            this.Name = Field.Id.ToString();

            int index = Program.Window.Explorer.AddImage(this.ImageUrl());
            this.ImageIndex = index;
            this.SelectedImageIndex = index;
        }

        public override string ImageUrl()
        {
            return SPMPaths.ImageDirectory + "MARR.GIF";
        }


        public override void CopyToClipboard()
        {
            System.Windows.Forms.Clipboard.SetText(Field.SchemaXml);
        }
    }
}
