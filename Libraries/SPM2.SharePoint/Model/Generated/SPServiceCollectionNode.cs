/* ---------------------------
 * SharePoint Manager 2010 v2
 * Created by Carsten Keutmann
 * ---------------------------
 */

using System;

using Microsoft.SharePoint.Administration;
using SPM2.Framework;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SPM2.SharePoint.Model
{
	[AdapterItemType("Microsoft.SharePoint.Administration.SPServiceCollection, Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c")]
	public partial class SPServiceCollectionNode : SPNodeCollection
	{
        [XmlIgnore]
		public SPServiceCollection ServiceCollection
        {
            get
            {
                return (SPServiceCollection)this.SPObject;
            }
            set
            {
                this.SPObject = value;
            }
        }
    }
}
