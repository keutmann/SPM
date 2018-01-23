using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPM2.SharePoint.Model;
using Microsoft.SharePoint;


namespace SPM2AuditLog.Model
{
    public class AuditLogModel 
    {
        public SPNode Node { get; set; }

        public SPSite Site { get; set; }

        public SPAudit Audit { get; set; }

        public AuditLogModel(SPNode node)
        {
            this.Node = node;

            this.Site = GetSite(node);
            // Config other properties.


        }

        private SPSite GetSite(SPNode node)
        {
            SPSite result = null;
            ISPNode temp = node;
            if (temp.SPObjectType == typeof(SPSite))
            {
                result = temp.SPObject as SPSite;
            }
            else
            {
                if (temp.Parent != null)
                {
                    result = GetSite(temp.Parent as SPNode);
                }
            }
            return result;
        }

        
    }
}
