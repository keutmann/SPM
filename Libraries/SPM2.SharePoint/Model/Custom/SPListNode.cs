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

namespace SPM2.SharePoint.Model
{
	[ExportToNode("SPM2.SharePoint.Model.SPListCollectionNode")]
	public partial class SPListNode : IViewRule
	{

        public override void Setup(ISPNode parent)
        {
            base.Setup(parent);

            string title = (String.IsNullOrEmpty(this.List.Title)) ? this.List.ID.ToString() : this.List.Title;
            this.Text = String.Format("{0} ({1})", title, this.List.ItemCount);

            if (this.List.Hidden)
            {
                this.State = "Gray";
            }

            this.Url = SPUtility.GetFullUrl(List.ParentWeb.Site, List.DefaultViewUrl);

            this.IconUri = GetIconUri(this.List.ImageUrl);
        }


        public bool IsVisible()
        {
            if (NodeProvider.ViewLevel >= 100)
                return true;

            var result = Parent is SPListCollectionNode;

            return result;
        }

        public static string GetIconUri(string filename)
        {
            return SharePointContext.GetImagePath(filename.TrimLastIndexOf("/").TrimEndLastIndexOf("?"));
        }

	}
}
