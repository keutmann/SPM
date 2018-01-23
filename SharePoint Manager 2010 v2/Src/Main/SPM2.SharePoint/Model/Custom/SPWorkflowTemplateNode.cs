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
	[Title("BaseTemplate")]
	[Icon(Small="BULLET.GIF")]
	[ExportToNode("SPM2.SharePoint.Model.SPWorkflowAssociationNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPWorkflowTemplateCollectionNode")]
	public partial class SPWorkflowTemplateNode
	{
	}
}
