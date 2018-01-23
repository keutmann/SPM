using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using SPM2.Framework.Collections;
using System.ComponentModel;

namespace SPM2.Framework.Configuration
{
    public class Settings<T> : ISettings
    {
        private static DateTime lastUpdate = DateTime.MinValue;

        private static object lockObject = new object();
        private static T _current = default(T);

        public static T Current
        {
            get
            {
                lock (lockObject)
                {
                    bool isOld = SettingsProvider.Current.LastUpdate != lastUpdate;
                    if (object.Equals(_current, default(T)) || isOld)
                    {
                        _current = SettingsProvider.Current.GetSettings<T>();
                        lastUpdate = SettingsProvider.Current.LastUpdate;
                    }
                }
                return _current;
            }
        }

        //protected ISettings Parent { get; set; }



        private SerializableList<ISettings> _children = null;
        [Browsable(false)]
        public SerializableList<ISettings> Children
        {
            get
            {
                if (_children == null)
                {
                    _children = LoadChildren();
                }
                return _children;
            }
            set
            {
                _children = value;
            }
        }


        protected virtual SerializableList<ISettings> LoadChildren()
        {
            SerializableList<ISettings> result = new SerializableList<ISettings>();
            OrderingCollection<ISettings> importedNodes = CompositionProvider.GetOrderedExports<ISettings>(this.GetType().FullName);

            foreach (var item in importedNodes)
            {
                result.Add(item.Value);
            }

            return result;
        }

        
    }
}
