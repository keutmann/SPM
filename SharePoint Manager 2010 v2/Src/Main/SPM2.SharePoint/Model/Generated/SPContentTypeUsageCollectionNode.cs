/* ---------------------------
 * SharePoint Manager 2010 v2
 * Created by Carsten Keutmann
 * ---------------------------
 */

using System;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using SPM2.Framework;
using System.Collections.Generic;

namespace SPM2.SharePoint.Model
{
	public partial class SPContentTypeUsageCollectionNode : SPNodeCollection
	{
        public IList<SPContentTypeUsage> ContentTypeUsageCollection
        {
            get
            {
                return (IList<SPContentTypeUsage>)this.SPObject;
            }
            set
            {
                this.SPObject = value;
            }
        }

	}
}
