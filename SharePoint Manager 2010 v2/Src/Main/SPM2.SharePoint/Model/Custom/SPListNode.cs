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

namespace SPM2.SharePoint.Model
{
	[ExportToNode("SPM2.SharePoint.Model.SPListCollectionNode")]
	public partial class SPListNode
	{

        public override void Setup(object spObject)
        {
            base.Setup(spObject);

            string title = (String.IsNullOrEmpty(this.List.Title)) ? this.List.ID.ToString() : this.List.Title;
            this.Text = String.Format("{0} ({1})", title, this.List.ItemCount);

            if (this.List.Hidden)
            {
                this.TextColor = "Gray";
            }

            this.Url = SPUtility.GetFullUrl(List.ParentWeb.Site, List.DefaultViewUrl);

            string filename = this.List.ImageUrl;
            filename = filename.Substring(filename.LastIndexOf("/") + 1);
            this.IconUri = SharePointContext.GetImagePath(filename);
        }



	}
}
