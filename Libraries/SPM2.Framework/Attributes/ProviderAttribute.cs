using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPM2.Framework.Configuration;

namespace SPM2.Framework
{
    [AttributeUsage(System.AttributeTargets.Interface, AllowMultiple=false)]
    public class ProviderAttribute : Attribute
    {
        public ProviderTypes ProviderType { get; set; }
        public string DefaultType { get; set; }

        public ProviderAttribute()
        {
        }
    }
}
