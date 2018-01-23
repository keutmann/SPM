using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.ComponentModel;
using System.Collections.Specialized;
using System.Reflection;
using SPM2.Framework.Reflection;

namespace SPM2.Framework.Configuration
{
    public class ProviderElement : ConfigurationElement
    {

        public NameValueCollection Options { get; private set; }


        public const string TYPE_ATTRIBUTE_NAME = "type";
        public const string NAME_ATTRIBUTE_NAME = "name";
        public const string CLASS_ATTRIBUTE_NAME = "Class";
        public const string ASSEMBLY_ATTRIBUTE_NAME = "Assembly";


        /// <summary>
        /// Defines the class name of the provider.
        /// </summary>
        [ConfigurationProperty(NAME_ATTRIBUTE_NAME, IsKey = true, IsRequired = true)]
        public ProviderTypes Name
        {
            get 
            {
                ProviderTypes result = ProviderTypes.Unknown;
                if (this[NAME_ATTRIBUTE_NAME] != null)
                {
                    result = (ProviderTypes)this[NAME_ATTRIBUTE_NAME];
                }
                return result;
             }
            set { this[NAME_ATTRIBUTE_NAME] = value; }
        }

        /// <summary>
        /// Defines the type and assembly for the provider.
        /// </summary>
        [ConfigurationProperty(TYPE_ATTRIBUTE_NAME, IsRequired = true)]
        [TypeConverter(typeof(TypeNameConverter))]
        [CallbackValidator(Type = typeof(ProviderElement), CallbackMethodName = "ValidateProviderType")]
        public Type Type
        {
            get { return this[TYPE_ATTRIBUTE_NAME] as Type; }
            set { this[TYPE_ATTRIBUTE_NAME] = value; }
        }


        public ProviderElement() : base()
        {
            Options = new NameValueCollection();
        }


        public T CreateInstance<T>()
        {
            T result = (T)Activator.CreateInstance(this.Type, true);
            if (result != null)
            {
                this.Initialize(result);
            }
            return result;
        }



        public void Initialize(object target)
        {
            Type type = target.GetType();

            foreach (string key in this.Options.AllKeys)
            {
                string value = this.Options[key];
                PropertyInfo p = type.GetProperty(key, BindingFlags.IgnoreCase | BindingFlags.FlattenHierarchy | BindingFlags.Instance);
                if (p != null)
                {
                    p.SetValue(target, value, null);
                }
                else
                {
                    FieldInfo f = type.GetField(key, BindingFlags.IgnoreCase | BindingFlags.FlattenHierarchy | BindingFlags.Instance);
                    if (f != null)
                    {
                        f.SetValue(target, value);
                    }
                }
            }
        }

        protected override bool OnDeserializeUnrecognizedAttribute(string name, string value)
        {
            Options.Add(name, value);
            return true;
        }


        public static void ValidateProviderType(object type)
        {
            //if (!typeof(IAddInProvider).IsAssignableFrom((Type)type))
            //{
            //    throw new ConfigurationErrorsException("The provider must implement the IAddInProvider interface.");
            //}
        }





        ///// <summary>
        ///// Returns the key value.
        ///// </summary>
        //[ConfigurationProperty("key", IsRequired = true)]
        //public string Key
        //{
        //    get
        //    {
        //        return this["key"] as string;
        //    }
        //}


        ///// <summary>
        ///// Defines the class name of the provider.
        ///// </summary>
        //[ConfigurationProperty(CLASS_ATTRIBUTE_NAME, IsRequired = true)]
        //public string ClassName
        //{
        //    get
        //    {
        //        return this[CLASS_ATTRIBUTE_NAME] as string;
        //    }
        //}

        //private string _assemblyName = null;
        ///// <summary>
        ///// Defines the Assembly where the provider can be found.
        ///// </summary>
        //[ConfigurationProperty(ASSEMBLY_ATTRIBUTE_NAME, IsRequired = false)]
        //public string AssemblyName
        //{
        //    get
        //    {
        //        if (String.IsNullOrEmpty(_assemblyName))
        //        {
        //            _assemblyName = this[ASSEMBLY_ATTRIBUTE_NAME] as string;
        //            if (String.IsNullOrEmpty(_assemblyName))
        //            {
        //                Type providerType = Type.GetType(this.ClassName, false);
        //                if (providerType != null)
        //                {
        //                    this._assemblyName = providerType.AssemblyQualifiedName;
        //                }
        //            }
        //        }
        //        return _assemblyName;
        //    }
        //}

    }
}
