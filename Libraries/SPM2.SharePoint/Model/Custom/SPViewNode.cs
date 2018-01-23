/* ---------------------------
 * SharePoint Manager 2010 v2
 * Created by Carsten Keutmann
 * ---------------------------
 */

using System;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using SPM2.Framework;
using Microsoft.SharePoint.Utilities;

namespace SPM2.SharePoint.Model
{
	[Title(PropertyName="Title")]
    [Icon(Small = "itgen.GIF")]
	[ExportToNode("SPM2.SharePoint.Model.SPViewCollectionNode")]
    //[ExportToNode("SPM2.SharePoint.Model.SPDocumentLibraryNode")]
    //[ExportToNode("SPM2.SharePoint.Model.SPViewContextNode")]
    //[ExportToNode("SPM2.SharePoint.Model.SPMobileContextNode")]
    //[ExportToNode("SPM2.SharePoint.Model.SPMobileBaseFieldControlNode")]
    //[ExportToNode("SPM2.SharePoint.Model.SPListNode")]
    //[ExportToNode("SPM2.SharePoint.Model.SPHealthRulesListNode")]
    //[ExportToNode("SPM2.SharePoint.Model.SPHealthReportsListNode")]
	public partial class SPViewNode
	{
        public override void Setup(ISPNode parent)
        {
            base.Setup(parent);

            this.Url = SPUrlUtility.CombineUrl(View.ParentList.ParentWeb.Url, View.Url);
        }
	}
}
