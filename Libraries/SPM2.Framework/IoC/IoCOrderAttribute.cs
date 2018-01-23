using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SPM2.Framework.IoC
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class IoCOrderAttribute : Attribute
    {
        public int Order { get; set; }

        public IoCOrderAttribute()
        {
            Order = int.MaxValue-1000;
        }

        public IoCOrderAttribute(int order)
        {
            Order = order;
        }
    }
}
