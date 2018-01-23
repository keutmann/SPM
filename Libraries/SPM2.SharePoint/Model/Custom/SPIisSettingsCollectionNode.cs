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
    [View(50)]
	public partial class SPIisSettingsCollectionNode
	{

        public override void Setup(ISPNode parent)
        {
            base.Setup(parent);

            Text = "IisSettings";
        }

        public override void LoadChildren()
        {
            foreach (var item in this.Collection)
            {
                SPUrlZone zone = item.Key;
                var iisSettings = item.Value;
                var node = new SPIisSettingsNode();
                var index = this.Children.Count;
                node.NodeProvider = this.NodeProvider;
                node.SPObjectType = iisSettings.GetType();
                node.SPObject = iisSettings;
                node.ID = iisSettings.GetType().FullName + index;
                node.Index = index;
                node.Setup(this);
                node.Text = zone.ToString();

                this.Children.Add(node);
            }
        }
	}
}
