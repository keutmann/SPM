using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Client;
using SPM2.Framework;
using SPM2.Framework.Components;
using SPM2.Framework.Xml;
using SPM2.SharePoint.Model;
using SPM2.SharePoint.Rules;
using SPM2.Framework.IoC;

namespace SPM2.SharePoint
{
    [IoCLifetime(Singleton = true)]
    public class SPNodeProvider : ISPNodeProvider
    {
        public const string AddInId = "SPM2.SharePoint.SPNodeProvider";
        public int ViewLevel { get; set; }
        public SPFarm Farm { get; set; }

        public Func<string, string> GetLocalizedTextFunction { get; set; }

        public IContainerAdapter IoCContainer { get; set; }        


        private FirstAcceptRuleEngine<ISPNode> _ruleEngine;

        public SPNodeProvider(SPFarm farm, IEnumerable<IRule<ISPNode>> rules, IContainerAdapter container)
        {
            ViewLevel = 100;
            Farm = farm;
            IoCContainer = container;

            _ruleEngine = new FirstAcceptRuleEngine<ISPNode>(rules);
        }




        public ISPNode LoadFarmNode()
        {
            var node = new SPFarmNode();
            node.Initialize(new NullPropertyDescriptor("Farm"), new NullSPNode(this), Farm, 0);

            return node;
        }


        public string GetLocalizedText(string text)
        {
            if (GetLocalizedTextFunction != null)
            {
                return GetLocalizedTextFunction(text);
            }
            return text;
        }

        public IEnumerable<ISPNode> LoadCollectionChildren(ISPNodeCollection parentNode, int batchCount)
        {
            var list = new List<ISPNode>();
            if (parentNode.SPObject == null) return list;

            int count = 0;
            
 
            if (parentNode.Pointer == null)
            {
                parentNode.ClearChildren();
                parentNode.TotalCount = 0;
                var collection = (IEnumerable)parentNode.SPObject;
                parentNode.Pointer = collection.GetEnumerator();
                //parentNode.Pointer.Reset();
                parentNode.LoadingChildren = parentNode.Pointer.MoveNext();
            }

            while (count < batchCount && parentNode.LoadingChildren)
            {

                var current = parentNode.Pointer.Current;

                var node = CreateCollectionNode(parentNode, current.GetType());

                if (node != null)
                {
                    node.Initialize(new NullPropertyDescriptor(parentNode.Text), parentNode, parentNode.Pointer.Current, parentNode.TotalCount);
                    if (RunIncludeRules(node))
                    {
                        node.Setup(parentNode);
                        list.Add(node);
                    }
                }
                
                parentNode.LoadingChildren = parentNode.Pointer.MoveNext();
                
                count++;
                parentNode.TotalCount++;

            }

            if (parentNode.TotalCount <= batchCount)
            {
                // There are a low number of nodes, therefore sort nodes by Text.
                return list.OrderBy(p => p.Text);
            }
            // Just add the elements without any sort, because of the high number of nodes.
            return list;
        }

        public IEnumerable<ISPNode> LoadChildren(ISPNode node)
        {
            return LoadUnorderedChildren(node).OrderBy(p => p.Text);
        }

        public IEnumerable<ISPNode> LoadUnorderedChildren(ISPNode sourceNode)
        {
            var list = new List<ISPNode>();

            if (sourceNode.SPObject == null) return list;

            ISPNode node = null;

            var propertyDescriptors = TypeDescriptor.GetProperties(sourceNode.SPObjectType);
            try
            {
                foreach (PropertyDescriptor descriptor in propertyDescriptors)
                {
                    node = CreateNodeOrDefault(descriptor.PropertyType.FullName);
                    if (node == null) 
                        continue;

                    node.Initialize(descriptor, sourceNode, null, list.Count);

                    if (node.SPObject == null)
                        continue;

                    node.Setup(sourceNode);

                    // Exclude the node if it do not match the correct view
                    if (!RunIncludeRules(node)) continue;

                    list.Add(node);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + " : " + node.GetType().FullName + " : " + ex.StackTrace);
            }
            return list;
        }


        private ISPNode CreateCollectionNode(ISPNodeCollection parentNode, Type spObejctType)
        {
            ISPNode node = CreateNodeOrDefault(spObejctType.FullName);
            if (node == null)
            {
                node = FindDefaultNode(parentNode, spObejctType);
            }
            return node;
        }

        private ISPNode FindDefaultNode(ISPNodeCollection parentNode, Type spObejctType)
        {
            ISPNode result = null;

            Type spType = null;

            var attr = spObejctType.GetAttribute<ClientCallableTypeAttribute>(true);
            if (attr != null)
            {
                spType = attr.CollectionChildItemType;
            }

            if (spType == null)
            {
                Type[] argTypes = spObejctType.GetBaseGenericArguments();
                if (argTypes != null && argTypes.Length == 1)
                {
                    spType = argTypes[0];
                }
            }

            if (spType != null)
            {
                result = CreateNodeOrDefault(spType.FullName);
            }

            if(result == null && spObejctType != typeof(object))
            {
                result = CreateCollectionNode(parentNode, spObejctType.BaseType);
            }



            return result;
        }

        private bool RunIncludeRules(ISPNode node)
        {
            return _ruleEngine.Check(node, true);
        }




        //public Dictionary<Type, ISPNode> GetChildrenTypes(ISPNode parentNode)
        //{
        //    IEnumerable<Lazy<SPNode>> importedNodes = CompositionProvider.GetExports<SPNode>(parentNode.Descriptor.ClassType);
        //    var types = new Dictionary<Type, ISPNode>();
        //    foreach (var lazyItem in importedNodes)
        //    {
        //        SPNode node = lazyItem.Value;
        //        node.NodeProvider = parentNode.NodeProvider;
        //    }
        //    return types;
        //}

        public string Serialize(ISPNode node)
        {
            string xml = Serializer.ObjectToXML(node);
            return xml;
        }

        public ISPNode Deserialize(string xml)
        {
            if (String.IsNullOrEmpty(xml)) return null;
            return Serializer.XmlToObject<SPFarmNode>(xml);
        }

        private ISPNode CreateNodeOrDefault(string spObjectTypeFullname)
        {
            var node = IoCContainer.ResolveOrDefault<ISPNode>(spObjectTypeFullname);
            return node;
            //if (node == null) return null;
            //return (ISPNode)Activator.CreateInstance(node.GetType());
        }

 

    }
}