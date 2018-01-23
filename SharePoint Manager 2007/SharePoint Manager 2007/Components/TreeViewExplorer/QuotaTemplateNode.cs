using System;
using System.IO;
using System.Xml;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    class QuotaTemplateNode : ExplorerNodeBase
    {
        public SPQuotaTemplate QuotaTemplate
        {
            get
            {
                return this.Tag as SPQuotaTemplate;
            }
        }


        public QuotaTemplateNode(object parent, SPQuotaTemplate tempate)
        {
            this.Tag = tempate;
            this.SPParent = parent;

            this.Setup();

            int index = Program.Window.Explorer.AddImage(this.ImageUrl());
            this.ImageIndex = index;
            this.SelectedImageIndex = index;

            this.Nodes.Add(new ExplorerNodeBase("Dummy"));
        }

        public override void Setup()
        {
            this.Text = QuotaTemplate.Name;
            this.ToolTipText = SPMLocalization.GetString("QuotaTemplate_ToolTip");
            this.Name = QuotaTemplate.QuotaID.ToString();


        }

        public override string ImageUrl()
        {
            return SPMPaths.ImageDirectory + "MARR.GIF";
        }

    }
}
