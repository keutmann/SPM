/* ---------------------------
 * SharePoint Manager 2010 v2
 * Created by Carsten Keutmann
 * ---------------------------
 */

using System;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using SPM2.Framework;
using SPM2.SharePoint.Rules;

namespace SPM2.SharePoint.Model
{
	[Title(PropertyName="DisplayName")]
	[Icon(Small="BULLET.GIF")][View(100)]
	[ExportToNode("SPM2.SharePoint.Model.SPManagedAccountNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPServiceApplicationProxyGroupNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPServiceApplicationNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPApplicationPoolNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPDeveloperDashboardSettingsNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPUsageIdentityTableNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPUsageSettingsNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPFeatureDefinitionNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPWebServiceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPAlertTemplateNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPServiceInstanceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPOutboundMailServiceInstanceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPDocumentConverterNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPHttpThrottleSettingsNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPWebApplicationNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPJobDefinitionNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPServiceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPTimerServiceInstanceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPDatabaseNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPUsageReceiverDefinitionNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPUsageDefinitionNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPSolutionValidatorNode")]
	[ExportToNode("SPM2.SharePoint.Model.DataConnectionFileNode")]
	[ExportToNode("SPM2.SharePoint.Model.SessionStateDatabaseNode")]
	[ExportToNode("SPM2.SharePoint.Model.SessionStateServiceApplicationNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPServiceApplicationProxyNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPServiceProxyNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPPersistedFileNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPSolutionLanguagePackNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPSolutionNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPDiagnosticsProviderNode")]
	public partial class SPPersistedObjectNode : IViewRule
	{
        public bool IsVisible()
        {
            return false;
        }
    }
}
