using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPM2.Framework;
using System.Reflection;

namespace SPM2.ClassGenerator
{
    public class TypesCollection : Dictionary<string, NodeDescriptor>
    {

        public bool Add(NodeDescriptor descriptor, NodeDescriptor parent)
        {
            if (parent != null)
            {
                parent.Children.Add(descriptor);
            }

            if (!this.ContainsKey(descriptor.NodeFullName))
            {
                this.Add(descriptor.NodeFullName, descriptor);
                //Console.WriteLine("Type added:" + descriptor.NodeFullName);
                return true;
            }
            return false;
        }



        public NodeDescriptor GetOrCreate(Type itemType)
        {
            return GetOrCreate(new NodeDescriptor(itemType));
            
        }

        public NodeDescriptor GetOrCreate(PropertyInfo info, NodeDescriptor parentDescriptor)
        {
            return GetOrCreate(info, parentDescriptor.GetPropertyObject(info), parentDescriptor);
        }


        public NodeDescriptor GetOrCreate(PropertyInfo info, object instance, NodeDescriptor parentDescriptor)
        {
            return GetOrCreate(new NodeDescriptor(info, instance));
        }

        public NodeDescriptor GetOrCreate(NodeDescriptor descriptor)
        {
            NodeDescriptor result = descriptor;
            if (this.ContainsKey(result.NodeFullName))
            {
                result = this[result.NodeFullName];
            }

            return result;
        }


        //public bool Append(string title, Type propertyType, Type parentType)
        //{
            
        //    bool isNew = false;
        //    AttachToCollection attachTo = null;
        //    if (this.ContainsKey(propertyType))
        //    {
        //        attachTo = this[propertyType];
        //    }
        //    else
        //    {
        //        attachTo = new AttachToCollection(title, propertyType);
        //        this.Add(propertyType, attachTo);
        //        isNew = true;
        //        Console.WriteLine("Type added:" + propertyType.Name + "(" + title + ")");
        //    }

        //    // Only attach to the parent if the propertyType is not defined in the chain before.
        //    if (!IsRecursive(propertyType, parentType))
        //    {
        //        attachTo.Append(parentType);
        //    }

        //    return isNew;
        //}



    }
}
