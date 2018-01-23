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
    [Title("SPAlternateUrlCollection")]
    [Icon(Small = "BULLET.GIF")][View(100)]
	[ExportToNode("SPM2.SharePoint.Model.SPAlternateUrlCollectionManagerNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPWebApplicationNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPAdministrationWebApplicationNode")]
	public partial class SPAlternateUrlCollectionNode
	{
        //protected override string GetTitle()
        //{
        //    // Just use the PropertyName
        //    return this.Text;
        //}
	}
}
