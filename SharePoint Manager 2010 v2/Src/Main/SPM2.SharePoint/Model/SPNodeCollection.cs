using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.SharePoint.Client;
using SPM2.Framework;

namespace SPM2.SharePoint.Model
{

    public class SPNodeCollection : SPNode, ISPNodeCollection
    {
        private ISPNode _defaultNode;

        public ISPNode DefaultNode
        {
            get
            {
                if (_defaultNode == null)
                {
                    _defaultNode = NodeProvider.FindDefaultNode(this);
                }
                return _defaultNode;
            }
            set { _defaultNode = value; }
        }

        public IEnumerator Pointer { get; set; }

        public bool MoveNext { get; set; }

        public int TotalCount { get; set; }

        public SPNodeCollection()
        {
            MoveNext = true;
        }


        public override void LoadChildren()
        {
            if (SPObject == null)
            {
                return;
            }

            if (Children.Count > 0)
            {
                // Ensure that the last node is the "MoreNode".
                int nodeIndex = Children.Count - 1;
                ISPNode node = Children[nodeIndex];

                if (node is MoreNode)
                {
                    // Remove the "MoreNode" from this.Children.
                    Children.RemoveAt(nodeIndex);
                }
            }
            else
            {
                ClearChildren();
                EnsureNodeTypes();
            }
#if DEBUG
            var watch = new Stopwatch();
            watch.Start();
#endif
            // Load the next batch!
            Children.AddRange(NodeProvider.LoadCollectionChildren(this));

#if DEBUG
            watch.Stop();
            Trace.WriteLine(String.Format("Load Properties: Type:{0} - Time {1} milliseconds.",
                                          SPObjectType.Name, watch.ElapsedMilliseconds));
#endif

        }

        public override void ClearChildren()
        {
            Pointer = null;
            TotalCount = 0;
            MoveNext = true;
            Children.Clear();
        }
    }
}