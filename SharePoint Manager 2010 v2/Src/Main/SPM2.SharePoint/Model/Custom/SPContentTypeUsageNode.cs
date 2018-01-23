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
    [ExportToNode("SPM2.SharePoint.Model.SPContentTypeUsageCollectionNode")]
	public partial class SPContentTypeUsageNode
	{

        public SPContentTypeUsageNode()
        {
            //this.IconUri = SharePointContext.GetImagePath("MARR.GIF");
        }

        public override void Setup(object spParent)
        {
            base.Setup(spParent);
            this.Text = ContentTypeUsage.Url;
        }

    }
}
