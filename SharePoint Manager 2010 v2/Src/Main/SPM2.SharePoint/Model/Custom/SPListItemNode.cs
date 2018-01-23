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
    [Icon(Small = "TFALLT.GIF")]
	[ExportToNode("SPM2.SharePoint.Model.SPContextNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPListItemCollectionNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPListItemVersionNode")]
	[ExportToNode("SPM2.SharePoint.Model.BaseFieldControlNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPMobileBaseFieldControlNode")]
    [ExportToNode(typeof(SPFileNode))]
	public partial class SPListItemNode
	{

	}
}
