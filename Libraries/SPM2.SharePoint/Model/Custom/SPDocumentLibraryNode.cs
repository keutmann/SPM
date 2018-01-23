/* ---------------------------
 * SharePoint Manager 2010 v2
 * Created by Carsten Keutmann
 * ---------------------------
 */

using System;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using SPM2.Framework;
using Microsoft.SharePoint.Utilities;
using SPM2.SharePoint.Rules;
using System.Diagnostics;

namespace SPM2.SharePoint.Model
{
	[Title(PropertyName="Title")]
    [ExportToNode("SPM2.SharePoint.Model.SPListCollectionNode")]
    public partial class SPDocumentLibraryNode : IViewRule
	{

        public override void Setup(ISPNode parent)
        {
            base.Setup(parent);

            if (this.SPObject == null) return;

            string title = (String.IsNullOrEmpty(this.DocumentLibrary.Title)) ? this.DocumentLibrary.ID.ToString() : this.DocumentLibrary.Title;
            this.Text = String.Format("{0} ({1})", title, this.DocumentLibrary.ItemCount);

            if (this.DocumentLibrary.Hidden)
            {
                this.State = "Gray";
            }

            this.Url = SPUtility.GetFullUrl(this.DocumentLibrary.ParentWeb.Site, this.DocumentLibrary.DefaultViewUrl);

            this.IconUri = SPListNode.GetIconUri(this.DocumentLibrary.ImageUrl);
        }

        public bool IsVisible()
        {
            if (NodeProvider.ViewLevel >= 100)
                return true;

            var result = Parent is SPListCollectionNode;

            return result;
        }

    }
}
