using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Collections;
using SPM2.Framework.Collections;

namespace SPM2.Framework.Xml
{
    public static class XmlSerializerFactoryExtensions
    {

        private static ThreadSafeDictionary<string, XmlSerializer> serializerTable = new ThreadSafeDictionary<string, XmlSerializer>();

        /// <summary>
        /// Create or reuse a XmlSerializer with a specific override!
        /// The .NET Factory method "CreateSerializer" do not support caching with a custom override!
        /// This method is optimized for speed and is threadsafe.
        /// </summary>
        /// <param name="factory"></param>
        /// <param name="type"></param>
        /// <param name="overrides"></param>
        /// <returns></returns>
        public static XmlSerializer GetSerializer(this XmlSerializerFactory factory, Type type, XmlAttributeOverrides overrides)
        {
            XmlSerializer result = null;
            
            string key = type.AssemblyQualifiedName;
            if (overrides != null)
            {
                key += overrides.GetHashCode();

                if (!serializerTable.TryGetValue(key, out result))
                {
                    result = factory.CreateSerializer(type, overrides);
                    serializerTable.MergeSafe(key, result);
                }
            }
            else
            {
                result = factory.CreateSerializer(type);
            }

            return result;
        }
    }
}
