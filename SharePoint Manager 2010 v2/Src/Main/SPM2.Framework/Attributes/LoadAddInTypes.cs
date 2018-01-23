using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPM2.Framework
{
    /// <summary>
    /// Tells the AddInProvider not to load any of the types in the assembly as AddIns. 
    /// Used for optimizing load speed of the AddInProvider.
    /// </summary>
    [AttributeUsage(System.AttributeTargets.Assembly, AllowMultiple=false)]
    public class LoadAddInTypesAttribute : Attribute
    {
        public bool Load { get; set; }

        public LoadAddInTypesAttribute()
        {
        }

        public LoadAddInTypesAttribute(bool load)
        {
            this.Load = load;
        }
    }
}
