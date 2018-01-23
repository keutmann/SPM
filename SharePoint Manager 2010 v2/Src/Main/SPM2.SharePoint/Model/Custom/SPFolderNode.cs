/* ---------------------------
 * SharePoint Manager 2010 v2
 * Created by Carsten Keutmann
 * ---------------------------
 */

using System;
using System.Linq;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using SPM2.Framework;

namespace SPM2.SharePoint.Model
{
    [Icon(Small = "Folder.gif")]
	[ExportToNode("SPM2.SharePoint.Model.SPFolderCollectionNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPMobileContextNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPListNode")]
    [ExportToNode(typeof(SPDocumentLibraryNode))]
    [ExportToNode("SPM2.SharePoint.Model.SPWebNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPHealthRulesListNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPHealthReportsListNode")]
    //[ExportToNode("SPM2.SharePoint.Model.SPFileNode")]
    //[ExportToNode("SPM2.SharePoint.Model.SPListItemNode")]
    public partial class SPFolderNode
	{

        public override void Setup(object spObject)
        {
            base.Setup(spObject);

            this.Text = this.Folder.Name;
        }


        public override void LoadChildren()
        {
            base.LoadChildren();

            SPFileCollectionNode files = this.Children.OfType<SPFileCollectionNode>().FirstOrDefault();
            if (files != null)
            {
                this.Children.Remove(files);

                files.LoadChildren();

                this.Children.InsertRange(0, files.Children);
            }

            SPFolderCollectionNode folderCollection = this.Children.OfType<SPFolderCollectionNode>().FirstOrDefault();
            if (folderCollection != null)
            {
                this.Children.Remove(folderCollection);
                
                folderCollection.LoadChildren();

                this.Children.InsertRange(0, folderCollection.Children);
            }
        }

	}

}
