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
	[Title("SPGroup")]
    [Icon(Small="MARR.GIF")]
	[ExportToNode("SPM2.SharePoint.Model.SPGroupCollectionNode")]
	public partial class SPGroupNode : IViewRule
	{
        public bool IsVisible()
        {
            if (NodeProvider.ViewLevel >= 100)
                return true;

            return Parent is SPGroupCollectionNode;
        }
    }
}
