using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Collections;

using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Client;

using SPM2.Framework;
using SPM2.Framework.Reflection;
using SPM2.SharePoint.Model;

namespace SPM2.ClassGenerator
{
    public class Genereator
    {
        public const string GeneratedNodeTemplateName = "GeneratedNode.template";
        public const string CustomNodeTemplateName = "CustomNode.template";
        public string GeneratedNodeTemplate = null;
        public string CustomNodeTemplate = null;


        TypesCollection Types = new TypesCollection();


        public Genereator()
        {
            this.GeneratedNodeTemplate = File.ReadAllText(GeneratedNodeTemplateName);
            this.CustomNodeTemplate = File.ReadAllText(CustomNodeTemplateName);
        }

        public void Run()
        {
            Type farmType = SPFarm.Local.GetType();
            NodeDescriptor descriptor = Types.GetOrCreate(null, SPFarm.Local, null);
            Types.Add(descriptor, null);

            Console.Write("Finding types...");
            FindTypes(descriptor);
            Console.WriteLine("Found : "+this.Types.Keys.Count);
            Console.WriteLine("Updating AttachTo...");
            UpdateAttachTo(descriptor);
            Console.WriteLine("Building files...");
            BuildFiles();
        }





        private void FindTypes(NodeDescriptor descriptor)
        {
            PropertyInfo[] properties = descriptor.ObjectType.GetProperties();

            if (properties != null)
            {
                foreach (PropertyInfo info in properties)
                {
                    NodeDescriptor child = Types.GetOrCreate(info, descriptor);

                    if (!child.IsSimpleType && !child.IsSystem)
                    {
                        if (child.IsEnumerable)
                        {
                            CreateArrayType(child, descriptor);
                        }
                        else
                        {
                            CreateSingleType(child, descriptor);
                        }
                    }

                }
            }

        }


        private void CreateArrayType(NodeDescriptor descriptor, NodeDescriptor parent)
        {
            // the object type is a GenericType in it self, therefore ignore it.
            if(descriptor.ObjectType.IsGenericType)
            {
                //Type itemType = null;
                //Type[] argTypes = descriptor.ObjectType.GetBaseGenericArguments();
                //if (argTypes != null && argTypes.Length > 0)
                //{
                //    itemType = argTypes[0];

                //    if (itemType.IsPrimitive || itemType == typeof(Guid) || itemType == typeof(string))
                //    {
                //        return;
                //    }
                //}
                return;
            }


            if (descriptor.IsStandardCollection)
            {
                return;
            }

            if (Types.Add(descriptor, parent))
            {
                // Do not find the property types in this collection
                // FindTypes(descriptor);

                CreateCollectionTypes(descriptor);

            }
            
        }

        private void CreateCollectionTypes(NodeDescriptor descriptor)
        {

            ClientCallableTypeAttribute attr = descriptor.ObjectType.GetAttribute<ClientCallableTypeAttribute>(true);
            if (descriptor.ObjectType.InheritFrom("SPBaseCollection") && attr != null)
            {
                Type itemType = attr.CollectionChildItemType;
                if (itemType != null)
                {
                    NodeDescriptor child = Types.GetOrCreate(itemType);
                    descriptor.CollectionItem = child;
                    if (Types.Add(child, descriptor))
                    {
                        FindTypes(child);
                    }
                }
            }
            else
            {
                CreateArrayInstanceTypes(descriptor);
            }
            
        }

        private void CreateArrayInstanceTypes(NodeDescriptor descriptor)
        {
            if (descriptor.Instance != null)
            {
                IEnumerable collection = (IEnumerable)descriptor.Instance;
                foreach (object obj in collection)
                {
                    NodeDescriptor child = Types.GetOrCreate(descriptor.Info, obj, descriptor);

                    if (Types.Add(child, descriptor))
                    {
                        FindTypes(child);
                    }
                }
            }

            Type itemType = GetArrayItemType(descriptor);
            if (itemType != null)
            {
                NodeDescriptor child = Types.GetOrCreate(itemType);
                descriptor.CollectionItem = child;
                if (Types.Add(child, descriptor))
                {
                    FindTypes(child);
                }
            }

        }

        private Type GetArrayItemType(NodeDescriptor descriptor)
        {
            Type itemType = null;
            Type[] argTypes = descriptor.ObjectType.GetBaseGenericArguments();
            if (argTypes != null && argTypes.Length > 0)
            {
                itemType = argTypes[0];

                if (itemType.IsPrimitive || itemType == typeof(Guid) || itemType == typeof(string))
                {
                    itemType = null;
                }
            }
            return itemType;
        }



        private void CreateSingleType(NodeDescriptor descriptor, NodeDescriptor parent)
        {
            // Add objects that is not collections
            if (descriptor.ObjectType.IsClass && !descriptor.IsSimpleType)
            {
                if (Types.Add(descriptor, parent))
                {
                    FindTypes(descriptor);
                }
            }
        }

        List<NodeDescriptor> AttachToPath = new List<NodeDescriptor>();

        private void UpdateAttachTo(NodeDescriptor descriptor)
        {
            descriptor.Visited = true;
            AttachToPath.Add(descriptor);

            foreach (NodeDescriptor child in descriptor.Children)
            {

                if (!AttachToPath.Contains(child) || child.Equals(descriptor.CollectionItem))
                {
                    child.AttachTo.Append(descriptor);
                    if (!child.Visited)
                    {
                        UpdateAttachTo(child);
                    }
                }
                else
                {
                    //child.Excludes.Append(descriptor);
                    //if(child.AttachTo.Contains(
                }
            }

            AttachToPath.Remove(descriptor);
        }


        private void BuildFiles()
        {
            //string csPath = Path.Combine(Environment.CurrentDirectory, "cs");
            //if (Directory.Exists(csPath))
            //{
            //    Directory.Delete(csPath, true);
            //}
            //Directory.CreateDirectory(csPath);
            foreach (KeyValuePair<string, NodeDescriptor> entry in this.Types)
            {
                ReplacementParameters param = new ReplacementParameters(entry.Value);

                NodeBuilder builder = new NodeBuilder(this.GeneratedNodeTemplate, "cs", param);
                builder.Bind();
                builder.Save();

                builder = new NodeBuilder(this.CustomNodeTemplate, "custom", param);
                builder.Bind();
                builder.Save();
            }
        }

        private Type CreateNodeType(Type type)
        {
            Type nodeType = null;
            bool isEnumerableType = TypeExtensions.IEnumerableType.IsAssignableFrom(type);
            if (isEnumerableType && type != TypeExtensions.StringType && !type.IsArray)
            {
                Type collectionType = type;

                Type itemType = null;
                Type[] argTypes = type.GetBaseGenericArguments();
                if (argTypes != null && argTypes.Length > 0)
                {
                    itemType = argTypes[0];
                    nodeType = SharedTypes.SPNodeCollectionType.MakeGenericType(collectionType, itemType);
                }

            }
            else
            {
                nodeType = SharedTypes.SPNodeType.MakeGenericType(type);
            }
            return nodeType;
        }




    }

}
