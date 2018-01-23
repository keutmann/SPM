using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPM2.Framework;
using System.Reflection;

namespace SPM2.ClassGenerator
{
    public class NodeDescriptorCollection : List<NodeDescriptor>
    {
        public NodeDescriptor Current {get;set;}

        public NodeDescriptorCollection(NodeDescriptor current)
        {
            this.Current = current;
        }

        public void AddUnique(NodeDescriptor descriptor)
        {
            if (!this.Contains(descriptor))
            {
                this.Add(descriptor);
            }
        }
        
        public void Append(NodeDescriptor parent)
        {
            if (parent != null && this.Current.NodeFullName != parent.NodeFullName && !this.Contains(parent))
            {
                this.Add(parent);
            }

            //if (parent != null && !this.Contains(parent))
            //{
            //    this.Add(parent);
            //}
        }

        private bool Exist(NodeDescriptor current, string name)
        {
            if (current.NodeFullName == name)
            {
                return true;
            }

            foreach (NodeDescriptor node in current.AttachTo)
            {
                if (Exist(node, name))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
