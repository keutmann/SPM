/* ---------------------------
 * SharePoint Manager 2010 v2
 * Created by Carsten Keutmann
 * ---------------------------
 */

using System;
using System.Xml.Serialization;
using Microsoft.SharePoint.Administration;
using SPM2.Framework;

namespace SPM2.SharePoint.Model
{
	[AdapterItemType("Microsoft.SharePoint.Administration.SPPolicyCollection, Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c")]
	public partial class SPPolicyCollectionNode : SPNodeCollection
	{
        [XmlIgnore]
		public SPPolicyCollection PolicyCollection
        {
            get
            {
                return (SPPolicyCollection)this.SPObject;
            }
            set
            {
                this.SPObject = value;
            }
        }
	}
}
