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
	[Title("Receivers")]
	[Icon(Small="BULLET.GIF")]
	[ExportToNode("SPM2.SharePoint.Model.SPImportUsageDefinitionNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPClickthroughUsageDefinitionNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPExportUsageDefinitionNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPRequestUsageDefinitionNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPFeatureUsageDefinitionNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPQueryUsageDefinitionNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPSiteInventoryUsageProviderNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPTimerJobUsageDefinitionNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPRatingUsageDefinitionNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPUsageDefinitionNode")]
	public partial class SPUsageReceiverDefinitionCollectionNode
	{
	}
}
