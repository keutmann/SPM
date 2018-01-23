/* ---------------------------
 * SharePoint Manager 2010 v2
 * Created by Carsten Keutmann
 * ---------------------------
 */

using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Utilities;
using SPM2.Framework;

namespace SPM2.SharePoint.Model
{
    [Title("Lists")]
    [Icon(Small = "itgen.GIF")]
    [View(1)]
    [ExportToNode("SPM2.SharePoint.Model.SPWebNode")]
    [ExportToNode("SPM2.SharePoint.Model.SPHealthRulesListNode")]
    [ExportToNode("SPM2.SharePoint.Model.SPHealthReportsListNode")]
    public partial class SPListCollectionNode
    {
        public override void Setup(ISPNode parent)
        {
            base.Setup(parent);

            this.Url =  SPUrlUtility.CombineUrl( this.ListCollection.Web.Url, "_layouts/15/viewlsts.aspx");
        }
    }
}
