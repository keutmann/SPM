using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPM2.SharePoint.Model
{
    /// <summary>
    /// Specialized ExportAttribute used for the SharePoint treeview object model.
    /// Non used anymore
    /// </summary
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class ExportToNodeAttribute : Attribute //: ExportAttribute
    {
        public bool AutoBind { get; set; }

        public ExportToNodeAttribute(Type contractType)
            //: this(AttributedModelServices.GetContractName(contractType))
        {
        }

        public ExportToNodeAttribute(string contractName)
            //: base(contractName, typeof(SPNode))
        {
            AutoBind = true;
        }
    }
}
