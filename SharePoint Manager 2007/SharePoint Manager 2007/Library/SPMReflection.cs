using System;
using System.Reflection;

namespace Keutmann.SharePointManager.Library
{
    public class SPMReflection
    {
        private static Type[] GetParameterTypes(object[] param)
        {
            Type[] types = new Type[param.Length];
            if (param.Length > 0)
            {
                for(int i = 0; i <param.Length; i++)
                {
                    types[i] = param[i].GetType();
                }
            }
            return types;
        }



        public static bool IsSPPropertyReadOnly(Type objType, string propertyName)
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


        public static bool DoMethodExists(Type spType, string methodName, object[] param)
        {
            Type[] types = GetParameterTypes(param);
            MethodInfo method = spType.GetMethod(methodName, types);
            if (method != null)
            {
                return true;
            }
            return false;

        }

        public static void CallMethod(object sourceObj, string methodName, object[] param)
        {
            Type[] types = GetParameterTypes(param);
            Type spType = sourceObj.GetType();
            MethodInfo method = spType.GetMethod(methodName, types);
            if (method != null)
            {
                method.Invoke(sourceObj, param);
            }
        }
    }
}
