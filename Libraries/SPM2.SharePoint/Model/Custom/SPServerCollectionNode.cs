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
	[Title("Servers")]
    [Icon(Small = "SPM2.SharePoint.Properties.Resources.server", Source = IconSource.Assembly)]
    [View(50)]
	[ExportToNode("SPM2.SharePoint.Model.SPFarmNode")]
	public partial class SPServerCollectionNode
	{
	}
}
