using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SPM2.Framework.IoC
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class IoCNamedAttribute : IoCOrderAttribute
    {
        public string Name { get; set; }

        public IoCNamedAttribute(string named) : base()
        {
            this.Name = named;
        }

        public IoCNamedAttribute(string named, int order)
        {
            this.Name = named;
            this.Order = order;
        }

    }
}
