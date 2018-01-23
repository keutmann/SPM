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
	[Title(PropertyName="Title")]
    [Icon(Small = "MARR.GIF")]
	[ExportToNode("SPM2.SharePoint.Model.SPFieldCollectionNode")]
	public partial class SPFieldNode
	{
	}
}
