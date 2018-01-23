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
    public class GroupNode : ExplorerNodeBase
    {

        public SPGroup Group
        {
            get
            {
                return this.Tag as SPGroup;
            }
        }

        public GroupNode(SPGroup group)
        {
            this.Tag = group;
            this.SPParent = group.ParentWeb;
            //this.WebNode = webNode;

            this.Setup();

            this.Nodes.Add(new ExplorerNodeBase("Dummy"));
        }

        public override void Setup()
        {
            this.Text = this.Group.Name;
            this.ToolTipText = this.Group.Description;
            this.Name = this.Group.ID.ToString();

            int index = Program.Window.Explorer.AddImage(this.ImageUrl());
            this.ImageIndex = index;
            this.SelectedImageIndex = index;
        }


        public override void LoadNodes()
        {
            base.LoadNodes();

            this.AddNode(NodeDisplayLevelType.Advanced, new UserCollectionNode(this.Group, this.Group.Users));
        }

        public override string ImageUrl()
        {
            return SPMPaths.ImageDirectory + "MARR.GIF";
        }


        public override TabPage[] GetTabPages()
        {
            ArrayList alPages = new ArrayList();
            
            alPages.AddRange(base.GetTabPages());

            TabXmlPage xmlPage = TabPages.GetXmlPage("Xml", this.Group.Xml);
            xmlPage.Text = xmlPage.Text.Replace(" ows_", "\r\n ows_");
            alPages.Add(xmlPage);

            return (TabPage[])alPages.ToArray(typeof(TabPage));

        }
    }
}
