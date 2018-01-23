using System;
using System.Collections.Generic;
using SPM2.Framework;
namespace SPM2.SharePoint.Model
{
    public interface ISPNode : INode
    {
        object Text { get; set; }
        string ToolTipText { get; set; }
        string TextColor { get; set; }
        string IconUri { get; set; }
        string AddInID { get; set; }
        string Url { get; set; }
        object SPObject { get; set; }
        object SPParent { get; set; }
        ClassDescriptor Descriptor { get; set; }
        List<ISPNode> Children { get; set; }
        Dictionary<Type, ISPNode> NodeTypes { get; set; }
        ISPNodeProvider NodeProvider { get; set; }

        Type SPObjectType { get;  }
        void LoadChildren();
        void ClearChildren();
    }
}
