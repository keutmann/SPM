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
	[Title(PropertyName="DisplayName")]
	[Icon(Small="BULLET.GIF")][View(1)]
	[ExportToNode("SPM2.SharePoint.Model.SPContentDatabaseNode")]
	public partial class SPAdministrationWebApplicationNode
	{
	}
}
