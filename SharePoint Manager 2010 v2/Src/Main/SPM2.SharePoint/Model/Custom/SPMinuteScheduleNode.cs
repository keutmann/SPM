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
	[Title("InitialSweepSchedule")]
	[Icon(Small="BULLET.GIF")]
	[ExportToNode("SPM2.SharePoint.Model.SPTimerServiceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPDiagnosticsSqlDmvProviderNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPDiagnosticsULSProviderNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPDatabaseServerDiagnosticsPerformanceCounterProviderNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPWebFrontEndDiagnosticsPerformanceCounterProviderNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPDiagnosticsEventLogProviderNode")]
	public partial class SPMinuteScheduleNode
	{
	}
}
