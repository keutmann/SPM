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
	[Title("ManageLink")]
	[Icon(Small="BULLET.GIF")]
	[ExportToNode("SPM2.SharePoint.Model.SPServiceApplicationNode")]
	[ExportToNode("SPM2.SharePoint.Model.SessionStateServiceApplicationNode")]
	[ExportToNode("SPM2.SharePoint.Model.BdcServiceApplicationProxyNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPServiceApplicationProxyNode")]
	public partial class SPAdministrationLinkNode
	{
	}
}
