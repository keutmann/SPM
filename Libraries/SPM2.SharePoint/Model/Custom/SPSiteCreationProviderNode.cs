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
	[Title("SiteCreationProvider")]
	[Icon(Small="BULLET.GIF")][View(100)]
	[ExportToNode("SPM2.SharePoint.Model.SPWebServiceNode")]
	public partial class SPSiteCreationProviderNode : IViewRule
	{
        public bool IsVisible()
        {
            var service = Parent as SPWebServiceNode;

            return !service.IsAdministrationService;
        }
    }
}
