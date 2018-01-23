using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;

namespace SPM2.Framework.IoC
{
    [IoCIgnoreAttribute()]
    public class AutofacIocAdapter : IContainerAdapter
    {
        private readonly IComponentContext _container;

        public AutofacIocAdapter(IComponentContext container)
        {
            _container = container;
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public T Resolve<T>(string serviceName)
        {
            return _container.ResolveNamed<T>(serviceName);
        }

        public bool TryResolve<T>(out T result)
        {
            return _container.TryResolve<T>(out result);
        }

        public bool TryResolve<T>(string serviceName, out T result)
        {
            object localResult;
            var success = _container.TryResolveNamed(serviceName, typeof(T), out localResult);
            result = (T)localResult;
            return success;
        }

        public void Update(object instance)
        {
            var builder = new ContainerBuilder();
            builder.RegisterInstance(instance);
            builder.Update(_container.ComponentRegistry);
        }
    }
}
