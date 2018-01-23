/* ---------------------------
 * SharePoint Manager 2010 v2
 * Created by Carsten Keutmann
 * ---------------------------
 */

using System;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using SPM2.Framework;
using SPM2.SharePoint.Rules;

namespace SPM2.SharePoint.Model
{
	[Title("Webs")]
    [Icon(Small = "orgchange.png")]
    [View(1)]
	[ExportToNode("SPM2.SharePoint.Model.SPWebNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPSiteNode")]
    [RecursiveRule(IsRecursiveVisible=true)]
	public partial class SPWebCollectionNode
	{
	}
}
