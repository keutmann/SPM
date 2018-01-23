using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Keutmann.SharePointManager.Components;
using Keutmann.SharePointManager.Library;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.WebControls;
using SPM2.Framework.Collections;
using SPM2.Framework.Forms;
using SPM2.SharePoint;
using SPM2.SharePoint.Model;

namespace Keutmann.SharePointManager.ViewModel.TreeView
{
    public class SPMoreNode : SPTreeNode, IShadowNode 
    {
        public SPMoreNode(ISPNode modelNode) : base(modelNode)
        {
            this.Text = "More...";
        }

        public static SPTreeNode Create(ITreeViewNodeProvider provider, ISPNode spNode)
        {
            var node = new SPMoreNode(spNode);
            node.NodeProvider = provider;

            return node;
        }
    }
}
