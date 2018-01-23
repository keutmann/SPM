/* ---------------------------
 * SharePoint Manager 2010 v2
 * Created by Carsten Keutmann
 * ---------------------------
 */

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using SPM2.Framework;
using SPM2.SharePoint.Rules;

namespace SPM2.SharePoint.Model
{
    [Icon(Small = "Folder.gif")]
    [View(50)]
	[ExportToNode("SPM2.SharePoint.Model.SPFolderCollectionNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPMobileContextNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPListNode")]
    [ExportToNode(typeof(SPDocumentLibraryNode))]
    [ExportToNode("SPM2.SharePoint.Model.SPWebNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPHealthRulesListNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPHealthReportsListNode")]
    [ExportToNode("SPM2.SharePoint.Model.SPContentTypeNode")]
    [RecursiveRule(IsRecursiveVisible = true)]
    public partial class SPFolderNode : IRecursiveRule, IViewRule
	{
        public override void LoadChildren()
        {
            var nodes = new List<ISPNode>(NodeProvider.LoadChildren(this));
            var folders = nodes.OfType<SPFolderCollectionNode>().FirstOrDefault();
            if (folders != null)
            {
                Children.AddRange(NodeProvider.LoadCollectionChildren(folders, int.MaxValue));
                nodes.Remove(folders);
            }

            var files = nodes.OfType<SPFileCollectionNode>().FirstOrDefault();
            if (files != null)
            {
                Children.AddRange(NodeProvider.LoadCollectionChildren(files, int.MaxValue));
                nodes.Remove(files);
            }

            Children.AddRange(nodes);
        }

        public bool IsRecursiveVisible()
        {
            if (this.Parent.SPObjectType.IsOfType(typeof(SPFolderCollection)))
                return true;

            return false;
        }

        public bool IsVisible()
        {
            return !(ParentPropertyDescriptor.Name == "ParentFolder");
        }
    }

}
