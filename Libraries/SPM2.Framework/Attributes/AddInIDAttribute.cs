using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPM2.Framework
{
    [AttributeUsage(System.AttributeTargets.Class, AllowMultiple=false)]
    public class AddInIDAttribute : Attribute
    {
        public string ID { get; set; }

        public AddInIDAttribute()
        {
        }

        public AddInIDAttribute(string id)
        {
            this.ID = id;
        }
    }
}
