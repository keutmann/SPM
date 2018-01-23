using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using SPM2.Framework.Collections;

namespace SPM2.Framework.Xml
{
    public static class XmlAttributeOverridesFactory
    {
        private static ThreadSafeDictionary<Type, XmlAttributeOverrides> table = new ThreadSafeDictionary<Type, XmlAttributeOverrides>();


        public static XmlAttributeOverrides Create(Type objectType)
        {
            XmlAttributeOverrides xOver = null;

            if (!table.TryGetValue(objectType, out xOver))
            {
                // Create XmlAttributeOverrides object.
                xOver = new XmlAttributeOverrides();

                /* Create an XmlTypeAttribute and change the name of the XML type. */
                XmlTypeAttribute xType = new XmlTypeAttribute();
                xType.TypeName = objectType.Name;

                // Set the XmlTypeAttribute to the XmlType property.
                XmlAttributes attrs = new XmlAttributes();
                attrs.XmlType = xType;

                /* Add the XmlAttributes to the XmlAttributeOverrides,
                   specifying the member to override. */
                xOver.Add(objectType, attrs);

                table.MergeSafe(objectType, xOver);
            }

            return xOver;
        }


    }
}
