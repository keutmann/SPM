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
	[Title("TitleResource")]
	[Icon(Small="BULLET.GIF")][View(100)]
    [ExportToNode("SPM2.SharePoint.Model.SPUserResourceCollectionNode")]
    //[ExportToNode("SPM2.SharePoint.Model.SPUserCustomActionNode")]
    //[ExportToNode("SPM2.SharePoint.Model.SPContentTypeNode")]
    //[ExportToNode("SPM2.SharePoint.Model.SPDocumentLibraryNode")]
    //[ExportToNode("SPM2.SharePoint.Model.SPFieldNode")]
    //[ExportToNode("SPM2.SharePoint.Model.SPListNode")]
    //[ExportToNode("SPM2.SharePoint.Model.SPWebNode")]
    //[ExportToNode("SPM2.SharePoint.Model.SPNavigationNodeNode")]
    //[ExportToNode("SPM2.SharePoint.Model.SPHealthRulesListNode")]
    //[ExportToNode("SPM2.SharePoint.Model.SPHealthReportsListNode")]
	public partial class SPUserResourceNode
	{
	}
}
