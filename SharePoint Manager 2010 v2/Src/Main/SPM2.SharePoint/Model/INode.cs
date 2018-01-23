using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPM2.Framework;

namespace SPM2.SharePoint.Model
{
    public interface INode
    {
        object GetSPObject();
        Type GetSPObjectType();

        void Setup(object spObject);
    }
}
