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
	[AdapterItemType("Microsoft.SharePoint.Administration.SPSolutionCollection, Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c")]
	public partial class SPSolutionCollectionNode : SPNodeCollection
	{
        [XmlIgnore]
		public SPSolutionCollection SolutionCollection
        {
            get
            {
                return (SPSolutionCollection)this.SPObject;
            }
            set
            {
                this.SPObject = value;
            }
        }
	}
}
