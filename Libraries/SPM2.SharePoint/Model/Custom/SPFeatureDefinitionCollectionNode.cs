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
	[Title("FeatureDefinitions")]
    [Icon(Small = "GenericFeature.gif")]
	[ExportToNode("SPM2.SharePoint.Model.SPSiteNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPFarmNode")]
	public partial class SPFeatureDefinitionCollectionNode : IViewRule
	{
        public bool IsVisible()
        {
            if (NodeProvider.ViewLevel >= 100)
                return true;

            return Parent is SPFarmNode;
        }
	}
}
