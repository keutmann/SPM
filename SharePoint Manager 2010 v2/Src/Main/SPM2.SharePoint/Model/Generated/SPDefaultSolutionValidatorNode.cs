/* ---------------------------
 * SharePoint Manager 2010 v2
 * Created by Carsten Keutmann
 * ---------------------------
 */

using System;

using Microsoft.SharePoint.UserCode;
using SPM2.Framework;

namespace SPM2.SharePoint.Model
{
	[AdapterItemType("Microsoft.SharePoint.UserCode.SPDefaultSolutionValidator, Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c")]
	public partial class SPDefaultSolutionValidatorNode : SPSolutionValidatorNode
	{
		public SPDefaultSolutionValidator DefaultSolutionValidator
        {
            get
            {
                return (SPDefaultSolutionValidator)this.SPObject;
            }
            set
            {
                this.SPObject = value;
            }
        }
	}
}
