using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using SPM2.Framework;
using SPM2.Framework.Collections;
using SPM2.Framework.ComponentModel;
using SPM2.Framework.Diagnostics;
using SPM2.Framework.Xml;
using SPM2.Framework.IoC;

namespace SPM2.SharePoint.Model
{
    [Serializable]
    public abstract class  SPNode : NotifyPropertyChanged, ISPNode, IDisposable
    {

        private ClassDescriptor _descriptor;
        private string _iconUri;
        private object _spObject;
        private Type _spObjectType;
        private string _text;
        private string _toolTipText;

        #region ISPNode Members

        public virtual string Text
        {
            get
            {
                return _text;
            }
            set 
            {
                var localText = NodeProvider.GetLocalizedText(value+"_Text");
                if (localText == null)
                    localText = value;

                if (_text != localText)
                {
                    _text = localText;
                    OnPropertyChanged("Text");
                }
            }
        }

        [XmlIgnore]
        public virtual string ToolTipText
        {
            get
            {
                if (String.IsNullOrEmpty(_toolTipText))
                {
                    _toolTipText = SPTypeName;
                }
#if DEBUG
                return _toolTipText + " (ID:" + this.ID + ")";

#else
                return _toolTipText;
#endif

            }
            set {
                var localText = NodeProvider.GetLocalizedText(value + "_ToolTip");
                if (localText == null)
                    localText = value;

                if (_toolTipText != localText)
                {
                    _toolTipText = localText;
                    OnPropertyChanged("ToolTip");
                }                
            }
        }


        private string _spTypeName = null;
        public virtual string SPTypeName
        {
            get
            {
                if (String.IsNullOrEmpty(_spTypeName))
                {
                    _spTypeName = SPObjectType.Name;
                }
                return _spTypeName;
            }
            set { _spTypeName = value; }
        }

        public virtual string ID { get; set; }
        public virtual int Index { get; set; }

 
        [XmlIgnore]
        public virtual ISPNodeProvider NodeProvider { get; set; }

        [XmlIgnore]
        public virtual string State { get; set; }

        [XmlIgnore]
        public virtual ISPNode Parent { get; set; }


        [XmlIgnore]
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
                                case IconSource.SharePointImageFile:
                                    _iconUri = SharePointContext.GetImagePath(Descriptor.Icon.Small);
                                    break;
                                default:
                                    _iconUri = GetResourceImagePath(Descriptor);
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

        [XmlIgnore]
        public virtual string AddInID { get; set; }

        [XmlIgnore]
        public virtual string Url { get; set; }

        [XmlIgnore]
        public object SPObject
        {
            get { return _spObject ?? (_spObject = GetSPObject()); }
            set { _spObject = value; }
        }


        [XmlIgnore]
        public ClassDescriptor Descriptor
        {
            get { return _descriptor ?? (_descriptor = new ClassDescriptor(GetType())); }
            set { _descriptor = value; }
        }

        [XmlIgnore]
        public PropertyDescriptor ParentPropertyDescriptor { get; set; }

