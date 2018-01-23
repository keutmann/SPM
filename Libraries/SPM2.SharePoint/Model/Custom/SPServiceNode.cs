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
    [Icon("SETTINGS.GIF")]
	[Title(PropertyName="DisplayName")]
    [View(100)]
	[ExportToNode("SPM2.SharePoint.Model.SPTimerServiceInstanceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SessionStateServiceApplicationNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPServiceCollectionNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPDiagnosticsProviderNode")]
	public partial class SPServiceNode
	{
	}
}
