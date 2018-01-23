using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;

namespace SPM2.Framework
{
    [AttributeUsage(System.AttributeTargets.Class, AllowMultiple=false)]
    public class AdapterItemTypeAttribute : ExportAttribute
    {
        public string Name { get; set; }
        public string Key { get; set; }

        public AdapterItemTypeAttribute()
        {
        }

        public AdapterItemTypeAttribute(string name)
            : base(name.IndexOf(",") > 0 ? name.Substring(name.IndexOf(",")) : name, typeof(SPNode))
        {
            Name = name;
        }
    }
}
