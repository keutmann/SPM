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
	[Title(PropertyName="DisplayName")]
	[Icon(Small="BULLET.GIF")]
	[ExportToNode("SPM2.SharePoint.Model.SPServiceApplicationNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPWebApplicationNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPAdministrationWebApplicationNode")]
	[ExportToNode("SPM2.SharePoint.Model.SessionStateServiceApplicationNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPServiceApplicationProxyGroupCollectionNode")]
	public partial class SPServiceApplicationProxyGroupNode
	{
	}
}
