using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Reflection;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
//using SPM2.Framework.Xml;


namespace SPM2.Framework.Xml
{
    public class Serializer
    {

        public const string TypeNameNamespace = "http://www.keutmann.dk/xmlschema/interface/2011-01-01";

        #region Members

        //private static Object thisLock = new Object();
        //private static Object lockDBAttributeOverride = new Object();

        //private static Dictionary<string, object> _serializerStore = new Dictionary<string,object>();

        //private static Hashtable _attributeOverrideStore = new Hashtable();

        private static XmlSerializerFactory factory = new XmlSerializerFactory();

        #endregion


        #region Serialize XML


        public static string ObjectToXML(object input)
        {
            //Create our own namespaces for the output
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();

            //Add an empty namespace and empty value
            ns.Add("", "");

            return ObjectToXML(input, null, ns);
        }

        public static string ObjectToXML(object input, XmlSerializerNamespaces ns)
        {
            return ObjectToXML(input, null, ns);
        }

        public static string ObjectToXML(object input, XmlAttributeOverrides xmlOverrides, XmlSerializerNamespaces ns)
        {
            string resultXml = null;

            using (MemoryStream memoryStream = new MemoryStream())
            {
                XmlTextWriter writer = new XmlTextWriter(memoryStream, null);
                writer.Formatting = Formatting.Indented;

                ObjectToXML(input, writer, xmlOverrides, ns);

                resultXml = Encoding.UTF8.GetString(memoryStream.ToArray());
            }
            return resultXml;
        }

        public static void ObjectToXML(object input, XmlWriter writer, XmlAttributeOverrides xmlOverrides, XmlSerializerNamespaces ns)
        {
            //Stopwatch watch = new Stopwatch();
            //watch.Start();

            if (input == null)
            {
                throw new NullReferenceException("Input object cannot be null");
            }

            //XmlSerializer serializer = factory.CreateSerializer(input.GetType(), xmlOverrides);
            XmlSerializer serializer = factory.GetSerializer(input.GetType(), xmlOverrides);

            //watch.Stop();
            //Trace.WriteLine(String.Format("Call to factory.CreateSerializer({0}) took {1} Milliseconds", input.GetType().Name, watch.ElapsedMilliseconds));

            //watch.Reset();
            //watch.Start();

            // Do the serialization here!
            serializer.Serialize(writer, input, ns);

            //watch.Stop();
            //Trace.WriteLine(String.Format("Done serializing '{0}' took {1} Milliseconds", input.GetType().Name, watch.ElapsedMilliseconds));
        }


        public static T XmlToObject<T>(string xml)
        {
            T resultObj = default(T);
            if (!String.IsNullOrEmpty(xml))
            {
                Type objType = typeof(T);
                XmlSerializer serializer = factory.CreateSerializer(objType);
                StringReader sr = new StringReader(xml);
                try
                {
                    resultObj = (T)serializer.Deserialize(sr);
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Unable to deserialize object '" + objType.FullName + "' from this xml :" + xml, ex);
                }
                finally
                {
                    sr.Close();
                }
            }
            return resultObj;
        }


        public static T Clone<T>(T instance)
        {
            string xml = ObjectToXML(instance);
            return XmlToObject<T>(xml);
        }

        public static object DeserializeFromElement(XmlElement element, Type objectType)
        {
            object result = null;
            using (XmlNodeReader reader = new XmlNodeReader(element))
            {
                XmlSerializer xs = factory.CreateSerializer(objectType);

                result = xs.Deserialize(reader);
            }
            return result;
        }



        /// <summary>
        /// Serializes list
        /// </summary>
        /// <param name="outputStream">Ouput stream to write the serialized data</param>
        public static void CollectionToXml<T>(System.Xml.XmlWriter outputStream, ICollection<T> list)
        {
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            foreach (var item in list)
            {
                Type itemType = item.GetType();

                outputStream.WriteStartElement("oc", Serializer.TypeNameNamespace);
                outputStream.WriteAttributeString("sz", "TypeName", Serializer.TypeNameNamespace, itemType.AssemblyQualifiedName);

                //XmlAttributeOverrides xOver = XmlAttributeOverridesFactory.Create(itemType);
                Serializer.ObjectToXML(item, outputStream, null, ns);

                outputStream.WriteEndElement();
            }
        }


