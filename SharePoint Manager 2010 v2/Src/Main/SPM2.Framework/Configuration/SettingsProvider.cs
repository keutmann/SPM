using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPM2.Framework.Configuration;
using System.IO;
using System.Xml.Serialization;
using SPM2.Framework.Xml;
using System.Diagnostics;

namespace SPM2.Framework.Configuration
{
    public class SettingsProvider
    {
        public const string FILENAME = "Settings.xml";

        [XmlIgnore]
        public DateTime LastUpdate { get; set; }

        private SettingsRoot _root = null;
        public SettingsRoot Root 
        {
            get
            {
                if (_root == null)
                {
                    _root = Load(FILENAME);
                    if (_root == null)
                    {
                        _root = new SettingsRoot();
                    }
                    this.LastUpdate = DateTime.Now;
                }
                return _root;
            }
            set
            {
                _root = value;
                this.LastUpdate = DateTime.Now;
            }
        }


        SettingsProvider() : base()
        {
        }


        public T GetSettings<T>()
        {
            return FindType<T>(this.Root);
        }

        private T FindType<T>(ISettings model)
        {
            T result = default(T);

            if (model is T)
            {
                result = (T)model;
            }
            else
            {
                foreach (var item in model.Children.AsSafeEnumable())
                {
                    result = FindType<T>(item);
                    if (result != null)
                    {
                        break;
                    }
                }
            }

            return result;
        }


        public void Save(string filename = FILENAME)
        {
            string xml = Serializer.ObjectToXML(this.Root);
            File.WriteAllText(filename, xml);
        }


        #region Singleton

        private static object lockObject = new object();
        private static SettingsProvider _current = null;

        public static SettingsProvider Current
        {
            get
            {
                if (_current == null)
                {
                    lock (lockObject)
                    {
                        if (_current == null)
                        {
                            _current = new SettingsProvider();
                            
                        }
                    }
                }
                return _current;
            }
            internal set
            {
                lock (lockObject)
                {
                    _current = value;
                }
            }
        }


        public static SettingsRoot Load(string filename)
        {
            SettingsRoot result = null;
            if (File.Exists(filename))
            {
                try
                {
                    string xml = File.ReadAllText(filename);
                    result = Serializer.XmlToObject<SettingsRoot>(xml);
                }
                catch (Exception ex)
                {
                    Trace.TraceError(ex.GetMessages());
                    string errorFilename = filename + ".error";
                    if (File.Exists(errorFilename))
                    {
                        File.Delete(errorFilename);
                    }
                    File.Move(filename, errorFilename);
                }

            }
            return result;
        }



        #endregion
    }
}
