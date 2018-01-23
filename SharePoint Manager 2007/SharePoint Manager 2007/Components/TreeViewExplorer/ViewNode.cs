using System;
using System.Collections;
using System.Windows.Forms;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    public class ViewNode : ExplorerNodeBase
    {
        public SPView View
        {
            get
            {
                return this.Tag as SPView;
            }
        }


        public ViewNode(SPView view)
        {
            this.Tag = view;
            this.SPParent = view.ParentList;

            int index = Program.Window.Explorer.AddImage(this.ImageUrl());
            this.ImageIndex = index;
            this.SelectedImageIndex = index;

            this.Setup();

            //this.Nodes.Add(new ExplorerNodeBase("Dummy"));
        }

        public override void Setup()
        {

            this.Text = View.Title;
            if (View.DefaultView)
            {
                this.Text += " " + SPMLocalization.GetString("ViewNode_Message01");
            }
            this.ToolTipText = SPMLocalization.GetString("View_ToolTip");
            this.Name = View.Url;
            this.BrowserUrl = SPUrlUtility.CombineUrl(View.ParentList.ParentWeb.Url, View.Url);             
        }


        public override string ImageUrl()
        {
            return SPMPaths.ImageDirectory + "itgen.GIF";
        }


        public override TabPage[] GetTabPages()
        {
            ArrayList alPages = new ArrayList();

            alPages.AddRange(base.GetTabPages());
            alPages.Add(TabPages.GetXmlPage("CAML", View.HtmlSchemaXml));

            return (TabPage[])alPages.ToArray(typeof(TabPage));
        }
    }
}
