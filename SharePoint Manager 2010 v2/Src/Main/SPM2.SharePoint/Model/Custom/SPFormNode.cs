/* ---------------------------
 * SharePoint Manager 2010 v2
 * Created by Carsten Keutmann
 * ---------------------------
 */

using System;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using SPM2.Framework;
using Microsoft.SharePoint.WebPartPages;
using Microsoft.SharePoint.Utilities;

namespace SPM2.SharePoint.Model
{
    [Icon(Small ="ASPX16.GIF")]
	[ExportToNode("SPM2.SharePoint.Model.SPFormCollectionNode")]
	public partial class SPFormNode
	{
        public override void Setup(object spObject)
        {
            base.Setup(spObject);

            this.Text = this.Form.Url.Substring(this.Form.Url.LastIndexOf("/") + 1);
            this.ToolTipText = this.Form.Url;
            this.Url = this.Form.ParentList.ParentWeb.Url + "/" + this.Form.Url;
        }


        public override void LoadChildren()
        {
            base.LoadChildren();

            SPLimitedWebPartCollectionNode webparts = new SPLimitedWebPartCollectionNode(this.Form.ParentList.ParentWeb, this.Form.Url);

            webparts.Setup(this.SPObject);

            this.Children.Add(webparts);
        }

	}
}