        [XmlIgnore]
        public virtual Type SPObjectType
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
                            _spObjectType = Type.GetType(attrib.Fullname, true, false);
                        }
                    }
                }
                return _spObjectType;
            }
            set { _spObjectType = value; }
        }

        public SerializableList<ISPNode> Children { get; set; }

        public SPNode()
        {
            State = "Black";
            Children = new SerializableList<ISPNode>();
        }

        public virtual void Setup(ISPNode parent)
        {
            if (parent == null) return;

            Parent = parent;
            NodeProvider = parent.NodeProvider;

            if(ParentPropertyDescriptor == null)
                ParentPropertyDescriptor = new NullPropertyDescriptor(parent);

            if (String.IsNullOrEmpty(ID))
            {
                if (parent is ISPNodeCollection && SPObject != null)
                {
                    ID = GetCollectionItemID(SPObject, Index);
                }
                else
                {
                    ID = ParentPropertyDescriptor.GetHashCode().ToString();
                }

            }

            var tempText = GetTitle();
            Text = tempText;
            //ToolTipText = tempText;

            // Make sure to update all children if exist!
            foreach (var item in Children)
            {
                item.Setup(this);
                if (item.Children.Count > 0)
                {
                    item.LoadChildren();
                }
            }
        }

        private string GetCollectionItemID(object spObject, int index)
        {
            string result = null;
            var flags = BindingFlags.IgnoreCase | BindingFlags.FlattenHierarchy | BindingFlags.Instance | BindingFlags.Public;
            if (String.IsNullOrEmpty(result))
            {
                if (spObject.PropertyExist("id", flags))
                {
                    result = spObject.GetPropertyValue<object>("id", flags) + string.Empty;
                }
            }

            if (String.IsNullOrEmpty(result))
            {
                if (spObject.PropertyExist("uniqueid", BindingFlags.IgnoreCase))
                {
                    result = spObject.GetPropertyValue<object>("uniqueid", flags) + string.Empty;
                }
            }

            if (String.IsNullOrEmpty(result))
            {
                if (spObject.PropertyExist("name", BindingFlags.IgnoreCase))
                {
                    result = spObject.GetPropertyValue<object>("name", flags) + string.Empty;
                }
            }

            if (String.IsNullOrEmpty(result))
            {
                result = index.ToString();
            }

            return result;
        }


        protected virtual string GetTitle()
        {
            string rawText = null;

            if (this.Parent is ISPNodeCollection)
            {
                if (String.IsNullOrEmpty(Text))
                {
                    rawText = SPObjectType.Name;
                }


                rawText = Descriptor.GetTitle(SPObject, rawText);
            }

            if (String.IsNullOrEmpty(rawText))
            {
                rawText = this.ParentPropertyDescriptor.DisplayName;
            }

            if (String.IsNullOrEmpty(rawText))
            {
                rawText = this.ParentPropertyDescriptor.Name;
            }

            return rawText;
        }

        public virtual object GetSPObject()
        {
            object result = null;

            // This ensures that a chain of objects are created
            if (Parent.SPObject == null) return result;
            if (ParentPropertyDescriptor == null) return result;

            try
            {
                result = ParentPropertyDescriptor.GetValue(Parent.SPObject);
            }
            catch 
            {
                // Sometimes its not possible to get the object at this point.
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
            //OrderingCollection<IContextMenuItem> orderedItems =
            //    CompositionProvider.GetOrderedExports<IContextMenuItem>(fromType);
            //foreach (var item in orderedItems)
            //{
            //    IContextMenuItem menuItem = item.Value;
            //    menuItem.SetupItem(this);
            //    result.Add(menuItem);
            //}
            return result;
        }


        public virtual void Update()
        {
            if (SPObject != null)
            {
                SPObject.InvokeMethod("Update", true);
            }
        }

        public static string GetResourceImagePath(ClassDescriptor descriptor )
        {
            string name = descriptor.Icon.Small;

            if (String.IsNullOrEmpty(name)) return string.Empty;

            var assembly = descriptor.ClassType.Assembly;
            var length = name.LastIndexOf('.');
            if(length < 1) return string.Empty;

            var path = name.Substring(0, length); // "SPM2.SharePoint.Properties.Resources";
            name = name.Substring(length+1);

            if (String.IsNullOrEmpty(name)) return string.Empty;

            var result = String.Format("{0};{1};{2}", assembly.FullName, path, name);
            //Trace.WriteLine("Resource: " + result);
            return result;
        }
        
        public virtual void LoadChildren()
        {
            Children.AddRange(NodeProvider.LoadChildren(this));
        }

        public virtual void ClearChildren()
        {
            Children.Clear();
        }

        public virtual bool HasChildren()
        {

            //var propertyDescriptors = TypeDescriptor.GetProperties(node.SPObjectType);
            //foreach (PropertyDescriptor descriptor in propertyDescriptors)
            //{
            //    var export = CompositionProvider.Current.GetExportedValueOrDefault<ISPNode>(descriptor.PropertyType.FullName);
            //    if (export != null)
            //        return true;
            //}

            return true;
        }


        public virtual bool IsDefaultSelected()
        {
            return false;
        }

 

        public void Dispose()
        {
            foreach (ISPNode child in Children)
            {
                child.Dispose();
            }

            if (SPObject == null) return;
            if (SPObject is IDisposable)
            {
                try
                {
                    ((IDisposable)SPObject).Dispose();
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.Message);
                }
            }
            else if (SPObject is SPPersistedObject)
            {
                try
                {
                    ((SPPersistedObject)SPObject).Uncache();
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.Message);
                }
            }

        }

    }
}