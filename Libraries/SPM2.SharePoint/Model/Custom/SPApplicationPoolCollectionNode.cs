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
	[Title("ApplicationPools")]
    [View(50)]
    [Icon(Small = "SPM2.SharePoint.Properties.Resources.AppPool", Source = IconSource.Assembly)]
	[ExportToNode("SPM2.SharePoint.Model.SPWebServiceNode")]
	public partial class SPApplicationPoolCollectionNode
	{
	}
}
