using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace SPM2.Framework.Configuration
{
    /// <summary>
    /// Abstract class that provides a generic implimentation of ConfigurationElementCollection
    /// </summary>
    /// <typeparam name="K">Type of the Key. For example this could be a string or integer.</typeparam>
    /// <typeparam name="V">Type of the Value. For example this could be string, integer or even a entire class.</typeparam>
    public abstract class ConfigurationElementCollection<K, V> : ConfigurationElementCollection where V : ConfigurationElement, new()
    {
        public ConfigurationElementCollection()
        {
        }

        public abstract override ConfigurationElementCollectionType CollectionType
        {
            get;
        }

        protected abstract override string ElementName
        {
            get;
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new V();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return GetElementKey((V)element);
        }

        protected abstract K GetElementKey(V element);

        public void Add(V path)
        {
            BaseAdd(path);
        }

        public void Remove(K key)
        {
            BaseRemove(key);
        }

        public V Get(K key)
        {
            return (V)BaseGet(key);
        }

        public V Get(int index)
        {
            return (V)BaseGet(index);
        }

        public V this[K key]
        {
            get { return (V)BaseGet(key); }
        }

        public V this[int index]
        {
            get { return (V)BaseGet(index); }
        }
    }
}
