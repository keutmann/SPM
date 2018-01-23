using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Diagnostics;

namespace SPM2.Framework.ComponentModel
{
    public class PropertyGridPropertyDescriptor : PropertyDescriptor
    {

        private readonly PropertyDescriptor InnerPropertyDescriptor = null;

        public override Type ComponentType
        {
            get
            {
                return this.InnerPropertyDescriptor.ComponentType;
            }
        }

        public override bool IsReadOnly
        {
            get
            {
                return this.InnerPropertyDescriptor.IsReadOnly;
            }
        }

        public override Type PropertyType
        {
            get
            {
                return this.InnerPropertyDescriptor.PropertyType;
            }
        }

        public PropertyGridPropertyDescriptor(PropertyDescriptor innerPropertyDescriptor, Attribute[] attrs)
            : base(innerPropertyDescriptor.Name, attrs)
        {
            this.InnerPropertyDescriptor = innerPropertyDescriptor;
        }


        public override bool CanResetValue(object component)
        {
            return this.InnerPropertyDescriptor.CanResetValue(component);
        }

        public override object GetValue(object component)
        {
            object result = null;
            try
            {
                result = this.InnerPropertyDescriptor.GetValue(component);
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message);
            }
            return result;
        }

        public override void ResetValue(object component)
        {
            this.InnerPropertyDescriptor.ResetValue(component);
        }

        public override void SetValue(object component, object value)
        {
            this.InnerPropertyDescriptor.SetValue(component, value);
        }

        public override bool ShouldSerializeValue(object component)
        {
            return this.InnerPropertyDescriptor.ShouldSerializeValue(component);
        }
    }
}
