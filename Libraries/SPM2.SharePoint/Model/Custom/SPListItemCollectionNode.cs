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
	[Title("ListItems")]
    [Icon(Small = "list.gif")]
    [ExportToNode("SPM2.SharePoint.Model.SPDocumentLibraryNode", AutoBind = true)]
	[ExportToNode("SPM2.SharePoint.Model.SPListNode", AutoBind=true)]
	[ExportToNode("SPM2.SharePoint.Model.SPHealthRulesListNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPHealthReportsListNode")]
	public partial class SPListItemCollectionNode : IViewRule
	{

        public override object GetSPObject()
        {
            if (Parent.SPObject is SPList)
            {
                var list = (SPList)Parent.SPObject;
                var model = new SPListItemCollectionModel(list);
                return model;
            }

            return base.GetSPObject();
        }

        public override void LoadChildren()
        {
            var settings = NodeProvider.IoCContainer.Resolve<SPExplorerSettings>();
            Children.AddRange(NodeProvider.LoadCollectionChildren(this, settings.BatchNodeLoad));
        }

        public bool IsVisible()
        {
            if (ParentPropertyDescriptor.Name == "Folders")
                return false;

            return true;
        }
    }
}
