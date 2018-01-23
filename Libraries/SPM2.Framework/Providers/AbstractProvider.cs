using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using SPM2.Framework.Configuration;
using SPM2.Framework;

namespace SPM2.Framework
{
    public abstract class AbstractProvider<I> 
    {
        #region Singleton

        private static object lockObject = new object();
        private static I _current = default(I);

        public static I Current
        {
            get
            {
                if (_current == null)
                {
                    lock (lockObject)
                    {
                        if (_current == null)
                        {
                            _current = CreateProvider();
                        }
                    }
                }
                return _current;
            }
        }

        private static I CreateProvider()
        {
            I result = default(I);

            //ProviderAttribute attribute = GetProviderAttribute();

            //ProviderElement element = SPM2Configuration.Current.Providers[attribute.ProviderType];

            //if (element != null)
            //{
            //    result = element.CreateInstance<I>();
            //}

            //if (result == null)
            //{
            //    Type defaultType = Type.GetType(attribute.DefaultType);
            //    result = (I)Activator.CreateInstance(defaultType);
            //}

            //if (result != null)
            //{
            //    //result.Initialize();
            //}
            result = (I)Activator.CreateInstance<I>();


            return result;
        }

        //protected virtual void Initialize()
        //{

        //}


        private static ProviderAttribute GetProviderAttribute()
        {
            Type iType = typeof(I);
            ProviderAttribute result = iType.GetAttribute<ProviderAttribute>(true);

            if (result == null)
            {
                throw new ApplicationException("Missing ProviderAttribute on Interface " + iType.Name);
            }

            return result;

        }

        #endregion
    }
}
