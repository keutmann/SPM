using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPM2.Framework.IoC;

namespace SPM2.SharePoint.Model
{
    [AttributeUsage(System.AttributeTargets.Class, AllowMultiple = false)]
    public class AdapterItemTypeAttribute : IoCNamedAttribute
    {

        public string Fullname { get; set; }

        public AdapterItemTypeAttribute(string name)
            : base(FormatName(name))
        {
            Fullname = name;
        }

        private static string FormatName(string name)
        {
            return name.IndexOf(",") > 0 ? name.Substring(0, name.IndexOf(",")) : name;
        }
    }
}
