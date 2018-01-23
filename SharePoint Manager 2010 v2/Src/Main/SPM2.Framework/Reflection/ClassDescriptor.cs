using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Reflection;

using SPM2.Framework;

namespace SPM2.Framework
{
     
    public class ClassDescriptor
    {
        public static Type AddInIDAttributeType = typeof(AddInIDAttribute);
        public static Type TitleAttributeType = typeof(TitleAttribute);
        public static Type DescriptionAttributeType = typeof(DescriptionAttribute);
        public static Type IconAttributeType = typeof(IconAttribute);
        public static Type IAddInDocumentWindow = typeof(IDocumentWindow);
        public static Type IAddInPadWindow = typeof(IPadWindow);


        private string _addInID = null;
        public string AddInID 
        { 
            get
            {
                if (_addInID == null)
                {
                    _addInID = this.ClassType.GetAddInID();
                }
                return _addInID;
            }
            set
            {
                _addInID = value;
            }
        }

        private string _title = null;
        public string Title
        {
            get
            {
                if (_title == null)
                {
                    TitleAttribute titleAttribute = (TitleAttribute)this.Attributes[TitleAttributeType];
                    if (titleAttribute != null)
                    {
                        _title = titleAttribute.Title;
                    }
                    if (String.IsNullOrEmpty(_title))
                    {
                        _title = this.ClassType.Name;
                        if (_title.Contains("`"))
                        {
                            Type[] argTypes = this.ClassType.GetBaseGenericArguments();
                            if (argTypes != null && argTypes.Length > 0)
                            {
                                _title = argTypes[0].Name;
                            }
                        }

                        if (_title.StartsWith("SP"))
                        {
                            _title = _title.Substring(2);
                        }
                        if (_title.EndsWith("Node"))
                        {
                            _title = _title.Substring(0, _title.Length - 4);
                        }
                        if (_title.EndsWith("Collection"))
                        {
                            _title = _title.Substring(0, _title.Length - "Collection".Length) + "s";

                        }
                    }
                }
                return _title;
            }
            set
            {
                _title = value;
            }
        }



        private string _description = null;
        public string Description 
        {
            get
            {
                if (_description == null)
                {
                    DescriptionAttribute descriptionAttribute = (DescriptionAttribute)this.Attributes[DescriptionAttributeType];
                    if (descriptionAttribute != null)
                    {
                        _description = descriptionAttribute.Description;
                    }
                    if (String.IsNullOrEmpty(_description))
                    {
                        _description = null;
                    }
                }
                return _description;
            }
            set
            {
                _title = value;
            }
        }

        private AttributeCollection _attributes = null;
        public AttributeCollection Attributes
        {
            get
            {
                if (_attributes == null)
                {
                    _attributes = new AttributeCollection(this.ClassType.GetCustomAttributes(true).OfType<Attribute>().ToArray());
                }
                return _attributes;
            }
            set
            {
                _attributes = value;
            }
        }


        private Type[] _interfaces = null;
        public Type[] Interfaces 
        {
            get
            {
                if (_interfaces == null)
                {
                    _interfaces = this.ClassType.GetInterfaces();
                }
                return _interfaces;
            }
            set
            {
                _interfaces = value;
            }
        }


        public Type ClassType { get; set; }


        private IconAttribute _icon = null;
        public IconAttribute Icon
        {
            get 
            {
                if (this._icon == null)
                {
                    this._icon = (IconAttribute)this.Attributes[IconAttributeType];
                }
                return _icon; 
            }
            set { _icon = value; }
        }


        private bool? _isEnumerable = null;
        public bool IsEnumerable
        {
            get 
            {
                if (this._isEnumerable == null)
                {
                    this._isEnumerable = TypeExtensions.IEnumerableType.IsAssignableFrom(this.ClassType);

                }
                return (bool)_isEnumerable; 
            }
            set { _isEnumerable = value; }
        }


        private Type _adapterItemType = null;
        public Type AdapterItemType
        {
            get
            {
                if (_adapterItemType == null)
                {
                    AdapterItemTypeAttribute attrib = this.ClassType.GetAttribute<AdapterItemTypeAttribute>(true);
                    if (attrib != null)
                    {
                        _adapterItemType = Type.GetType(attrib.Name, false, false);
                    }
                }
                return _adapterItemType; 
            }
            set { _adapterItemType = value; }
        }


        public ClassDescriptor(Type type)
        {
            this.ClassType = TypeDescriptor.GetReflectionType(type);
        }


        public T CreateInstance<T>()
        {
            T result = default(T);

            try
            {
                object instance = Activator.CreateInstance(this.ClassType);
                if (instance != null && instance is T)
                {
                    result = (T)instance;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to create an instance of " + typeof(T).Name, ex);
            }

            return result;
        }

        public string GetTitle(object instance)
        {
            string result = null;
            if (instance != null)
            {
                Type instanceType = instance.GetType();
                if (String.IsNullOrEmpty(result))
                {
                    TitleAttribute titleAttribute = (TitleAttribute)this.Attributes[TitleAttributeType];
                    if (titleAttribute != null)
                    {
                        if (!String.IsNullOrEmpty(titleAttribute.PropertyName))
                        {
                            PropertyInfo info = instanceType.GetProperty(titleAttribute.PropertyName);
                            if (info != null)
                            {
                                result = info.GetValue(instance, null) as string;
                            }
                        }
                    }
                }

                if (String.IsNullOrEmpty(result))
                {
                    PropertyInfo info = instanceType.GetProperty("DisplayName");
                    if (info != null)
                    {
                        result = info.GetValue(instance, null) as string;
                    }
                }

                if (String.IsNullOrEmpty(result))
                {
                    PropertyInfo info = instanceType.GetProperty("Name");
                    if (info != null)
                    {
                        result = info.GetValue(instance, null) as string;
                    }
                }

            }
            if (String.IsNullOrEmpty(result))
            {

                result = this.Title;
            }

            return result;
        }


    }
}
