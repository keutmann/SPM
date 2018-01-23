using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPM2.Framework
{
    [AttributeUsage(System.AttributeTargets.Class, AllowMultiple=false)]
    public class AdapterItemTypeAttribute : Attribute
    {
        public string Name { get; set; }

        public AdapterItemTypeAttribute()
        {
        }

        public AdapterItemTypeAttribute(string name)
        {
            this.Name = name;
        }
    }
}
