using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace SPM2.Framework.ComponentModel
{
    public class PropertyGridEditValue
    {
        public ITypeDescriptorContext Context {get;set;}
        public IServiceProvider Provider {get;set;}
        public object Value { get; set; }

        public PropertyGridEditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            this.Context = context;
            this.Provider = provider;
            this.Value = value;
        }
    }
}