        /// <summary>
        /// Deserializes list
        /// </summary>
        /// <param name="outputStream">Ouput stream to write the serialized data</param>
        public static void XmlToCollection<T>(System.Xml.XmlReader inputStream, ICollection<T> interfaceList)
        {
            if (inputStream.IsEmptyElement)
            {
                //Move to next element
                inputStream.Read();
                return;
            }

            //Get the base node name of generic list of items of type Collection object
            string parentNodeName = inputStream.Name;

            //Stopwatch watch = new Stopwatch();
            //watch.Start();

            //Move to first child
            inputStream.Read();
            while (inputStream.NodeType != XmlNodeType.EndElement || inputStream.Name != parentNodeName)
            {
                if (inputStream.NodeType == XmlNodeType.Element)
                {
                    string typeName = inputStream.GetAttribute("TypeName", Serializer.TypeNameNamespace);
                    Type objectType = Type.GetType(typeName);

                    if (objectType != null)
                    {
                        inputStream.Read();
                        if (inputStream.NodeType != XmlNodeType.EndElement)
                        {
                            //XmlAttributeOverrides xOver = XmlAttributeOverridesFactory.Create(objectType);

                            XmlSerializer xs = factory.CreateSerializer(objectType);
                            T item = (T)xs.Deserialize(inputStream);
                            interfaceList.Add(item);
                        }
                    }
                    else
                    {
                        throw new ApplicationException("Error in XmlToCollection method. Node unhandled: " + inputStream.Name);
                    }
                }
                else
                {
                    // Move to the next element
                    inputStream.Read();
                }
            }
            // Move to the next element
            inputStream.Read();

            //watch.Stop();
            //Trace.WriteLine(String.Format("XmlToCollection took {0} Milliseconds", watch.ElapsedMilliseconds));

        }

        public static XmlSerializer GetSerializer(Type type, XmlAttributeOverrides overrides)
        {
            return factory.GetSerializer(type, overrides);
        }



        public static string FormatXml(string xml)
        {
            string tempXml = xml;
            bool rooted = xml.Trim().StartsWith("<?");
            if (!rooted)
            {
                tempXml = "<rootformatter>" + xml + "</rootformatter>";
            }


            string result = null;
            using (StringReader sr = new StringReader(tempXml))
            {
                XmlTextReader xtr = new XmlTextReader(sr);

                using (StringWriter sw = new StringWriter())
                {
                    XmlTextWriter xtw = new XmlTextWriter(sw);
                    xtw.Formatting = Formatting.Indented;

                    xtr.MoveToContent();
                    while (!xtr.EOF)
                    {
                        xtw.WriteNode(xtr, false);
                    }
                    result = sw.ToString();
                }
            }

            if (!rooted)
            {
                int rootlenght = "<rootformatter>".Length;
                int newLineLength = Environment.NewLine.Length;
                result = result.Substring(rootlenght + newLineLength, result.Length - ((rootlenght * 2) + 1 + newLineLength));
            }

            return result;
        }


        public static void LoadAttributes(object obj, XmlTextReader xtr)
        {
            if (xtr.HasAttributes)
            {

                Type objType = obj.GetType();
                PropertyInfo[] properties = objType.GetProperties(BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                foreach (PropertyInfo prop in properties)
                {
                    string rawValue = xtr.GetAttribute(prop.Name);

                    if (rawValue != null)
                    {
                        object parsedValue = null;
                        Type propType = prop.PropertyType;
                        if (propType.IsEnum)
                        {
                            parsedValue = Enum.Parse(propType, rawValue);
                        }
                        else
                        {
                            MethodInfo parseInfo = propType.GetMethod("Parse", BindingFlags.Public | BindingFlags.Static | BindingFlags.IgnoreCase);
                            if (parseInfo != null)
                            {
                                parsedValue = parseInfo.Invoke(null, new object[] { rawValue });
                            }
                            else
                            {
                                parsedValue = rawValue;
                            }
                        }

                        if (parsedValue != null)
                        {
                            prop.SetValue(obj, parsedValue, null);
                        }
                    }
                }
            }
        }



        private static string Utf8ToUnicode(string utf8)
        {
            return Encoding.Unicode.GetString(Encoding.Convert(Encoding.UTF8, Encoding.Unicode, Encoding.UTF8.GetBytes(utf8)));
        }

        private static String UTF8ByteArrayToString(Byte[] characters)
        {

            UTF8Encoding encoding = new UTF8Encoding();
            String constructedString = encoding.GetString(characters);
            return (constructedString);
        }

        private static Byte[] StringToUTF8ByteArray(String pXmlString)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            Byte[] byteArray = encoding.GetBytes(pXmlString);
            return byteArray;
        }


        #endregion

        #region Serialize Binary

        public static byte[] ObjectToBinary(object input, Type objType)
        {
            byte[] result = null;
            BinaryFormatter binFormatter = new BinaryFormatter();
            MemoryStream dataStream = new MemoryStream();
            try
            {
                binFormatter.Serialize(dataStream, input);
                result = dataStream.GetBuffer();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to binary serialize object '" + objType.FullName + "'", ex);
            }
            finally
            {
                dataStream.Close();
            }
            return result;
        }

        public static object BinaryToObject(byte[] data, Type objType)
        {
            object resultObj = null;
            BinaryFormatter binFormatter = new BinaryFormatter();
            MemoryStream dataStream = new MemoryStream(data);
            try
            {
                resultObj = binFormatter.Deserialize(dataStream);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to deserialize object '" + objType.FullName + "' from binary.", ex);
            }
            return resultObj;
        }
        #endregion

    }
}