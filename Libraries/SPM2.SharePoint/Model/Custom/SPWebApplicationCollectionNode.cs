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
	[Title("WebApplications")]
    [Icon(Small = "SPM2.SharePoint.Properties.Resources.GlobalServer", Source = IconSource.Assembly)]
    [View(1)]
    [ExportToNode("SPM2.SharePoint.Model.SPWebServiceNode")]
	public partial class SPWebApplicationCollectionNode
	{
	}
}
