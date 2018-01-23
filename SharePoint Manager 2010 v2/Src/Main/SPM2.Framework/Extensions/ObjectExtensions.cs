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

    }
}
