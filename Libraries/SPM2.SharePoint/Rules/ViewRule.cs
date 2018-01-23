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
    //[ExportMetadata("Order", int.MaxValue)]

    [IoCLifetime(Singleton = true)]
    [IoCOrder()]
    public class ViewRule : IRule<ISPNode>
    {
        // Always accept this rule as it should be the laset one.
        public bool Accept(ISPNode node)
        {
 	        return true;
        }

        // Check the node
        public bool Check(ISPNode node)
        {
            if (node == null) throw new ArgumentNullException("node");

            if (node is IViewRule)
            {
                return ((IViewRule)node).IsVisible();
            }

            var type = node.GetType();
            var list = type.GetCustomAttributes(true).OfType<ViewAttribute>();
            if (list.Count() == 0) return true;

            return list.Any(p => node.NodeProvider.ViewLevel >= p.Level);
        }
    }
}
