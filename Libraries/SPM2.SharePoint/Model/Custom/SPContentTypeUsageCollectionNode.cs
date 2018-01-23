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

        public override void Setup(ISPNode parent)
        {
            base.Setup(parent);

            this.Text = "ContentTypeUsages";
            ToolTipText = this.GetType().Name;
        }

        public override object GetSPObject()
        {
            return SPContentTypeUsage.GetUsages((SPContentType)Parent.SPObject);
        }
	}
}
