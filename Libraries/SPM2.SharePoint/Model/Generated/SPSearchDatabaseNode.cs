/* ---------------------------
 * SharePoint Manager 2010 v2
 * Created by Carsten Keutmann
 * ---------------------------
 */

using System;
using System.Xml.Serialization;
using Microsoft.SharePoint.Search.Administration;
using SPM2.Framework;

namespace SPM2.SharePoint.Model
{
	[AdapterItemType("Microsoft.SharePoint.Search.Administration.SPSearchDatabase, Microsoft.SharePoint.Search, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c")]
	public partial class SPSearchDatabaseNode : SPNode
	{
        [XmlIgnore]
		public SPSearchDatabase SearchDatabase
        {
            get
            {
                return (SPSearchDatabase)this.SPObject;
            }
            set
            {
                this.SPObject = value;
            }
        }
	}
}
