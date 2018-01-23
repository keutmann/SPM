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
	[Icon(Small="BULLET.GIF")][View(100)]
	[ExportToNode("SPM2.SharePoint.Model.SPSearchServiceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPDatabaseServiceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SearchServiceNode")]
	[ExportToNode("SPM2.SharePoint.Model.ProfileSynchronizationServiceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPWindowsTokenServiceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPTracingServiceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPUserCodeServiceNode")]
	[ExportToNode("SPM2.SharePoint.Model.LauncherServiceNode")]
	[ExportToNode("SPM2.SharePoint.Model.LoadBalancerServiceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPAdministrationServiceNode")]
	[ExportToNode("SPM2.SharePoint.Model.WebAnalyticsServiceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPTimerServiceNode")]
	public partial class SPProcessIdentityNode
	{
	}
}
