/* ---------------------------
 * SharePoint Manager 2010 v2
 * Created by Carsten Keutmann
 * ---------------------------
 */

using System;
using System.Linq;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using SPM2.Framework; using SPM2.SharePoint.Model;

namespace SPM2.SharePoint2013.Model
{
	[Title("PushNotificationSubscribers")]
	[Icon(Small = Icons2013.DefaultSmall)][View(100)]
	[ExportToNode("SPM2.SharePoint.Model.SPWebNode")]
	public partial class SPPushNotificationSubscriberCollectionNode
	{
        public readonly Guid PhonePNSubscriberID = new Guid("41e1d4bf-b1a2-47f7-ab80-d5d6cbba3092");


        public bool IsActivated
        {
            get
            {
                var web = Parent.SPObject as SPWeb;
                if (web == null) return false;
                return web.Features.Any<SPFeature>(p => p.DefinitionId == PhonePNSubscriberID);
            }
        }

        public override object GetSPObject()
        {
            // if the PhonePNSubscriber (Push Notifications) feature is not activated, then return null;
            if (!IsActivated)
                return null;
            
            return base.GetSPObject();
        }
	}
}
