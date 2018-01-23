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
	[Title("ApplicationProxies")]
	[Icon(Small="BULLET.GIF")]
	[ExportToNode("SPM2.SharePoint.Model.BdcServiceProxyNode")]
	[ExportToNode("SPM2.SharePoint.Model.WordServiceProxyNode")]
	[ExportToNode("SPM2.SharePoint.Model.StateServiceProxyNode")]
	[ExportToNode("SPM2.SharePoint.Model.AccessServerWebServiceProxyNode")]
	[ExportToNode("SPM2.SharePoint.Model.ApplicationRegistryServiceProxyNode")]
	[ExportToNode("SPM2.SharePoint.Model.MetadataWebServiceProxyNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPSubscriptionSettingsServiceProxyNode")]
	[ExportToNode("SPM2.SharePoint.Model.BIMonitoringServiceProxyNode")]
	[ExportToNode("SPM2.SharePoint.Model.SecureStoreServiceProxyNode")]
	[ExportToNode("SPM2.SharePoint.Model.SearchQueryAndSiteSettingsServiceProxyNode")]
	[ExportToNode("SPM2.SharePoint.Model.WebAnalyticsServiceProxyNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPTopologyWebServiceProxyNode")]
	[ExportToNode("SPM2.SharePoint.Model.NotesWebServiceProxyNode")]
	[ExportToNode("SPM2.SharePoint.Model.UserProfileServiceProxyNode")]
	[ExportToNode("SPM2.SharePoint.Model.VisioGraphicsServiceProxyNode")]
	[ExportToNode("SPM2.SharePoint.Model.SearchServiceProxyNode")]
	[ExportToNode("SPM2.SharePoint.Model.ExcelServerWebServiceProxyNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPUsageServiceProxyNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPServiceProxyNode")]
	public partial class SPServiceApplicationProxyCollectionNode
	{
	}
}
