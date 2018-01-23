using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using SPM2.Framework;
using SPM2.Framework.Collections;
using SPM2.Framework.ComponentModel;

namespace SPM2.SharePoint.Model
{
    public class SPNode : ISPNode
    {
        public const string ResourceImagePath = "/SPM2.SharePoint;component/Resources/Images/";
        private ClassDescriptor _descriptor;
        private string _iconUri;
        private object _spObject;
        private Type _spObjectType;
        private object _text;
        private string _toolTipText;

        public virtual string SPTypeName { get; set; }
        public List<ISPNode> Children { get; set; }

        public Dictionary<Type, ISPNode> NodeTypes { get; set; }

        public ISPNodeProvider NodeProvider { get; set; }

        public string TextColor { get; set; }

        public virtual string ToolTipText
        {
            get
            {
                if (String.IsNullOrEmpty(_toolTipText))
                {
                    _toolTipText = Descriptor.ClassType.Name;
                }
                return _toolTipText;
            }
            set { _toolTipText = value; }
        }

        public virtual string IconUri
        {
            get
            {
                if (String.IsNullOrEmpty(_iconUri))
                {
                    if (Descriptor.Icon != null)
                    {
                        string name = Descriptor.Icon.Small;
                        if (!String.IsNullOrEmpty(name) && !"BULLET.GIF".Equals(name, StringComparison.Ordinal))
                        {
                            switch (Descriptor.Icon.Source)
                            {
                                case IconSource.File:
                                    _iconUri = SharePointContext.GetImagePath(Descriptor.Icon.Small);
                                    break;
                                default:
                                    _iconUri = GetResourceImagePath(Descriptor.Icon.Small);
                                    break;
                            }
                        }
                    }

                    if (String.IsNullOrEmpty(_iconUri))
                    {
                        _iconUri = Path.Combine(SharePointContext.ImagePath, "mbllistbullet.gif");
                    }
                }
                return _iconUri;
            }
            set { _iconUri = value; }
        }

        #region ISPNode Members

        public virtual string AddInID { get; set; }
        public virtual string Url { get; set; }


        public object SPObject
        {
            get { return _spObject ?? (_spObject = GetSPObject()); }
            set { _spObject = value; }
        }


        public object SPParent { get; set; }

        public ClassDescriptor Descriptor
        {
            get { return _descriptor ?? (_descriptor = new ClassDescriptor(GetType())); }
            set { _descriptor = value; }
        }

        public Type SPObjectType
        {
            get
            {
                if (_spObjectType == null)
                {
                    if (_spObject != null)
                    {
                        _spObjectType = _spObject.GetType();
                    }

                    if (_spObjectType == null)
                    {
                        var attrib = GetType().GetAttribute<AdapterItemTypeAttribute>(true);
                        if (attrib != null)
                        {
                            _spObjectType = Type.GetType(attrib.Name, true, false);
                        }
                    }

                    if (_spObjectType != null)
                    {
                        PropertyGridTypeConverter.AddTo(_spObjectType);
                    }
                }
                return _spObjectType;
            }
            set { _spObjectType = value; }
        }

        public virtual object Text
        {
            get
            {
                if (String.IsNullOrEmpty(_text + string.Empty))
                {
                    _text = Descriptor.GetTitle(SPObject);
                }
                return _text;
            }
            set { _text = value; }
        }


        
        public SPNode()
        {
            TextColor = "Black";
            Children = new List<ISPNode>();
        }

        public virtual void Setup(object spParent)
        {
            SPParent = spParent;
        }

        public virtual object GetSPObject()
        {
            object result = null;
            if (SPParent != null)
            {
                PropertyDescriptorCollection des = TypeDescriptor.GetProperties(SPParent.GetType());
                foreach (PropertyDescriptor info in des)
                {
                    if (SPObjectType == info.PropertyType)
                    {
                        // Use the name from the Property in the object model.
                        Descriptor.Title = info.DisplayName;

                        result = info.GetValue(SPParent);

                        break;
                    }
                }
            }

            return result;
        }

        public virtual Type GetSPObjectType()
        {
            return SPObjectType;
        }

        #endregion

