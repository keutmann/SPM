using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;

namespace SPM2.Framework.WPF.Controls
{
    public class ExportToMenuItem : ExportAttribute
    {
        public ExportToMenuItem(string contractName)
            : base(contractName, typeof(MenuItem))
        {

        }

        public ExportToMenuItem(Type contractType)
            : base(AttributedModelServices.GetContractName(contractType), typeof(MenuItem))
        {

        }
    }
}
