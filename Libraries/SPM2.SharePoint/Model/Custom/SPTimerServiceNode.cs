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
	[ExportToNode("SPM2.SharePoint.Model.SPServiceCollectionNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPFarmNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPDiagnosticsBlockingQueryProviderNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPDiagnosticsSqlDmvProviderNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPDiagnosticsULSProviderNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPDatabaseServerDiagnosticsPerformanceCounterProviderNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPWebFrontEndDiagnosticsPerformanceCounterProviderNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPDiagnosticsEventLogProviderNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPDiagnosticsSqlMemoryProviderNode")]
	public partial class SPTimerServiceNode
	{
	}
}
