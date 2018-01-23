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
	[Title("Sites")]
    [Icon(Small = "coll_site.gif")]
	[ExportToNode("SPM2.SharePoint.Model.SPWebApplicationNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPAdministrationWebApplicationNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPContentDatabaseNode")]
	public partial class SPSiteCollectionNode
	{
        public override IEnumerable<SPNode> NodesToExpand()
        {
            return this.Children.OfType<SPSiteNode>().Take(1).Cast<SPNode>();
        }

	}
}
