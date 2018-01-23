using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;

namespace SPM2.SharePoint.Model
{
    /// <summary>
    /// Specialized ExportAttribute used for the SharePoint treeview object model.
    /// </summary>
    public class ExportToNodeAttribute : ExportAttribute
    {
        public ExportToNodeAttribute(string contractName)
            : base(contractName, typeof(SPNode))
        {

        }

        public ExportToNodeAttribute(Type contractType)
            : base(AttributedModelServices.GetContractName(contractType), typeof(SPNode))
        {

        }
    }
}
