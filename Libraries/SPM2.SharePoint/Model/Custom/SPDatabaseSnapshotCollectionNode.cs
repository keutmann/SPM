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
	[Title("Snapshots")]
	[Icon(Small="BULLET.GIF")][View(100)]
	[ExportToNode("SPM2.SharePoint.Model.StateDatabaseNode")]
	[ExportToNode("SPM2.SharePoint.Model.SecureStoreServiceDatabaseNode")]
	[ExportToNode("SPM2.SharePoint.Model.QueueDatabaseNode")]
	[ExportToNode("SPM2.SharePoint.Model.SocialDatabaseNode")]
	[ExportToNode("SPM2.SharePoint.Model.BdcServiceDatabaseNode")]
	[ExportToNode("SPM2.SharePoint.Model.WebAnalyticsStagerDatabaseNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPConfigurationDatabaseNode")]
	[ExportToNode("SPM2.SharePoint.Model.BIMonitoringServiceDatabaseNode")]
	[ExportToNode("SPM2.SharePoint.Model.SearchGathererDatabaseNode")]
	[ExportToNode("SPM2.SharePoint.Model.SearchPropertyStoreDatabaseNode")]
	[ExportToNode("SPM2.SharePoint.Model.ApplicationRegistryServiceDatabaseNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPContentDatabaseNode")]
	[ExportToNode("SPM2.SharePoint.Model.SearchAdminDatabaseNode")]
	[ExportToNode("SPM2.SharePoint.Model.MetadataWebServiceDatabaseNode")]
	[ExportToNode("SPM2.SharePoint.Model.ProfileDatabaseNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPUsageDatabaseNode")]
	[ExportToNode("SPM2.SharePoint.Model.SynchronizationDatabaseNode")]
	[ExportToNode("SPM2.SharePoint.Model.WebAnalyticsWarehouseDatabaseNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPDatabaseNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPSearchDatabaseNode")]
	[ExportToNode("SPM2.SharePoint.Model.SessionStateDatabaseNode")]
	public partial class SPDatabaseSnapshotCollectionNode
	{
	}
}
