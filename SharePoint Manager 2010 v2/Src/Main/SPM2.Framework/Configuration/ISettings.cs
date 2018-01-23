using System;
using SPM2.Framework.Xml;
using SPM2.Framework.Collections;

namespace SPM2.Framework.Configuration
{
    public interface ISettings
    {
        SerializableList<ISettings> Children { get; set; }
    }
}
