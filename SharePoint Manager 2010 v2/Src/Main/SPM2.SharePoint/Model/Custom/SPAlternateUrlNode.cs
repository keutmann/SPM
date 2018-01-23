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
	[Title("AlternateUrl")]
	[Icon(Small="BULLET.GIF")]
	[ExportToNode("SPM2.SharePoint.Model.SPAlternateUrlCollectionManagerNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPAlternateUrlCollectionNode")]
	public partial class SPAlternateUrlNode
	{
	}
}
