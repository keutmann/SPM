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
	[Title("FieldTypeDefinition")]
	[Icon(Small="BULLET.GIF")][View(100)]
	[ExportToNode("SPM2.SharePoint.Model.SPFieldNode")]
	public partial class SPFieldTypeDefinitionNode
	{
        public override void Setup(ISPNode parent)
        {
            base.Setup(parent);

            if (FieldTypeDefinition != null)
            {
                Text = FieldTypeDefinition.TypeDisplayName;
                ToolTipText = FieldTypeDefinition.TypeShortDescription;
            }
        }
	}
}
