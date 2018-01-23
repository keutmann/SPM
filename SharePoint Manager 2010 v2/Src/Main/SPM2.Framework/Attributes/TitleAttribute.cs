using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPM2.Framework
{
    [AttributeUsage(System.AttributeTargets.Class, AllowMultiple=false)]
    public class TitleAttribute : Attribute
    {
        public string Title { get; set; }
        public string PropertyName { get; set; }

        public TitleAttribute()
        {
        }

        public TitleAttribute(string title)
        {
            this.Title = title;
        }
    }
}
