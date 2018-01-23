using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPM2.Framework;
using SPM2.SharePoint.Model;


namespace SPM2.SharePoint.Rules
{

    [AttributeUsage(AttributeTargets.Class, AllowMultiple=false)]
    public class RecursiveRuleAttribute : Attribute
    {
        public bool IsRecursiveVisible { get; set; }

        public RecursiveRuleAttribute()
        {
            IsRecursiveVisible = true;
        }
    }
}
