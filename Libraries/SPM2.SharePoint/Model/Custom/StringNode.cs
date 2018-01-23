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
	
	[Icon(Small="BULLET.GIF")][View(100)]
	[ExportToNode("SPM2.SharePoint.Model.SPViewFieldCollectionNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPMimeTypeSetNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPFileExtensionsCollectionNode")]
	public partial class StringNode
	{
        public override void Setup(ISPNode parent)
        {
            base.Setup(parent);
            
            var val = this.SPObject as string;
            if (!String.IsNullOrEmpty(val))
            {
                Text += " ("+val+")";
            }
        }
	}
}
