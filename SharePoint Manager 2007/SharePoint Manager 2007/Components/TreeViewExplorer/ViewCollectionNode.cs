using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;
using System.Windows.Forms;
using System.Collections;

namespace Keutmann.SharePointManager.Components
{
    class ViewCollectionNode : ExplorerNodeBase
    {

        public SPViewCollection Views
        {
            get
            {
                return this.Tag as SPViewCollection;
            }
        }
        

        public SPList List
        {
            get
            {
                return this.SPParent as SPList;
            }
        }

        public ViewCollectionNode(SPList list)
        {
            this.Tag = list.Views;
            this.SPParent = list;

            int index = Program.Window.Explorer.AddImage(this.ImageUrl());
            this.ImageIndex = index;
            this.SelectedImageIndex = index;

            this.Setup();

            this.Nodes.Add(new ExplorerNodeBase("Dummy"));
        }


        public override void Setup()
        {
            this.Text = SPMLocalization.GetString("ViewsCollection_Text");
            this.ToolTipText = SPMLocalization.GetString("ViewsCollection_ToolTip");
            this.Name = "Views";
        }

        public override void LoadNodes()
        {
            base.LoadNodes();

            foreach (SPView view in Views)
            {
                this.Nodes.Add(new ViewNode(view));
            }
        }


        public override string ImageUrl()
        {
            return SPMPaths.ImageDirectory + "itgen.gif";
        }

        public override TabPage[] GetTabPages()
        {
            ArrayList alPages = new ArrayList(base.GetTabPages());

            string xml = this.List.GetPropertiesXmlForUncustomizedViews();
            if (!String.IsNullOrEmpty(xml))
            {
                alPages.Add(TabPages.GetXmlPage("BaseView Xml", xml));
            }

            return (TabPage[])alPages.ToArray(typeof(TabPage));
        }

        
    }
}
