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
    [Title("Lists")]
    [Icon(Small = "BULLET.GIF")]
    [ExportToNode("SPM2.SharePoint.Model.SPWebNode")]
    [ExportToNode("SPM2.SharePoint.Model.SPHealthRulesListNode")]
    [ExportToNode("SPM2.SharePoint.Model.SPHealthReportsListNode")]
    public partial class SPListCollectionNode
    {

        public SPListCollectionNode()
        {
            this.IconUri = SharePointContext.GetImagePath("itgen.GIF");
        }

    }
}
