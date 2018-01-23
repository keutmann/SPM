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
	[Title(PropertyName="Title")]
    //[ExportToNode("SPM2.SharePoint.Model.SPFolderNode")]
    //[ExportToNode("SPM2.SharePoint.Model.SPFileNode")]
    [ExportToNode("SPM2.SharePoint.Model.SPListCollectionNode")]
	public partial class SPDocumentLibraryNode
	{

        public override void Setup(object spObject)
        {
            base.Setup(spObject);

            string title = (String.IsNullOrEmpty(this.DocumentLibrary.Title)) ? this.DocumentLibrary.ID.ToString() : this.DocumentLibrary.Title;
            this.Text = String.Format("{0} ({1})", title, this.DocumentLibrary.ItemCount);

            if (this.DocumentLibrary.Hidden)
            {
                this.TextColor = "Gray";
            }

            this.Url = SPUtility.GetFullUrl(this.DocumentLibrary.ParentWeb.Site, this.DocumentLibrary.DefaultViewUrl);

            string filename = this.DocumentLibrary.ImageUrl;
            filename = filename.Substring(filename.LastIndexOf("/") + 1);
            this.IconUri = SharePointContext.GetImagePath(filename);
        }
	}
}
