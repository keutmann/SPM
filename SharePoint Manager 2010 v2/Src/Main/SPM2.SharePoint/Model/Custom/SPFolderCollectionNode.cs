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
	[Title("Folders")]
    [Icon(Small = "Folder.gif")]
	[ExportToNode("SPM2.SharePoint.Model.SPFolderNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPWebNode")]
	public partial class SPFolderCollectionNode
	{
        public override void Setup(object spObject)
        {
            base.Setup(spObject);
        }
	}
}
