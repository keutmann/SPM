using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPM2.Framework.IoC;
using SPM2.Framework.Configuration;
using System.ComponentModel;

namespace Keutmann.SharePointManager
{
    [IoCBind(typeof(ISettings))]
    [IoCLifetime(Singleton = true)]
    public class GeneralSettings : Settings
    {
        [DisplayName("Read only")]
        [Description("Disable the delete function.")]
        public bool ReadOnly { get; set; }
    }
}
