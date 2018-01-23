using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SPM2.Framework.IoC
{
    public interface IContainerAdapter
    {
        T Resolve<T>();
        T Resolve<T>(string serviceName);
        bool TryResolve<T>(out T result);
        bool TryResolve<T>(string serviceName, out T result);

        void Update(object instance);
    }
}
