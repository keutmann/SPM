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
using SPM2.Framework.ComponentModel;
using System.Collections.Generic;

namespace SPM2.SharePoint.Model
{
	[Title(PropertyName="DisplayName")]
    [Icon(Small = "SPM2.SharePoint.Properties.Resources.actionssettings", Source = IconSource.Assembly)]
    [View(1)]
	public partial class SPFarmNode
	{
        public override void Setup(ISPNode parent)
        {
            base.Setup(parent);
            if (String.IsNullOrEmpty(this.Url))
            {
                var webapp = SPAdministrationWebApplication.Local;
                if (webapp.Sites.Count > 0)
                {
                    this.Url = webapp.Sites["/"].Url;
                }
            }
        }
	}
}
