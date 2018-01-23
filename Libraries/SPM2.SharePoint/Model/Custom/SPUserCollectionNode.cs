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
	[Title("Users")]
    [Icon(Small = "MNGATT.GIF")]
    [View(50)]
	[ExportToNode("SPM2.SharePoint.Model.SPGroupNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPWebNode")]
	public partial class SPUserCollectionNode : IViewRule
	{
        public bool IsVisible()
        {
            if (NodeProvider.ViewLevel >= 100)
                return true;

            if (ParentPropertyDescriptor.Name == "Users")
                return true;

            return false;
        }
    }
}
