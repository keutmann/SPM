/* ---------------------------
 * SharePoint Manager 2010 v2
 * Created by Carsten Keutmann
 * ---------------------------
 */

using System;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using SPM2.Framework;
using System.Collections;
using System.Xml.Serialization;

namespace SPM2.SharePoint.Model
{
    [Icon(Small = "SPM2.SharePoint.Properties.Resources.icon_property", Source = IconSource.Assembly)]
    [ExportToNode("SPM2.SharePoint.Model.SPPropertyCollectionNode")]
    [AdapterItemType("System.Collections.DictionaryEntry")]
	public partial class SPPropertyNode : SPNode
	{

        [XmlIgnore]
        public DictionaryEntry Entry
        {
            get { return (DictionaryEntry)this.SPObject; }
            set { this.SPObject = value; }
        }


        public override void Setup(ISPNode parent)
        {
            base.Setup(parent);

            this.Text = this.Entry.Key.ToString();
        }


        public override bool HasChildren()
        {
            return false;
        }
	}
}
