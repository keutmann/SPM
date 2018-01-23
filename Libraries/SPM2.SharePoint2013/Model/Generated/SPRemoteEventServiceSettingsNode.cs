/* ---------------------------
 * SharePoint Manager 2010 v2
 * Created by Carsten Keutmann
 * ---------------------------
 */

using System;

using Microsoft.SharePoint.Administration;
using SPM2.Framework; using SPM2.SharePoint.Model;

namespace SPM2.SharePoint2013.Model
{
	[AdapterItemType("Microsoft.SharePoint.Administration.SPRemoteEventServiceSettings, Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c")]
	public partial class SPRemoteEventServiceSettingsNode : SPNode
	{
		[System.Xml.Serialization.XmlIgnore]
        public SPRemoteEventServiceSettings RemoteEventServiceSettings
        {
            get
            {
                return (SPRemoteEventServiceSettings)this.SPObject;
            }
            set
            {
                this.SPObject = value;
            }
        }
	}
}
