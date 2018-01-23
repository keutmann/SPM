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
	[Title("Folders")]
    [Icon(Small = "Folder.gif")]
    [View(50)]
	[ExportToNode("SPM2.SharePoint.Model.SPFolderNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPWebNode")]
	public partial class SPFolderCollectionNode : IViewRule, IRecursiveRule
	{
        public override void Setup(ISPNode parent)
        {
            base.Setup(parent);

            if (SPObject != null)
                Text += String.Format(" ({0})", FolderCollection.Count);
        }

        public bool IsVisible()
        {
            if (NodeProvider.ViewLevel >= 100)
                return true;

            if (ParentPropertyDescriptor != null && Parent is SPFolderNode)
                return true;

            return false;
        }

        public bool IsRecursiveVisible()
        {
            return true;
        }
    }
}
