using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using Autofac;
using Autofac.Builder;
using Autofac.Core;
using Autofac.Features.Metadata;
using Autofac.Features.Scanning;
using SPM2.Framework.IoC;
using System.ComponentModel;

namespace SPM2.Framework.IoC
{
    public static class AutofacExtensions
    {
        private const string OrderString = "Order";
        private static int OrderCounter;

        #region Registration

        public static IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle>
            WithOrder<TLimit, TActivatorData, TRegistrationStyle>
                (this IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> registrationBuilder)
        {
            var test = registrationBuilder;
            
            return registrationBuilder.WithMetadata(OrderString, Interlocked.Increment(ref OrderCounter));
        }

        static Type[] GetImplementedInterfaces(Type type)
        {
            return type.GetInterfaces().Where(i => i != typeof(IDisposable)).ToArray();
        }

        public static IRegistrationBuilder<object, ConcreteReflectionActivatorData, SingleRegistrationStyle>
            Named2(
                this IRegistrationBuilder<object, ConcreteReflectionActivatorData, SingleRegistrationStyle> registration)
        {
            return registration;
        }

        public static IRegistrationBuilder<TLimit, ReflectionActivatorData, DynamicRegistrationStyle>
            AsSelf2<TLimit>(this IRegistrationBuilder<TLimit, ReflectionActivatorData, DynamicRegistrationStyle> registration)
        {
            if (registration == null) throw new ArgumentNullException("registration");
            return registration.As(registration.ActivatorData.ImplementationType);
        }

        public static IRegistrationBuilder<TLimit, TConcreteActivatorData, SingleRegistrationStyle>
            IoC<TLimit, TConcreteActivatorData>(this IRegistrationBuilder<TLimit, TConcreteActivatorData, SingleRegistrationStyle> registration)
            where TConcreteActivatorData : IConcreteActivatorData
        {
            if (registration == null) throw new ArgumentNullException("registration");
            var t = registration.ActivatorData.Activator.LimitType;

            var list = new List<Service>();

            // IoCNamedAttribute------------------------------------------------------
            var iocAttributes = t.GetCustomAttributes(true).OfType<IoCNamedAttribute>();
            foreach (var item in iocAttributes)
            {

                if (String.IsNullOrEmpty(item.Name))
                    continue;

                list.Add(new KeyedService(item.Name, t));

                var interfaces = GetImplementedInterfaces(t);
                if (interfaces.Any())
                {
                    list.AddRange(( from i in interfaces
                                    where !"INotifyPropertyChanged".EqualsIgnorecase(i.Name) && !"IDisposable".EqualsIgnorecase(i.Name)
                                    select new KeyedService(item.Name, i)).ToArray());
                }
            }


            var bindAttributes = t.GetCustomAttributes(true).OfType<IoCBindAttribute>();
            foreach (var item in bindAttributes)
            {

                if (item.Parent == null)
                    continue;

                var named = item.Parent.AssemblyQualifiedName;

                list.Add(new KeyedService(named, t));

                var interfaces = GetImplementedInterfaces(t);
                if (interfaces.Any())
                {
                    list.AddRange((from i in interfaces
                                   where !"INotifyPropertyChanged".EqualsIgnorecase(i.Name) && !"IDisposable".EqualsIgnorecase(i.Name)
                                   select new KeyedService(named, i)).ToArray());
                }
            }

            var result = registration.As(list.ToArray());

            if(t.GetAttibuteOrDefault<IoCPropertiesAutowiredAttribute>(null) != null)
            {
                result = result.PropertiesAutowired();
            }

            var lifetimeAttributes =  t.GetAttibuteOrDefault<IoCLifetimeAttribute>(new IoCLifetimeAttribute());
            if (lifetimeAttributes.Singleton)
            {
                result = result.SingleInstance();
            }

            var decoratorAttribute = t.GetAttibuteOrDefault<IoCDecoratorAttribute>(null);
            if (decoratorAttribute != null)
            {
                // ?
            }

            return result;
        }


        public static T GetAttibuteOrDefault<T>(this Type t, T defaultValue)
        {
            return t.GetCustomAttributes(true).OfType<T>().DefaultIfEmpty(defaultValue).FirstOrDefault();
        }

        #endregion

        #region Adapter

        public static IEnumerable<TComponent> ResolveBind<TComponent>(this IContainerAdapter container, Type parent)
        {
            var items = container.Resolve<IEnumerable<TComponent>>(parent.AssemblyQualifiedName).BindOrdered(parent);

            return items;
        }

        #endregion

        #region Ordered

        public static IEnumerable<TComponent> Ordered<TComponent>(this IEnumerable<TComponent> collection)
        {
            if (collection == null)
                return null;

            return from m in collection
                   orderby
                        m.GetType().GetCustomAttributes(true).OfType<IoCOrderAttribute>().DefaultIfEmpty(new IoCOrderAttribute()).FirstOrDefault().Order
                   select m;
        }


        public static IEnumerable<TComponent> Ordered<TComponent>(this IEnumerable<TComponent> collection, string groupName)
        {
            if (collection == null)
                return null;

            return from m in collection
                   orderby
                        m.GetType().GetCustomAttributes(true).OfType<IoCNamedAttribute>().DefaultIfEmpty(new IoCNamedAttribute("") { Name = groupName }).FirstOrDefault(p => groupName.Equals(p.Name)).Order
                   select m;
        }


        public static IEnumerable<TComponent> BindOrdered<TComponent>(this IEnumerable<TComponent> collection, Type astype)
        {
            if (collection == null)
                return null;

            return from m in collection
                   orderby
                        m.GetType().GetCustomAttributes(true).OfType<IoCBindAttribute>().DefaultIfEmpty(new IoCBindAttribute(astype)).FirstOrDefault(p => astype.Equals(p.Parent)).Order
                   select m;
        }

        #endregion

        #region Type 

        public static bool HasIoCIgnore(this Type type)
        {
            if (type == null) throw new ArgumentNullException("type");
            return type.GetCustomAttributes(true).OfType<IoCIgnoreAttribute>().Any();
        }

        #endregion
    }
}
