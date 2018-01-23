using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPM2.Framework.IoC
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class IoCBindAttribute : IoCOrderAttribute
    {
        public Type Parent { get; set; }
        
        public IoCBindAttribute(Type parent)
        {
            this.Parent = parent;
        }

        public IoCBindAttribute(Type parent, int order) : base(order)
        {
            this.Parent = parent;
        }
    }
}
