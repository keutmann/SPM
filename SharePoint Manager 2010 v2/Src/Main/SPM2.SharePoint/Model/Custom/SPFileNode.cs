/* ---------------------------
 * SharePoint Manager 2010 v2
 * Created by Carsten Keutmann
 * ---------------------------
 */

using System;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using SPM2.Framework;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebPartPages;

namespace SPM2.SharePoint.Model
{
	[Title(PropertyName="Name")]
	[Icon(Small="BULLET.GIF")]
	[ExportToNode("SPM2.SharePoint.Model.SPListItemNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPFileCollectionNode")]
	//[ExportToNode("SPM2.SharePoint.Model.SPContextNode")]
	public partial class SPFileNode
	{

        public override void Setup(object spObject)
        {
            base.Setup(spObject);

            if (File != null)
            {
                if (this.File.Url.EndsWith(".aspx", StringComparison.OrdinalIgnoreCase))
                {
                    this.Url = SPUrlUtility.CombineUrl(this.File.ParentFolder.ParentWeb.Url, this.File.Url);
                }
                this.IconUri = SharePointContext.GetImagePath(this.File.IconUrl);
                this.Text = this.File.Name;
            }
        }

        public override void LoadChildren()
        {
            base.LoadChildren();
            if (File != null)
            {
                if (this.File.Url.EndsWith(".aspx", StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        SPLimitedWebPartCollectionNode webparts = new SPLimitedWebPartCollectionNode(this.File);

                        webparts.Setup(this.SPObject);

                        this.Children.Add(webparts);
                    }
                    catch
                    {
                        // Do nothing
                    }
                }
            }
        }
	}
}
