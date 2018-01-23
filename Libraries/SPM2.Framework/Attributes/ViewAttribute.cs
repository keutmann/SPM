using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPM2.Framework
{
    [AttributeUsage(System.AttributeTargets.Class, AllowMultiple=true)]
    public class ViewAttribute : Attribute
    {
        public int Level { get; set; }

        public ViewAttribute(int level)
        {
            this.Level = level;
        }
    }
}
