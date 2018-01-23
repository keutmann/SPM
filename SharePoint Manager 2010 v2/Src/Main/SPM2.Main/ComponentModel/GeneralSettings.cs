using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPM2.Framework.ComponentModel;
using System.ComponentModel;
using SPM2.Framework;
using System.ComponentModel.Composition;
using SPM2.Framework.Configuration;

namespace SPM2.SharePoint.Model
{
    [Title("General")]
    [ExportToSettings()]
    [ExportMetadata("Order", 100)]
    public class GeneralSettings : Settings<GeneralSettings>
    {

    }
}
