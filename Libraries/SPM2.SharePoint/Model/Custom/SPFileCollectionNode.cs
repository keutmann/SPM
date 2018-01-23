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
	[Title("Files")]
    [Icon(Small = "ITS16.GIF")]
	[ExportToNode("SPM2.SharePoint.Model.SPFolderNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPWebNode")]
    [View(50)]
	public partial class SPFileCollectionNode : IViewRule
	{


        public override void Setup(ISPNode parent)
        {
            base.Setup(parent);

            if(SPObject != null)
                Text += String.Format(" ({0})", FileCollection.Count);
        }

        public override void LoadChildren()
        {
            var settings = NodeProvider.IoCContainer.Resolve<SPExplorerSettings>();
            Children.AddRange(NodeProvider.LoadCollectionChildren(this, settings.BatchNodeLoad));
        }

        public bool IsVisible()
        {
            if (NodeProvider.ViewLevel >= 100)
                return true;

            return !(Parent.SPObject is SPWeb);
        }
    }
}
