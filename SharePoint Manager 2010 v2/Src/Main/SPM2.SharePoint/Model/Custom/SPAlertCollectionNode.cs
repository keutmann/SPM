/* ---------------------------
 * SharePoint Manager 2010 v2
 * Created by Carsten Keutmann
 * ---------------------------
 */

using System;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using SPM2.Framework;
using System.IO;

namespace SPM2.SharePoint.Model
{
	[Title("Alerts")]
	[Icon(Small="BULLET.GIF")]
	[ExportToNode("SPM2.SharePoint.Model.SPWebNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPUserNode")]
	public partial class SPAlertCollectionNode
	{
        public SPAlertCollectionNode()
        {
            this.IconUri = SharePointContext.GetImagePath("AIF16.GIF");
        }
	}
}
