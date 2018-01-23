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
	[Title("Children")]
	[Icon(Small="BULLET.GIF")]
	[ExportToNode("SPM2.SharePoint.Model.SPNavigationNodeNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPNavigationNode")]
	public partial class SPNavigationNodeCollectionNode
	{
	}
}
