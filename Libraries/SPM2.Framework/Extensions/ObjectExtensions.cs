using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace SPM2.Framework
{
    public static class ObjectExtensions
    {
        public static void InvokeMethod(this object sourceObj, string methodName)
        {
            sourceObj.InvokeMethod(methodName, null);
        }

        public static void InvokeMethod(this object sourceObj, string methodName, params object[] args)
        {
            if (sourceObj == null)
            {
                throw new ApplicationException("Missing sourceObj in Extension method 'InvokeMethod'");
            }

            Type[] types = TypeExtensions.GetParameterTypes(args);
            Type spType = sourceObj.GetType();
            MethodInfo method = spType.GetMethod(methodName, types);
            if (method != null)
            {
                method.Invoke(sourceObj, args);
            }
        }

        public static bool PropertyExist(this object source, string name, BindingFlags flags)
        {
            if (source == null ) new ArgumentNullException("source");
            if (String.IsNullOrEmpty(name)) new ArgumentException("Parameter name may not be null or empty");

            var type = source.GetType();
            var property = type.GetProperty(name, flags);

            return (property != null);
        }

        public static T GetPropertyValue<T>(this object source, string name, BindingFlags flags)
        {
            if (source == null) new ArgumentNullException("source");
            if (String.IsNullOrEmpty(name)) new ArgumentException("Parameter name may not be null or empty");

            var result = default(T);

            var type = source.GetType();
            var property = type.GetProperty(name, flags);

            if (property == null) return result;

            result = (T)property.GetValue(source, null);

            return result;
        }



    }
}
