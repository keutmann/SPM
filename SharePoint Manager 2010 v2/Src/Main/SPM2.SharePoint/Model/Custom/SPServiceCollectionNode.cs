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
	[Title("Services")]
    [Icon(Small = "SERVICES.GIF")]
	[ExportToNode("SPM2.SharePoint.Model.SPFarmNode")]
	public partial class SPServiceCollectionNode
	{
        public override IEnumerable<SPNode> NodesToExpand()
        {
            return this.Children.OfType<SPWebServiceNode>().Where(p => !p.IsAdministrationService).Cast<SPNode>();
        }
	}
}
