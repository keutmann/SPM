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
using System.Collections;

namespace SPM2.SharePoint.Model
{
	[Title("Sites")]
    [Icon(Small = "coll_site.gif")]
	[ExportToNode("SPM2.SharePoint.Model.SPWebApplicationNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPAdministrationWebApplicationNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPContentDatabaseNode")]
	public partial class SPSiteCollectionNode
	{
        public override void LoadChildren()
        {
            var settings = NodeProvider.IoCContainer.Resolve<SPExplorerSettings>();
            Children.AddRange(NodeProvider.LoadCollectionChildren(this, settings.BatchNodeLoad));
       }
    }
}
