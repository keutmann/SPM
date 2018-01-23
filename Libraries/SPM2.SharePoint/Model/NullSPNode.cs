using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPM2.SharePoint.Model
{
    public class NullSPNode : SPNode
    {
        public NullSPNode()
        {

        }

        public NullSPNode(ISPNodeProvider provider)
        {
            this.NodeProvider = provider;
        }
    }
}
