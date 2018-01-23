using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using SPM2.Framework.Reflection;
using System.ComponentModel;

namespace SPM2.ClassGenerator
{
    public class NodeDescriptor : IComparable<NodeDescriptor>, IEquatable<NodeDescriptor>
    {
        public const string NAMESPACE = "SPM2.SharePoint.Model.";

        //public Type ParentType { get; set; }
        public PropertyInfo Info { get; set; }
        public object Instance { get; set; }

        public bool Visited { get; set; }

        private Type _objectType = null;
        public Type ObjectType
        {
            get 
            {
                if (_objectType == null)
                {
                    if (this.Instance != null)
                    {
                        _objectType = this.Instance.GetType();
                    }
                    else
                    {
                        _objectType = this.Info.PropertyType;
                    }
                }
                return _objectType; 
            }
            set { _objectType = value; }
        }

        private AttributeCollection _attributes = null;

        public AttributeCollection Attributes
        {
            get 
            {
                if (_attributes == null)
                {
                    _attributes = new AttributeCollection(this.ObjectType.GetCustomAttributes(true).OfType<Attribute>().ToArray());
                }
                return _attributes; 
            }
            set { _attributes = value; }
        }


        private string _propertyTitle = null;

        public string PropertyTitle
        {
            get 
            {
                if (_propertyTitle == null)
                {
                    _propertyTitle = GetPropertyTitle();
                }
                return _propertyTitle; 
            }
            set { _propertyTitle = value; }
        }

        private string _title = null;
        public string Title
        {
            get 
            {
                if (_title == null)
                {
                    if (this.Info != null)
                    {
                        _title = this.Info.Name;
                    }

                    if (String.IsNullOrEmpty(_title) ||  _title == "Item")
                    {
                        _title = this.ObjectType.Name;
                    }
                }
                return _title; 
            }
            set { _title = value; }
        }

        private bool? _isEnumerable = null;
        public bool IsEnumerable
        {
            get
            {
                if (_isEnumerable == null)
                {
                    _isEnumerable = TypeExtensions.IEnumerableType.IsAssignableFrom(this.ObjectType);
                }
                return (bool)_isEnumerable; 
            }
            set { _isEnumerable = value; }
        }

        private bool? _isSimpleType = null;
        public bool IsSimpleType
        {
            get 
            {
                if (_isSimpleType == null)
                {
                    _isSimpleType = this.ObjectType == TypeExtensions.StringType || this.ObjectType.IsPrimitive || this.ObjectType.IsArray || this.ObjectType == TypeExtensions.GuidType;
                }
                return (bool)_isSimpleType;
            }
            set { _isSimpleType = value; }
        }


        private bool? _isStandardCollection = null;
        public bool IsStandardCollection
        {
            get 
            {
                if (_isStandardCollection == null)
                {
                    _isStandardCollection = this.ObjectType.FullName.StartsWith("System.Collections.");
                }
                return (bool)_isStandardCollection; 
            }
            set { _isStandardCollection = value; }
        }

        private bool? _isSystem = null;
        public bool IsSystem
        {
            get
            {
                if (_isSystem == null)
                {
                    _isSystem = this.ObjectType.FullName.StartsWith("System.");
                }
                return (bool)_isSystem;
            }
            set { _isStandardCollection = value; }
        }

        private bool? _isGeneric = null;
        public bool IsGeneric
        {
            get 
            {
                if (_isGeneric == null)
                {
                    _isGeneric = this.ObjectType.Name.Contains("`");
                }
                return (bool)_isGeneric; 
            }
            set { _isGeneric = value; }
        }



        private bool? _isSPPersistedObjectType = null;
        public bool IsSPPersistedObjectType
        {
            get 
            {
                if (_isSPPersistedObjectType == null)
                {
                    _isSPPersistedObjectType = this.ObjectType.InheritFrom("SPPersistedObject") && !this.IsEnumerable;
                }
                return (bool)_isSPPersistedObjectType; 
            }
            set { _isSPPersistedObjectType = value; }
        }

        private string _nodeName = null;
        public string NodeName
        {
            get 
            {
                if (_nodeName == null)
                {
                    _nodeName = this.ObjectType.Name+"Node";
                }
                return _nodeName; 
            }
            set { _nodeName = value; }
        }

        private string _nodeFullNode = null;
        public string NodeFullName
        {
            get
            {
                if (_nodeFullNode == null)
                {
                    _nodeFullNode = string.Format("{0}{1}", NAMESPACE, this.NodeName);
                }
                return _nodeFullNode;
            }
            set { _nodeFullNode = value; }
        }

        private NodeDescriptorCollection _attachTo = null;
        public NodeDescriptorCollection AttachTo
        {
            get
            {
                if (_attachTo == null)
                {
                    _attachTo = new NodeDescriptorCollection(this);
                }
                return _attachTo;
            }
            set { _attachTo = value; }
        }


        private NodeDescriptorCollection _children = null;
        public NodeDescriptorCollection Children
        {
            get 
            { 
                if(_children == null)
                {
                    _children = new NodeDescriptorCollection(this);
                }
                return _children; 
            }
            set { _children = value; }
        }

        private NodeDescriptorCollection _excludeList = null;
        public NodeDescriptorCollection Excludes
        {
            get
            {
                if (_excludeList == null)
                {
                    _excludeList = new NodeDescriptorCollection(this);
                }
                return _excludeList;
            }
            set { _excludeList = value; }
        }

        public NodeDescriptor CollectionItem { get; set; }

        public NodeDescriptor(PropertyInfo info, object instance)
        {
            this.Info = info;
            this.Instance = instance;
        }

        public NodeDescriptor(Type itemType)
        {
            this.ObjectType = itemType;
            this.Instance = null;
        }

        public string GetNodeFullName(Type type)
        {
            if (type.IsGenericType)
            {
                return "";
            }
            else
            {
                return GetFullName(type);
            }
        }

        public static string GetFullName(Type type)
        {
            if (type != null)
            {
                return string.Format("{0}{1}Node", NAMESPACE, type.Name);
            }
            else
            {
                return "";
            }
        }



        public object GetPropertyObject(PropertyInfo info)
        {
            object childObject = null;
            if (this.Instance != null)
            {
                try
                {
                    // Get the object if we can
                    childObject = info.GetValue(this.Instance, null);
                }
                catch
                {
                }
            }
            return childObject;
        }

        public int CompareTo(NodeDescriptor other)
        {
            return this.NodeFullName.CompareTo(other.NodeFullName);
        }

        public bool Equals(NodeDescriptor other)
        {
            bool result = false;
            if (other != null)
            {
                result = this.NodeFullName.Equals(other.NodeFullName);
            }

            return result;
        }

        private string GetPropertyTitle()
        {
            string result = null;

            if(PropertyExist("DisplayName"))
            {
                result = "DisplayName";
            }
            else
            if(PropertyExist("Title"))
            {
                result = "Title";
            }
            return result;
        }

        private bool PropertyExist(string name)
        {
            PropertyInfo info = this.ObjectType.GetProperty(name);
            return info != null;
        }
    }
}
