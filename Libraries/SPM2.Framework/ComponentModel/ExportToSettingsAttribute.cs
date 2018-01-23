using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using SPM2.Framework.Configuration;

namespace SPM2.Framework.ComponentModel
{
    /// <summary>
    /// Specialized ExportAttribute used for the Settings treeview object model.
    /// </summary>
    public class ExportToSettingsAttribute : ExportAttribute
    {
        /// <summary>
        /// Exports the class to the SettingsRoot.
        /// </summary>
        public ExportToSettingsAttribute()
            : base(AttributedModelServices.GetContractName(typeof(SettingsRoot)), typeof(ISettings))
        {

        }

        public ExportToSettingsAttribute(string contractName)
            : base(contractName, typeof(ISettings))
        {

        }

        public ExportToSettingsAttribute(Type contractType)
            : base(AttributedModelServices.GetContractName(contractType), typeof(ISettings))
        {

        }
    }
}
