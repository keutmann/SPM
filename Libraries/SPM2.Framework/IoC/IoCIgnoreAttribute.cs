using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPM2.Framework.IoC
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class IoCIgnoreAttribute : Attribute
    {
        public IoCIgnoreAttribute()
        {

        }
    }
}
