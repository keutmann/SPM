using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPM2.Framework.Xml;
using SPM2.Framework.Collections;
using System.ComponentModel;
using System.Xml.Serialization;

namespace SPM2.Framework.Configuration
{
    public class SettingsRoot 
    {
        [Browsable(false)]
        public SerializableList<ISettings> Children = new SerializableList<ISettings>();
    }
}
