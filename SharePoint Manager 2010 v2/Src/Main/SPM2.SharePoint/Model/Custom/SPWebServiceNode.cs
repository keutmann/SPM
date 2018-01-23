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
using System.Collections.Generic;

namespace SPM2.SharePoint.Model
{
	[Title(PropertyName="DisplayName")]
    //[ExportToNode("SPM2.SharePoint.Model.SPWebApplicationNode")]
    //[ExportToNode("SPM2.SharePoint.Model.SPAdministrationWebApplicationNode")]
    //[ExportToNode("SPM2.SharePoint.Model.SPWebServiceInstanceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPServiceCollectionNode")]
	public partial class SPWebServiceNode
	{
        public SPWebServiceNode()
        {
            this.IconUri = SharePointContext.GetImagePath("SETTINGS.GIF");
        }

        public bool IsAdministrationService
        {
            get
            {
                return this.WebService == SPWebService.AdministrationService;
            }
        }

        public override IEnumerable<SPNode> NodesToExpand()
        {
            return this.Children.OfType<SPWebApplicationCollectionNode>().Cast<SPNode>();
        }

	}
}
