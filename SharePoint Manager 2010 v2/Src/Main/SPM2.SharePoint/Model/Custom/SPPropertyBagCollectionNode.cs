/* ---------------------------
 * SharePoint Manager 2010 v2
 * Created by Carsten Keutmann
 * ---------------------------
 */

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SPM2.Framework;

namespace SPM2.SharePoint.Model
{
    [Title("PropertyBag")]
    [Icon(Small = "EXITGRID.GIF")]
    [ExportToNode("SPM2.SharePoint.Model.SPFarmNode")]
    [ExportToNode("SPM2.SharePoint.Model.SPWebNode")]
    [ExportToNode("SPM2.SharePoint.Model.SPFolderNode")]
    [ExportToNode("SPM2.SharePoint.Model.SPFileNode")]
    [ExportToNode("SPM2.SharePoint.Model.SPFileVersionNode")]
    [ExportToNode(typeof (SPListItemNode))]
    [ExportToNode(typeof (SPJobDefinitionNode))]
    [ExportToNode(typeof (SPServerNode))]
    [ExportToNode(typeof (SPServiceNode))]
    [ExportToNode(typeof (SPWebServiceNode))]
    [ExportToNode(typeof (SPSolutionNode))]
    public partial class SPPropertyBagCollectionNode
    {
        public override void LoadChildren()
        {
            var list = new List<ISPNode>();

            foreach (DictionaryEntry entry in PropertyBag)
            {
                var node = new SPPropertyNode();
                node.SPObject = entry;
                node.Setup(SPObject);
                list.Add(node);
            }

            Children.AddRange(list.OrderBy(p => p.Text));
        }
    }
}