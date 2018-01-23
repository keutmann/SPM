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
	[Title("SPRoleDefinition")]
    [Icon(Small = "MARR.GIF")]
	[ExportToNode("SPM2.SharePoint.Model.SPRoleDefinitionBindingCollectionNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPRoleDefinitionCollectionNode")]
	public partial class SPRoleDefinitionNode
	{
	}
}
