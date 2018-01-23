using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Xml.Serialization;
using SPM2.Framework.Xml;


namespace SPM2.Framework.Collections
{
    /// <summary>
    /// An extended version of ObservableCollection that supports serializing with Interfaces.
    /// </summary>
    /// <typeparam name="T">Can be any type or interface</typeparam>
    public class ObservableCollectionXML<T> : ObservableCollection<T>, IXmlSerializable
    {

        public ObservableCollectionXML() : 
            base()
        {
        }

        public ObservableCollectionXML(IEnumerable<T> collection) : 
            base(collection)
        {
        }

        public ObservableCollectionXML(List<T> list) : 
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
