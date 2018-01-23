using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPM2.SharePoint.Model
{
    public interface ISPNodeCollection : ISPNode
    {
        ISPNode DefaultNode { get; set; }
        IEnumerator Pointer { get; set; }
        bool MoveNext { get; set; }
        int TotalCount { get; set; }
    }
}
