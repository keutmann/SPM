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
	[Icon(Small="BULLET.GIF")][View(100)]
	[ExportToNode("SPM2.SharePoint.Model.SPSearchServiceInstanceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPServiceInstanceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPOutboundMailServiceInstanceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPTimerServiceInstanceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPDatabaseServiceInstanceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPSearchDataAccessServiceInstanceNode")]
	[ExportToNode("SPM2.SharePoint.Model.PolicyConfigServiceInstanceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SearchDataAccessServiceInstanceNode")]
	[ExportToNode("SPM2.SharePoint.Model.MetadataWebServiceInstanceNode")]
	[ExportToNode("SPM2.SharePoint.Model.ProfileSynchronizationServiceInstanceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPUsageServiceInstanceNode")]
	[ExportToNode("SPM2.SharePoint.Model.BdcServiceInstanceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SearchAdminWebServiceInstanceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SecureStoreServiceInstanceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPWindowsTokenServiceInstanceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPTracingServiceInstanceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPWorkflowTimerServiceInstanceNode")]
	[ExportToNode("SPM2.SharePoint.Model.BIMonitoringServiceInstanceNode")]
	[ExportToNode("SPM2.SharePoint.Model.ApplicationRegistryServiceInstanceNode")]
	[ExportToNode("SPM2.SharePoint.Model.OfficeServerServiceInstanceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPUserCodeServiceInstanceNode")]
	[ExportToNode("SPM2.SharePoint.Model.PortalServiceInstanceNode")]
	[ExportToNode("SPM2.SharePoint.Model.VisioGraphicsServiceInstanceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SearchServiceInstanceNode")]
	[ExportToNode("SPM2.SharePoint.Model.LauncherServiceInstanceNode")]
	[ExportToNode("SPM2.SharePoint.Model.LoadBalancerServiceInstanceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SearchQueryAndSiteSettingsServiceInstanceNode")]
	[ExportToNode("SPM2.SharePoint.Model.WebAnalyticsWebServiceInstanceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPSecurityTokenServiceInstanceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPWebServiceInstanceNode")]
	[ExportToNode("SPM2.SharePoint.Model.ExcelServerWebServiceInstanceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPIncomingEmailServiceInstanceNode")]
	[ExportToNode("SPM2.SharePoint.Model.UserProfileServiceInstanceNode")]
	[ExportToNode("SPM2.SharePoint.Model.AccessServerWebServiceInstanceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPSubscriptionSettingsServiceInstanceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPAdministrationServiceInstanceNode")]
	[ExportToNode("SPM2.SharePoint.Model.NotesWebServiceInstanceNode")]
	[ExportToNode("SPM2.SharePoint.Model.WebAnalyticsServiceInstanceNode")]
	[ExportToNode("SPM2.SharePoint.Model.WordServiceInstanceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPTopologyWebServiceInstanceNode")]
	public partial class SPActionLinkNode
	{
	}
}
