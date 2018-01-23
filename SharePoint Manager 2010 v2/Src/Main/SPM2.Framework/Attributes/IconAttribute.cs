using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPM2.Framework
{

    public enum IconSource
    {
        Assembly,
        File
    }

    [AttributeUsage(System.AttributeTargets.Class, AllowMultiple=false)]
    public class IconAttribute : Attribute
    {
        public string Large { get; set; }
        public string Small { get; set; }


        private IconSource _source = IconSource.File;
        public IconSource Source
        {
            get { return _source; }
            set { _source = value; }
        }


        public IconAttribute()
        {
        }

        public IconAttribute(string small)
        {
            this.Small = small;
        }

    }
}
