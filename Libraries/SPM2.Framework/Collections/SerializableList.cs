using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Diagnostics;
using SPM2.Framework.Xml;

namespace SPM2.Framework.Collections
{
    public class SerializableList<T> : List<T>, IXmlSerializable
    {
        public SerializableList() :
            base()
        {
        }

        public SerializableList(IEnumerable<T> collection) :
            base(collection)
        {
        }

        public SerializableList(List<T> list) :
            base(list)
        {
        }


        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(System.Xml.XmlReader reader)
        {
            Serializer.XmlToCollection<T>(reader, this);
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            Serializer.CollectionToXml<T>(writer, this);
        }
    }
}
