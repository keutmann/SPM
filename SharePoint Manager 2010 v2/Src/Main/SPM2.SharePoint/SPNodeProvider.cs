using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Client;
using SPM2.Framework;
using SPM2.SharePoint.Model;

namespace SPM2.SharePoint
{
    [Export()]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class SPNodeProvider : ISPNodeProvider
    {
        public const string AddInId = "SPM2.SharePoint.SPNodeProvider";

        public ISPNode LoadFarmNode()
        {
            return Create("Farm", typeof(SPFarmNode), SharePointContext.Instance.Farm);
        }

        public  IEnumerable<ISPNode> LoadCollectionChildren(ISPNodeCollection parentNode)
        {
            int batchCount = SPExplorerSettings.Current.BatchNodeLoad;

            var list = new List<ISPNode>();
            int count = 0;

            if (parentNode.Pointer == null)
            {
                parentNode.ClearChildren();
                parentNode.TotalCount = 0;
                var collection = (IEnumerable)parentNode.SPObject;
                parentNode.Pointer = collection.GetEnumerator();
                //_pointer.Reset();
                parentNode.MoveNext = parentNode.Pointer.MoveNext();
            }

            while (count <= batchCount && parentNode.MoveNext)
            {
                Type instanceType = parentNode.Pointer.Current.GetType();
                ISPNode node = null;

                if (parentNode.NodeTypes.ContainsKey(instanceType))
                {
                    node = parentNode.NodeTypes[instanceType];
                }
                else
                {
                    if (parentNode.DefaultNode != null)
                    {
                        node = parentNode.DefaultNode;
                    }
                }

                if (node != null)
                {
                    // Always create a new node, because the object has to be unique for each item in the treeview.
                    var instanceNode = (ISPNode) Activator.CreateInstance(node.GetType());
                    instanceNode.NodeProvider = parentNode.NodeProvider;
                    instanceNode.SPObject = parentNode.Pointer.Current;
                    instanceNode.Setup(parentNode.SPObject);
                    list.Add(instanceNode);
                }

                parentNode.MoveNext = parentNode.Pointer.MoveNext();
                count++;
                parentNode.TotalCount++;
            }
            // If there is more nodes in the collection, add a "More" item.
            if (count >= batchCount && parentNode.MoveNext)
            {
                var node = new MoreNode(parentNode);
                node.Setup(parentNode.SPObject);
                list.Add(node);
            }

            if (parentNode.TotalCount <= batchCount)
            {
                // There are a low number of nodes, therefore sort nodes by Text.
                return list.OrderBy(p => p.Text);
            }
            // Just add the elements without any sort, because of the high number of nodes.
            return list;
        }


        public  IEnumerable<ISPNode> LoadChildren(ISPNode node)
        {
            return LoadUnorderedChildren(node).OrderBy(p => p.Text);
        }

        public  IEnumerable<ISPNode> LoadUnorderedChildren(ISPNode sourceNode)
        {
            var list = new List<ISPNode>();
            PropertyDescriptorCollection propertyDescriptors = TypeDescriptor.GetProperties(sourceNode.SPObjectType);
            try
            {

                // ReSharper disable LoopCanBeConvertedToQuery
                foreach (PropertyDescriptor info in propertyDescriptors)
                {
                    if (sourceNode.NodeTypes.ContainsKey(info.PropertyType))
                    {
                        ISPNode node = sourceNode.NodeTypes[info.PropertyType];

                        //Ensure that the child node instance is unique in the TreeView
                        node = Create(info.DisplayName, node.GetType(), sourceNode.SPObject);
                        list.Add(node);
                        //yield return node;
                    }
                }
                // ReSharper restore LoopCanBeConvertedToQuery
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            return list;
        }

        public  Dictionary<Type, ISPNode> GetChildrenTypes(ISPNode parentNode)
        {
            IEnumerable<Lazy<SPNode>> importedNodes = CompositionProvider.GetExports<SPNode>(parentNode.Descriptor.ClassType);
            var types = new Dictionary<Type, ISPNode>();
            foreach (var lazyItem in importedNodes)
            {
                SPNode node = lazyItem.Value;
                node.NodeProvider = parentNode.NodeProvider;
    
                if (node.Descriptor.AdapterItemType != null)
                {
                    types.AddOrReplace(node.Descriptor.AdapterItemType, node);
                }
            }
            return types;
        }


        public ISPNode FindDefaultNode(ISPNode node)
        {
            ISPNode result = null;
            if (node.SPObjectType != null)
            {
                Type spType = null;

                var attr = node.SPObjectType.GetAttribute<ClientCallableTypeAttribute>(true);
                if (attr != null)
                {
                    spType = attr.CollectionChildItemType;
                }

                if (spType == null)
                {
                    Type[] argTypes = node.SPObjectType.GetBaseGenericArguments();
                    if (argTypes != null && argTypes.Length == 1)
                    {
                        spType = argTypes[0];
                    }
                }

                if (spType != null && node.NodeTypes.ContainsKey(spType))
                {
                    result = node.NodeTypes[spType];
                }
            }

            return result;
        }


        private ISPNode Create(string name, Type nodeType, object spObject)
        {
            var node = (ISPNode) Activator.CreateInstance(nodeType);
            node.NodeProvider = this;
            node.Text = name;
            node.Setup(spObject);
            return node;
        }
    }
}