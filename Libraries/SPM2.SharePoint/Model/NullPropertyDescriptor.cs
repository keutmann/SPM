using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace SPM2.SharePoint.Model
{
    public class NullPropertyDescriptor : PropertyDescriptor
    {
        public NullPropertyDescriptor(string name)
            : base(name, new Attribute[] { })
        {
        }

        public NullPropertyDescriptor(ISPNode parent)
            : this(parent.Text)
        {
        }

        public override bool CanResetValue(object component)
        {
            return false;
        }

        public override Type ComponentType
        {
            get { return typeof(string); }
        }

        public override object GetValue(object component)
        {
            return null;
        }

        public override bool IsReadOnly
        {
            get { return true; }
        }

        public override Type PropertyType
        {
            get { return typeof(string); }
        }

        public override void ResetValue(object component)
        {
        }

        public override void SetValue(object component, object value)
        {
        }

        public override bool ShouldSerializeValue(object component)
        {
            return false;
        }
    }
}
