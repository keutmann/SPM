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
	[Title("ReusableAcl")]
	[Icon(Small="BULLET.GIF")]
	[ExportToNode("SPM2.SharePoint.Model.SPItemNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPSecurableObjectNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPDocumentLibraryNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPListItemNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPListNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPWebNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPHealthRulesListNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPHealthReportsListNode")]
	public partial class SPReusableAclNode
	{
	}
}
