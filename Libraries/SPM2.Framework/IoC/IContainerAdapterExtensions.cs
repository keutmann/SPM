using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPM2.Framework.IoC
{
    public static class IContainerAdapterExtensions
    {
        public static T ResolveOrDefault<T>(this IContainerAdapter adapter)
        {
            return ResolveOrDefault<T>(adapter, default(T));
        }

        public static T ResolveOrDefault<T>(this IContainerAdapter adapter, T defaultValue = default(T))
        {
            T result;

            if (adapter.TryResolve<T>(out result))
            {
                return result;

            }

            return defaultValue;
        }

        public static T ResolveOrDefault<T>(this IContainerAdapter adapter, string serviceName)
        {
            return ResolveOrDefault<T>(adapter, serviceName, default(T));
        }

        public static T ResolveOrDefault<T>(this IContainerAdapter adapter, string serviceName, T defaultValue = default(T))
        {
            T result;

            if (adapter.TryResolve<T>(serviceName, out result))
            {
                return result;
            }

            return defaultValue;
        }
    }
}
