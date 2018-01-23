/* ---------------------------
 * SharePoint Manager 2010 v2
 * Created by Carsten Keutmann
 * ---------------------------
 */

using System;
using System.Linq;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using SPM2.Framework;
using System.Collections.Generic;

namespace SPM2.SharePoint.Model
{
	[Title("WebApplications")]
	[Icon(Small="BULLET.GIF")]
	[ExportToNode("SPM2.SharePoint.Model.SPWebServiceNode")]
	public partial class SPWebApplicationCollectionNode
	{
        public SPWebApplicationCollectionNode()
        {
            this.IconUri = GetResourceImagePath("GlobalServer.gif");
        }

        public override IEnumerable<SPNode> NodesToExpand()
        {
            return this.Children.OfType<SPWebApplicationNode>().Take(1).Cast<SPNode>();
        }

	}
}
