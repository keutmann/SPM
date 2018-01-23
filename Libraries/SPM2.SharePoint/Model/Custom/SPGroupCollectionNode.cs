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
	[Title("Groups")]
    [Icon(Small = "MYSHRPTS.GIF")]
	[ExportToNode("SPM2.SharePoint.Model.SPUserNode")]
    [View(50)]
	public partial class SPGroupCollectionNode : IViewRule
	{

        public bool IsVisible()
        {
            if (NodeProvider.ViewLevel >= 100)
                return true;

            if (Parent.SPObject is SPWeb)
            {
                var web = (SPWeb)Parent.SPObject;
                if (web.IsRootWeb && ParentPropertyDescriptor.Name != "Groups")
                    return false;

                if (!web.IsRootWeb && ParentPropertyDescriptor.Name == "SiteGroups")
                    return false;
            }
            return true;
        }
    }
}
