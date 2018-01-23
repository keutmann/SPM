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

namespace SPM2.SharePoint.Model
{
    [Icon(Small = "icon-property.gif", Source=IconSource.Assembly)]
    [ExportToNode("SPM2.SharePoint.Model.SPPropertyCollectionNode")]
    [AdapterItemType("System.Collections.DictionaryEntry")]
	public partial class SPPropertyNode : SPNode
	{


        public DictionaryEntry Entry
        {
            get { return (DictionaryEntry)this.SPObject; }
            set { this.SPObject = value; }
        }


        public override void Setup(object spParent)
        {
            base.Setup(spParent);

            this.Text = this.Entry.Key.ToString();

            // Remove the "Expand" icon from the Property, because the will never be children to this object.
            //this.IsExpanded = true;
        }

        public override void LoadChildren()
        {
            // Do nothing!
        }

	}
}
