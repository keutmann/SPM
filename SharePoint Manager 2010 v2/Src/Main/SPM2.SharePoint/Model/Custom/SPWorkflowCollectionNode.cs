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
	[Title("Workflows")]
    [Icon(Small = "workflows.gif")]
	[ExportToNode("SPM2.SharePoint.Model.SPListItemNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPWebNode")]
	public partial class SPWorkflowCollectionNode
	{
	}
}
