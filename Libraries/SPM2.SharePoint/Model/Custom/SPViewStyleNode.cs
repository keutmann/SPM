/* ---------------------------
 * SharePoint Manager 2010 v2
 * Created by Carsten Keutmann
 * ---------------------------
 */

using System;
using System.Xml.Serialization;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using SPM2.Framework;

namespace SPM2.SharePoint.Model
{
	[Icon(Small="BULLET.GIF")][View(100)]
	public partial class SPViewStyleNode
	{
        [XmlIgnore]
        public SPViewStyle ViewStyle
        {
            get
            {
                return (SPViewStyle)this.SPObject;
            }
            set
            {
                this.SPObject = value;
            }
        }


        public override void Setup(ISPNode parent)
        {
            base.Setup(parent);
            this.Text = (String.IsNullOrEmpty(this.ViewStyle.Title)) ? "(Noname)" : this.ViewStyle.Title;
        }

	}
}
