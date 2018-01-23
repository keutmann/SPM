/* ---------------------------
 * SharePoint Manager 2010 v2
 * Created by Carsten Keutmann
 * ---------------------------
 */

using System;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using SPM2.Framework;

namespace SPM2.SharePoint.Model
{
	[Icon(Small="BULLET.GIF")]
	public partial class SPViewStyleNode
	{
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


        public override void Setup(object spObject)
        {
            base.Setup(spObject);
            this.Text = (String.IsNullOrEmpty(this.ViewStyle.Title)) ? "(Noname)" : this.ViewStyle.Title;
        }

	}
}
