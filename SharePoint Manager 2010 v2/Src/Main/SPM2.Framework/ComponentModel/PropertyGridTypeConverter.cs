using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace SPM2.Framework.ComponentModel
{
    public class PropertyGridTypeConverter : TypeConverter
    {
        private static List<string> _excludedProperties = new List<string>();
        public static List<string> ExcludedProperties
        {
            get { return PropertyGridTypeConverter._excludedProperties; }
            set { PropertyGridTypeConverter._excludedProperties = value; }
        }

        private static Dictionary<Type, Attribute[]> _propertyAttributes = new Dictionary<Type, Attribute[]>();
        public static Dictionary<Type, Attribute[]> PropertyAttributes
        {
            get { return PropertyGridTypeConverter._propertyAttributes; }
            set { PropertyGridTypeConverter._propertyAttributes = value; }
        }

        public static void AddTo(Type type)
        {
            if (type != null)
            {
                TypeConverterAttribute tt = new TypeConverterAttribute(typeof(PropertyGridTypeConverter));
                TypeDescriptor.AddAttributes(type, new Attribute[] { tt });
            }
        }

        public static void AddEditor(Type targetType, Type editorType)
        {
            PropertyAttributes.Add(targetType, new Attribute[] { new EditorAttribute(editorType, typeof(System.Drawing.Design.UITypeEditor)) }); 
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(value, attributes);
            List<PropertyDescriptor> result = new List<PropertyDescriptor>(props.Count);

            foreach (PropertyDescriptor prop in props)
            {
                PropertyDescriptor addProperty = prop;

                if (ExcludedProperties.Contains(prop.Name))
                {
                    continue;
                }

                if (PropertyAttributes.ContainsKey(prop.PropertyType))
                {
                    List<Attribute> attributeList = new List<Attribute>(prop.Attributes.OfType<Attribute>());
                    attributeList.AddRange(PropertyAttributes[prop.PropertyType]);

                    addProperty = new PropertyGridPropertyDescriptor(prop, attributeList.ToArray());
                }

                result.Add(addProperty);
            }

            return new PropertyDescriptorCollection(result.ToArray());
        }


    }
}
