using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Client;
using SPM2.Framework;

namespace SPM2.SharePoint.Model
{

    public class SPNodeCollection : SPNode, ISPNodeCollection
    {
        [XmlIgnore]
        public IEnumerator Pointer { get; set; }

        [XmlIgnore]
        public bool LoadingChildren { get; set; }

        public int TotalCount { get; set; }


        public SPNodeCollection()
        {
        }


        public override void Setup(ISPNode parent)
        {
            base.Setup(parent);
        }

        public override void LoadChildren()
        {
            Children.AddRange(NodeProvider.LoadCollectionChildren(this, int.MaxValue));
        }


        public override void ClearChildren()
        {
            Pointer = null;
            TotalCount = 0;
            LoadingChildren = false;
            Children.Clear();
        }

        public override bool HasChildren()
        {
            if (SPObject == null) return true;

            var collection = SPObject as SPBaseCollection;
            if (collection != null)
            {
                return collection.Count > 0;
            }
            return true;
        }


    }
}