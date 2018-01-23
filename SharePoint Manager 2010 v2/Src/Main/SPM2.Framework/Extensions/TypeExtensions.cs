using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections;

namespace SPM2.Framework
{
    public static class TypeExtensions
    {
        public static Type IEnumerableType = typeof(IEnumerable);
        public static Type StringType = typeof(string);
        public static Type GuidType = typeof(Guid);


        public static List<PropertyInfo> GetProperties(this Type source, Type targetType, bool includeNonPublic)
        {
            List<PropertyInfo> result = new List<PropertyInfo>();
            BindingFlags flags = BindingFlags.FlattenHierarchy | BindingFlags.Public;
            flags |= (includeNonPublic) ? BindingFlags.NonPublic : BindingFlags.IgnoreCase;

            PropertyInfo[] list = source.GetProperties(flags);
            foreach (PropertyInfo info in list)
            {
                if (info.PropertyType == targetType)
                {
                    result.Add(info);
                }
            }

            return result;
        }

        public static bool IsOfType(this Type type, Type targetType)
        {
            return targetType.IsAssignableFrom(type);
        }



        public static bool InheritFrom(this Type type, string name)
        {
            bool result = false;

            while (type != null)
            {
                if (type.Name.Contains(name))
                {
                    result = true;
                    break;
                }
                type = type.BaseType;
            }

            return result;
        }

        /// <summary>
        /// Look at the base classes for a generic class to get the arguments from.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Type[] GetBaseGenericArguments(this Type type)
        {
            Type[] result = null;

            while (type != null)
            {
                if (type.IsGenericType)
                {
                    result = type.GetGenericArguments();
                    break;
                }
                else
                {
                    Type[] interfaceTypes = type.GetInterfaces();
                    foreach (Type interfaceType in interfaceTypes)
                    {
                        if (interfaceType.IsGenericType)
                        {
                            result = interfaceType.GetGenericArguments();
                            break;
                        }
                    }
                }
                type = type.BaseType;
            }

            return result;
        }

        public static T GetAttribute<T>(this Type source, bool inherit)
        {
            Type type = typeof(T);
            return source.GetCustomAttributes(type, inherit).Cast<T>().FirstOrDefault();
        }

        public static string GetAddInID(this Type source)
        {
            string result = null;
            AddInIDAttribute idAttribute = source.GetAttribute<AddInIDAttribute>(true);
            if (idAttribute != null)
            {
                result = idAttribute.ID;
            }
            if (String.IsNullOrEmpty(result))
            {
                result = source.FullName;
            }
            return result;
        }






        public static bool IsSPPropertyReadOnly(this Type objType, string propertyName)
        {
            bool result = true;
            if (objType != null)
            {
                PropertyInfo propInfo = objType.GetProperty(propertyName);
                if (propInfo != null)
                {
                    result = !propInfo.CanWrite;
                }
            }
            return result;
        }


        public static bool DoMethodExists(this Type spType, string methodName, object[] param)
        {
            Type[] types = GetParameterTypes(param);
            MethodInfo method = spType.GetMethod(methodName, types);
            if (method != null)
            {
                return true;
            }
            return false;

        }

        public static Type[] GetParameterTypes(object[] param)
        {
            Type[] types = new Type[] {};
            if (param != null)
            {
                types = new Type[param.Length];
                if (param.Length > 0)
                {
                    for (int i = 0; i < param.Length; i++)
                    {
                        types[i] = param[i].GetType();
                    }
                }
            }
            return types;
        }



    }
}
