using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPM2.Framework;
using SPM2.SharePoint.Model;
using SPM2.Framework.Components;
using SPM2.Framework.IoC;


namespace SPM2.SharePoint.Rules
{
    //[Export(typeof(IRule<ISPNode>))]
    //[PartCreationPolicy(CreationPolicy.Shared)]
    //[ExportMetadata("Order", int.MaxValue-1)]

    [IoCOrder(int.MaxValue-1)]
    public class RecursiveRule : IRule<ISPNode>
    {

        public bool Accept(ISPNode node)
        {
            if (node == null) throw new ArgumentNullException("node");

            if (IsRecursiveVisible(node))
                return false;

            if (PreviousExist(node.Parent, node.GetType().FullName))
                return true;

            return false;
        }

        // Check the node
        public bool Check(ISPNode node)
        {
            return false;
        }

        private bool PreviousExist(ISPNode node, string typeName)
        {
            if (node == null) return false;

            if (node.GetType().FullName == typeName) return true;

            return PreviousExist(node.Parent, typeName);
        }

        public static bool IsRecursiveVisible(ISPNode node)
        {
            if (node is IRecursiveRule)
            {
                return ((IRecursiveRule)node).IsRecursiveVisible();
            }

            return node.Descriptor.Attributes.OfType<RecursiveRuleAttribute>().Any(p => p.IsRecursiveVisible);
        }
    }
}
