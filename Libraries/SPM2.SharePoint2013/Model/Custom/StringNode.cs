/* ---------------------------
 * SharePoint Manager 2010 v2
 * Created by Carsten Keutmann
 * ---------------------------
 */

using System;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using SPM2.Framework;
using SPM2.SharePoint.Model;

namespace SPM2.SharePoint2013.Model
{

    [Icon(Small = Icons2013.DefaultSmall)]
    [View(100)]
    [ExportToNode("SPM2.SharePoint2013.Model.SPScriptSafeDomainsCollectionNode")]
    [ExportToNode("SPM2.SharePoint2013.Model.SPScriptSafePagesCollectionNode")]
    public partial class StringNode
	{
        public override void Setup(ISPNode parent)
        {
            base.Setup(parent);

            Text = this.SPObject as string;
            if (String.IsNullOrEmpty(Text))
            {
                Text = "(Empty)";
            }
        }
	}
}
