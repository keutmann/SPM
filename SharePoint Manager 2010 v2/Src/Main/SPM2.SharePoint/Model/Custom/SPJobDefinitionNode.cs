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
	[Title(PropertyName="DisplayName")]
	[ExportToNode("SPM2.SharePoint.Model.SPJobDefinitionCollectionNode")]
	public partial class SPJobDefinitionNode
	{

        public SPJobDefinitionNode()
        {
            this.IconUri = SharePointContext.GetImagePath("MARR.GIF");
        }
	}
}
