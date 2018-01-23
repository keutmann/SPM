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
    [Icon(Small = "SETTINGS.GIF")]
    [View(1)]
    //[ExportToNode("SPM2.SharePoint.Model.SPWebApplicationNode")]
    //[ExportToNode("SPM2.SharePoint.Model.SPAdministrationWebApplicationNode")]
    //[ExportToNode("SPM2.SharePoint.Model.SPWebServiceInstanceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPServiceCollectionNode")]
	public partial class SPWebServiceNode
	{
        public bool IsAdministrationService
        {
            get
            {
                return this.WebService == SPWebService.AdministrationService;
            }
        }
	}
}
