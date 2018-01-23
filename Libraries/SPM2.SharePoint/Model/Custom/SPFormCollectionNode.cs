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
	[Title("Forms")]
    [Icon(Small = "ASA16.GIF")]
    [View(50)]
	[ExportToNode("SPM2.SharePoint.Model.SPDocumentLibraryNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPListNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPHealthRulesListNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPHealthReportsListNode")]
	public partial class SPFormCollectionNode
	{
	}
}
