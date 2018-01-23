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
    [AdapterItemType("Microsoft.SharePoint.Administration.SPIisSettings, Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c")]
    public partial class SPIisSettingsNode : SPNode
	{
        [XmlIgnore]
        public SPIisSettings IisSettings
        {
            get
            {
                return (SPIisSettings)this.SPObject;
            }
            set
            {
                this.SPObject = value;
            }
        }
	}
}
