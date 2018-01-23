using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using SPM2.Framework.ComponentModel;

namespace SPM2.SharePoint.Model
{
    /// <summary>
    /// Specialized ExportAttribute used for the SharePoint treeview object model.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple=true)]
    public class ExportToContextMenuAttribute : ExportAttribute
    {
        public ExportToContextMenuAttribute(string contractName)
            : base(contractName, typeof(IContextMenuItem))
        {

        }

        public ExportToContextMenuAttribute(Type contractType)
            : base(AttributedModelServices.GetContractName(contractType), typeof(IContextMenuItem))
        {

        }
    }
}
