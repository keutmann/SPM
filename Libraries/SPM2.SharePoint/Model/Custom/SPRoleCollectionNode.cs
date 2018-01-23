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
	[Title("Roles")]
	[Icon(Small="BULLET.GIF")][View(100)]
	[ExportToNode("SPM2.SharePoint.Model.SPPrincipalNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPWebNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPGroupNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPUserNode")]
	public partial class SPRoleCollectionNode
	{
	}
}
