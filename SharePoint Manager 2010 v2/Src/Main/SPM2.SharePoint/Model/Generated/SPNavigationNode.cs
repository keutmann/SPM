/* ---------------------------
 * SharePoint Manager 2010 v2
 * Created by Carsten Keutmann
 * ---------------------------
 */

using System;

using Microsoft.SharePoint.Navigation;
using SPM2.Framework;

namespace SPM2.SharePoint.Model
{
	[AdapterItemType("Microsoft.SharePoint.Navigation.SPNavigation, Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c")]
	public partial class SPNavigationNode : SPNode
	{
		public SPNavigation Navigation
        {
            get
            {
                return (SPNavigation)this.SPObject;
            }
            set
            {
                this.SPObject = value;
            }
        }
	}
}
