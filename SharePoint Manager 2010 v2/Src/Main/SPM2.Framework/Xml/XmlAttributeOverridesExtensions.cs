using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Reflection;
using System.Collections;

namespace SPM2.Framework.Xml
{
    public static class XmlAttributeOverridesExtensions
    {
        public static string GetHashKey(this XmlAttributeOverrides overrides)
        {
            string result = null;

            if (overrides != null)
            {
                Type type = overrides.GetType();

                StringBuilder key = new StringBuilder(type.AssemblyQualifiedName);

                FieldInfo field = type.GetField("types", BindingFlags.Instance | BindingFlags.NonPublic);
                if (field != null)
                {
                    Hashtable table = (Hashtable)field.GetValue(overrides);
                    if (table != null)
                    {
                        foreach (DictionaryEntry entry in table)
                        {
                            Type memberType = (Type)entry.Key;
                            key.Append(memberType.AssemblyQualifiedName);

                            Hashtable memberTable = (Hashtable)entry.Value;
                            foreach (DictionaryEntry memberEntry in memberTable)
                            {
                                string memberName = memberEntry.Key as string;
                                key.Append(memberName);

                                //XmlAttributes attributes = (XmlAttributes)memberEntry.Value;
                            }

                        }
                    }
                }


                result = key.ToString();// HashAlgorithmExtensions.GetHash();
            }

            return result;
        }


    }
}
