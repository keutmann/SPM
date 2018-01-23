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
	[Title("FeatureDefinitions")]
    [Icon(Small = "GenericFeature.gif")]
	[ExportToNode("SPM2.SharePoint.Model.SPSiteNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPFarmNode")]
	public partial class SPFeatureDefinitionCollectionNode
	{
        public SPFeatureDefinitionCollectionNode()
        {
            this.IconUri = SharePointContext.GetImagePath("GenericFeature.gif");
        }
	}
}
