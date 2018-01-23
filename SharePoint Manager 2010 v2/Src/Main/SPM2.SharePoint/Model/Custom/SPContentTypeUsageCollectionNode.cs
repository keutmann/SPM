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
	public partial class SPContentTypeUsageCollectionNode
	{
        public SPContentTypeUsageCollectionNode()
        {
        }

        public override void Setup(object spParent)
        {
            base.Setup(spParent);

            this.Text = "ContentTypeUsages";
            
        }

        public override object GetSPObject()
        {
            return SPContentTypeUsage.GetUsages((SPContentType)this.SPParent);
        }
	}
}
