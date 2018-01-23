using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using SPM2.Framework.Collections;
using System.ComponentModel;
using SPM2.Framework.IoC;
using SPM2.Framework.Xml;

namespace SPM2.Framework.Configuration
{
    [IoCLifetime(Singleton=true)]
    public abstract class Settings : ISettings
    {
    }
}
