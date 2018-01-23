using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPM2.Framework.Xml;

namespace SPM2.Framework.Configuration
{
    public class SettingsRoot : Settings<SettingsRoot>
    {
        public SettingsRoot Clone()
        {
            return Serializer.Clone<SettingsRoot>(this);
        }
    }
}
