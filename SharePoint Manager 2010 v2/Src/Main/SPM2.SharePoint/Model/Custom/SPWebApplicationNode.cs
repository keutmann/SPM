/* ---------------------------
 * SharePoint Manager 2010 v2
 * Created by Carsten Keutmann
 * ---------------------------
 */

using System;
using System.Linq;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using SPM2.Framework;
using System.Collections.Generic;

namespace SPM2.SharePoint.Model
{
    [Title(PropertyName = "DisplayName")]
    [ExportToNode("SPM2.SharePoint.Model.SPJobDefinitionNode")]
    [ExportToNode("SPM2.SharePoint.Model.SPWebApplicationCollectionNode")]
    [ExportToNode("SPM2.SharePoint.Model.SPDiagnosticsBlockingQueryProviderNode")]
    [ExportToNode("SPM2.SharePoint.Model.SPDiagnosticsSqlDmvProviderNode")]
    [ExportToNode("SPM2.SharePoint.Model.SPDiagnosticsULSProviderNode")]
    [ExportToNode("SPM2.SharePoint.Model.SPDatabaseServerDiagnosticsPerformanceCounterProviderNode")]
    [ExportToNode("SPM2.SharePoint.Model.SPWebFrontEndDiagnosticsPerformanceCounterProviderNode")]
    [ExportToNode("SPM2.SharePoint.Model.SPDiagnosticsEventLogProviderNode")]
    [ExportToNode("SPM2.SharePoint.Model.SPDiagnosticsSqlMemoryProviderNode")]
    [ExportToNode("SPM2.SharePoint.Model.SPDiagnosticsProviderNode")]
    public partial class SPWebApplicationNode
    {
        public SPWebApplicationNode()
        {
            this.IconUri = GetResourceImagePath("Internet.gif");
        }


        public override IEnumerable<SPNode> NodesToExpand()
        {
            return this.Children.OfType<SPSiteCollectionNode>().Take(1).Cast<SPNode>();
        }

    }
}