        public IEnumerable<object> GetContextMenuItems()
        {
            var result = new List<object>();

            try
            {
                result.AddRange(LoadContextMenuNodes(typeof (SPNode)));
                result.AddRange(LoadContextMenuNodes(GetType()));
            }
            catch (Exception ex)
            {
#if DEBUG
                Trace.Fail(ex.Message, ex.StackTrace);
#else
                Trace.Fail(ex.Message);
#endif

                throw;
            }

            return result;
        }

        private IEnumerable<object> LoadContextMenuNodes(Type fromType)
        {
            var result = new List<object>();
            OrderingCollection<IContextMenuItem> orderedItems =
                CompositionProvider.GetOrderedExports<IContextMenuItem>(fromType);
            foreach (var item in orderedItems)
            {
                IContextMenuItem menuItem = item.Value;
                menuItem.SetupItem(this);
                result.Add(menuItem);
            }
            return result;
        }


        public virtual void Update()
        {
            if (SPObject != null)
            {
                SPObject.InvokeMethod("Update", true);
            }
        }

        public static string GetResourceImagePath(string filename)
        {
            return ResourceImagePath + filename;
        }


        public virtual void LoadChildren()
        {
            if (SPObject != null)
            {
                ClearChildren();
                EnsureNodeTypes();
#if DEBUG
                var watch = new Stopwatch();
                watch.Start();
#endif
                Children.AddRange(NodeProvider.LoadChildren(this)); 

#if DEBUG
                watch.Stop();
                Trace.WriteLine(String.Format("Load Properties: Type:{0} - Time {1} milliseconds.",
                                              SPObjectType.Name, watch.ElapsedMilliseconds));
#endif
            }
        }

        public virtual void EnsureNodeTypes()
        {
            if (NodeTypes == null)
            {
                NodeTypes = NodeProvider.GetChildrenTypes(this);
            }
        }


        public virtual void ClearChildren()
        {
            Children.Clear();
        }


        public virtual IEnumerable<SPNode> NodesToExpand()
        {
            return null;
        }

        public virtual bool IsDefaultSelected()
        {
            return false;
        }


        //public virtual SPNode Refresh()
        //{
        //    SPNode result = this;
        //    Type webType = typeof(SPWeb);
        //    Type siteType = typeof(SPSite);

        //    List<int> indexs = new List<int>();

        //    SPNode target = this;
        //    SPNode parent = target.Parent as SPNode;
        //    if (parent == null)
        //    {
        //        return result;
        //    }

        //    int selectedIndex = target.Parent.Children.IndexOf(target);

        //    indexs.Add(selectedIndex);

        //    foreach (var node in target.Ancestors().OfType<SPNode>())
        //    {
        //        if (node.Parent == null)
        //        {
        //            break;
        //        }

        //        indexs.Insert(0, node.Parent.Children.IndexOf(node));

        //        if (node.SPObjectType == webType || node.SPObjectType == siteType)
        //        {
        //            target = node;
        //            parent = target.Parent as SPNode;

        //            break;
        //        }
        //    }

        //    if (target == this)
        //    {
        //        indexs = new List<int> { selectedIndex }; 
        //    }


        //    var enumerator = indexs.GetEnumerator();
        //    if (enumerator.MoveNext())
        //    {
        //        foreach (var node in parent.Descendants())
        //        {
        //            node.Text += " Old";
        //        }
        //        parent.LazyLoading = true;
        //        parent.ClearChildren();
        //        parent.IsExpanded = true;
        //        result = parent.RefreshNodes(enumerator);
        //    }
        //    return result;
        //}


        //internal SPNode RefreshNodes(IEnumerator<int> enumerator)
        //{
        //    SPNode result = null;
        //    int index = enumerator.Current;
        //    bool lastIndex = !enumerator.MoveNext();

        //    if (this.Children.Count > index)
        //    {
        //        SPNode child = this.Children[index] as SPNode;

        //        if (lastIndex)
        //        {
        //            child.IsSelected = true;
        //            result = child;
        //        }
        //        else
        //        {
        //            // IsExpanded = true; Auto load of new nodes
        //            child.IsExpanded = true;
        //            result = child.RefreshNodes(enumerator);
        //        }

        //    }
        //    return result;
        //}
    }
}