using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using SPM2.Framework;


namespace SPM2.SharePoint.Model
{
    public static class ISPNodeExtensions
    {
        public static void Initialize(this ISPNode node, PropertyDescriptor descriptor, ISPNode parent, object spObject, int index)
        {
            if (descriptor == null)
                throw new ArgumentNullException("descriptor");

            node.Parent = parent;
            node.NodeProvider = parent.NodeProvider;
            //node.ID = (spObject != null) ? GetCollectionItemID(spObject, index) : descriptor.GetHashCode().ToString();

            node.ParentPropertyDescriptor = descriptor;
            node.Index = index;
            node.SPObject = spObject;

            //node.Setup(parent);
        }


    }
}
