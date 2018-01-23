/* ---------------------------
 * SharePoint Manager 2010 v2
 * Created by Carsten Keutmann
 * ---------------------------
 */

using System;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using SPM2.Framework;
using System.IO;

namespace SPM2.SharePoint.Model
{
	[Title(PropertyName="DisplayName")]
    [Icon(Small = "SPM2.SharePoint.Properties.Resources.server", Source = IconSource.Assembly)]
	[ExportToNode("SPM2.SharePoint.Model.SPServerCollectionNode")]
	[ExportToNode("SPM2.SharePoint.Model.SessionStateDatabaseNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPDiagnosticsBlockingQueryProviderNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPDiagnosticsSqlDmvProviderNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPDiagnosticsULSProviderNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPDatabaseServerDiagnosticsPerformanceCounterProviderNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPWebFrontEndDiagnosticsPerformanceCounterProviderNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPDiagnosticsEventLogProviderNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPDiagnosticsSqlMemoryProviderNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPDiagnosticsProviderNode")]
	public partial class SPServerNode
	{
	}
}
