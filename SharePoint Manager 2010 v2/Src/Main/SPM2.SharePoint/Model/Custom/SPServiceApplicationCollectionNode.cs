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
	[Title("Applications")]
	[Icon(Small="BULLET.GIF")]
	[ExportToNode("SPM2.SharePoint.Model.SPServiceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPWebServiceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPDatabaseServiceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPSearchServiceNode")]
	[ExportToNode("SPM2.SharePoint.Model.PolicyConfigServiceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SearchServiceNode")]
	[ExportToNode("SPM2.SharePoint.Model.MetadataWebServiceNode")]
	[ExportToNode("SPM2.SharePoint.Model.ProfileSynchronizationServiceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPUsageServiceNode")]
	[ExportToNode("SPM2.SharePoint.Model.BdcServiceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SearchAdminWebServiceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SecureStoreServiceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPWindowsTokenServiceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPTracingServiceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPWorkflowTimerServiceNode")]
	[ExportToNode("SPM2.SharePoint.Model.BIMonitoringServiceNode")]
	[ExportToNode("SPM2.SharePoint.Model.ApplicationRegistryServiceNode")]
	[ExportToNode("SPM2.SharePoint.Model.OfficeServerServiceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPUserCodeServiceNode")]
	[ExportToNode("SPM2.SharePoint.Model.PortalServiceNode")]
	[ExportToNode("SPM2.SharePoint.Model.VisioGraphicsServiceNode")]
	[ExportToNode("SPM2.SharePoint.Model.LauncherServiceNode")]
	[ExportToNode("SPM2.SharePoint.Model.LoadBalancerServiceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SearchQueryAndSiteSettingsServiceNode")]
	[ExportToNode("SPM2.SharePoint.Model.WebAnalyticsWebServiceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPSecurityTokenServiceNode")]
	[ExportToNode("SPM2.SharePoint.Model.ExcelServerWebServiceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPIncomingEmailServiceNode")]
	[ExportToNode("SPM2.SharePoint.Model.UserProfileServiceNode")]
	[ExportToNode("SPM2.SharePoint.Model.AccessServerWebServiceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPSubscriptionSettingsServiceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPAdministrationServiceNode")]
	[ExportToNode("SPM2.SharePoint.Model.NotesWebServiceNode")]
	[ExportToNode("SPM2.SharePoint.Model.WebAnalyticsServiceNode")]
	[ExportToNode("SPM2.SharePoint.Model.WordServiceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPTopologyWebServiceNode")]
	[ExportToNode("SPM2.SharePoint.Model.FormsServiceNode")]
	[ExportToNode("SPM2.SharePoint.Model.StateServiceNode")]
	[ExportToNode("SPM2.SharePoint.Model.DiagnosticsServiceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPTimerServiceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPOutboundMailServiceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SessionStateServiceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPDiagnosticsServiceNode")]
	public partial class SPServiceApplicationCollectionNode
	{
	}
}
