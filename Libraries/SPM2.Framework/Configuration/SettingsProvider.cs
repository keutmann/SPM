using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPM2.Framework.Configuration;
using System.IO;
using System.Xml.Serialization;
using SPM2.Framework.Xml;
using System.Diagnostics;
using SPM2.Framework.IoC;

namespace SPM2.Framework.Configuration
{
    public class SettingsProvider
    {
        public const string FILENAME = "Settings.xml";

        public IContainerAdapter IoCContainer { get; set; }

        public SettingsProvider(IContainerAdapter container) 
        {
            IoCContainer = container;
        }


        public void Save(string filename = FILENAME)
        {
            var collection = IoCContainer.Resolve<IEnumerable<ISettings>>();

            var root = CreateSettingsRoot(collection);

            string xml = Serializer.ObjectToXML(root);
            File.WriteAllText(filename, xml);
        }


        public void Load(string filename = FILENAME)
        {
            SettingsRoot root = null;
            if (!File.Exists(filename))
                return;

            try
            {
                string xml = File.ReadAllText(filename);
                root = Serializer.XmlToObject<SettingsRoot>(xml);

                foreach (var item in root.Children)
                {
                    IoCContainer.Update(item);
                }
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

        private SettingsRoot CreateSettingsRoot(IEnumerable<ISettings> collection)
        {
            var result = new SettingsRoot();

            result.Children.AddRange(collection);

            return result;
        }



    }
}
