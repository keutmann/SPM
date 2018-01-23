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
	[Title("SystemAccount")]
    [Icon(Small = "ULS16.GIF")]
	[ExportToNode("SPM2.SharePoint.Model.SPSiteNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPUserCollectionNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPHealthRulesListNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPHealthReportsListNode")]
	public partial class SPUserNode : IViewRule
	{
        public bool IsVisible()
        {
            if (NodeProvider.ViewLevel >= 100)
                return true;

            return Parent is SPUserCollectionNode;
        }
    }
}
