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
	[Title("SPFileVersion")]
    [Icon(Small = "ICGEN.GIF")]
	[ExportToNode("SPM2.SharePoint.Model.SPFileVersionCollectionNode")]
	public partial class SPFileVersionNode
	{
        public override void LoadChildren()
        {
            base.LoadChildren();
        }
	}
}
