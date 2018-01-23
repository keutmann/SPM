/* ---------------------------
 * SharePoint Manager 2010 v2
 * Created by Carsten Keutmann
 * ---------------------------
 */

using System;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using SPM2.Framework;

namespace SPM2.SharePoint.Model
{
	[Title(PropertyName="Title")]
    [Icon(Small = "CAT.GIF")]
	[ExportToNode("SPM2.SharePoint.Model.SPWebCollectionNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPSiteNode")]
	public partial class SPWebNode
	{

        public override void Setup(object spObject)
        {
            base.Setup(spObject);
            this.Text = this.Web.Title;
            this.Url = this.Web.Url;
        }

        public override bool IsDefaultSelected()
        {
            return true;
        }
	}
}
