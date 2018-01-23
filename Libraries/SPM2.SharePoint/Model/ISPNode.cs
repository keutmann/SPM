using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using SPM2.Framework;
using SPM2.Framework.Collections;
using SPM2.Framework.IoC;
namespace SPM2.SharePoint.Model
{
    [XmlInclude(typeof(SPNode))]
    public interface ISPNode : IDisposable
    {
        string Text { get; set; }
        string ToolTipText { get; set; }
        string State { get; set; }
        string IconUri { get; set; }
        string AddInID { get; set; }
        string Url { get; set; }
        object SPObject { get; set; }
        
        ClassDescriptor Descriptor { get; set; }
        PropertyDescriptor ParentPropertyDescriptor { get; set; }
        SerializableList<ISPNode> Children { get; set; }
        //Dictionary<Type, ISPNode> NodeTypes { get; set; }
        ISPNodeProvider NodeProvider { get; set; }

        ISPNode Parent { get; set; }
        string ID { get; set; }
        int Index { get; set; }

        Type SPObjectType { get; set; }

        void Setup(ISPNode parent);

        object GetSPObject();
        Type GetSPObjectType();

        void LoadChildren();
        void ClearChildren();
        bool HasChildren();


    }
}
