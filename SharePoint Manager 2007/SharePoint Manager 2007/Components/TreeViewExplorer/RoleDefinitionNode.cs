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
    public class RoleDefinitionNode : ExplorerNodeBase
    {

        public SPRoleDefinition RoleDefinition
        {
            get
            {
                return this.Tag as SPRoleDefinition;
            }
        }

        public RoleDefinitionNode(SPRoleDefinition roleDef)
        {
            this.Tag = roleDef;
            this.SPParent = roleDef.ParentWeb;

            this.Setup();
            
            this.Nodes.Add(new ExplorerNodeBase("Dummy"));
        }

        public override void Setup()
        {
            this.Text = this.RoleDefinition.Name;
            this.ToolTipText = this.RoleDefinition.Description;
            this.Name = this.RoleDefinition.Id.ToString();

            int index = Program.Window.Explorer.AddImage(this.ImageUrl());
            this.ImageIndex = index;
            this.SelectedImageIndex = index;
        }

        public override string ImageUrl()
        {
            return SPMPaths.ImageDirectory + "MARR.GIF";
        }


        public override void LoadNodes()
        {
            base.LoadNodes();

            //this.AddNode(NodeDisplayLevelType.Advanced, new UserCollectionNode(this.Group, this.Group.Users));
        }


        public override TabPage[] GetTabPages()
        {
            ArrayList alPages = new ArrayList();
            
            alPages.AddRange(base.GetTabPages());

            TabXmlPage xmlPage = TabPages.GetXmlPage("Xml", this.RoleDefinition.Xml);
            xmlPage.Text = xmlPage.Text.Replace(" ows_", "\r\n ows_");
            alPages.Add(xmlPage);

            return (TabPage[])alPages.ToArray(typeof(TabPage));

        }
    }
}
