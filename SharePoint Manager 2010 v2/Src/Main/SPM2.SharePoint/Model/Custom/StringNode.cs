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
	[Title("String")]
	[Icon(Small="BULLET.GIF")]
	[ExportToNode("SPM2.SharePoint.Model.SPViewFieldCollectionNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPMimeTypeSetNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPFileExtensionsCollectionNode")]
	public partial class StringNode
	{
	}
}
