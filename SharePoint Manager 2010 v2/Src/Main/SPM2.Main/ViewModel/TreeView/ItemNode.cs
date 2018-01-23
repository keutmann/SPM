using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ICSharpCode.TreeView;
using SPM2.Framework.WPF.ViewModel.TreeView;
using SPM2.SharePoint.Model;
using System.Collections.ObjectModel;

namespace SPM2.Main.ViewModel.TreeView
{
    /// <summary>
    /// Base class for all ViewModel classes displayed by TreeViewItems.  
    /// This acts as an adapter between a raw data object and a TreeViewItem.
    /// </summary>
    [Serializable]
    public class ItemNode : SharpTreeNode, IItemNode
    {
        #region Data

        private bool _isHidden;

        public ISPNode SPNode { get; set; }

        public ITreeViewNodeProvider NodeProvider
        {
            get; set;
        }

        public override string IconUri
        {
            get
            {
                return SPNode.IconUri;
            }
            set
            {
                SPNode.IconUri = value;
            }
        }

        [Browsable(false)]
        public override object Text
        {
            get { return SPNode.Text; }
            set { SPNode.Text = value; }
        }

        //private string _description = null;
        //public string Description
        //{
        //    get { return _description; }
        //    set { _description = value; }
        //}

        [Browsable(false)]
        public virtual string ToolTipText
        {
            get { return SPNode.ToolTipText; }
            set { SPNode.ToolTipText = value; }
        }


        //static readonly IItemNode DummyChild = new DummyChild();

        ///// <summary>
        ///// Returns true if this object's Children have not yet been populated.
        ///// </summary>
        //[Browsable(false)]
        //[XmlIgnore]
        //public bool HasDummyChild
        //{
        //    get { return this.Children.Count == 1 && this.Children[0] is DummyChild; }
        //}


        //bool _isExpanded;
        ///// <summary>
        ///// Gets/sets whether the TreeViewItem 
        ///// associated with this object is expanded.
        ///// </summary>
        //[Browsable(false)]
        //[XmlAttribute]
        //public override bool IsExpanded
        //{
        //    get { return _isExpanded; }
        //    set
        //    {
        //        if (value != _isExpanded)
        //        {
        //            _isExpanded = value;
        //            this.OnPropertyChanged("IsExpanded");
        //        }

        //        // Lazy load the child items, if necessary.
        //        if (this.HasDummyChild)
        //        {
        //            this.LoadChildren();
        //            this.LazyLoading = false;
        //        }
        //    }
        //}


        /// <summary>
        /// Gets/sets whether the TreeViewItem is hidden
        /// </summary>
        [Browsable(false)]
        [XmlAttribute]
        public bool IsHidden
        {
            get { return _isHidden; }
            set
            {
                if (value != _isHidden)
                {
                    _isHidden = value;
                    RaisePropertyChanged("IsHidden");
                }
            }
        }

        //private bool _isFocused = false;
        ///// <summary>
        ///// Gets/Sets whether the TreeViewItem is in focus.
        ///// </summary>
        //public bool IsFocused
        //{
        //    get { return _isFocused; }
        //    set 
        //    {
        //        if (value != _isFocused)
        //        {
        //            _isFocused = value;
        //            this.OnPropertyChanged("IsFocused");
        //        }
        //    }
        //}

        private IItemNode _parent;
        [Browsable(false)]
        [XmlIgnore]
        public IItemNode Parent
        {
            get { return _parent; }
        }

        /// <summary>
        /// Sets the color of the text.
        /// </summary>
        [Browsable(false)]
        [XmlAttribute]
        public string TextColor
        {
            get { return SPNode.TextColor; }
            set
            {
                if (SPNode.TextColor != value)
                {
                    SPNode.TextColor = value;
                    RaisePropertyChanged("TextColor");
                }
            }
        }


        //[Browsable(false)]
        //[XmlAttribute]
        //public string ContextMenuVisible
        //{
        //    get 
        //    { 
        //        return (this.ContextMenuItems != null && this.ContextMenuItems.Count > 0) ? "Visible" : "Hidden"; 
        //    }
        //}

        //private bool _lazyLoadChildren = true;
        //[Browsable(false)]
        //[XmlAttribute]
        //public bool LazyLoadChildren
        //{
        //    get { return _lazyLoadChildren; }
        //    set { _lazyLoadChildren = value; }
        //}


        //private ObservableCollection<IItemNode> _children = null;
        ///// <summary>
        ///// Returns the logical child items of this object.
        ///// </summary>
        //[Browsable(false)]
        //public new ObservableCollection<IItemNode> Children
        //{
        //    get
        //    {
        //        if (_children == null)
        //        {
        //            _children = new ObservableCollection<IItemNode>();
        //            if (this.LazyLoadChildren)
        //            {
        //                _children.Add(DummyChild);
        //            }
        //        }
        //        return _children;
        //    }
        //    set { _children = value; }
        //}

        #endregion // Data

        #region Constructors

        protected ItemNode()
            : this(null, true)
        {
        }

        protected ItemNode(ISharpTreeNode parent, bool lazyLoadChildren)
        {
            //this.Parent = parent;
            LazyLoading = lazyLoadChildren;
        }

        public static IItemNode Create(ITreeViewNodeProvider provider, ISPNode spNode)
        {
            var node = new ItemNode
                           {
                               NodeProvider =  provider,
                               SPNode = spNode
                           };
            return node;
        }

        #endregion // Constructors

        /// <summary>
        /// Invoked when the child items need to be loaded on demand.
        /// Subclasses can override this to populate the Children collection.
        /// </summary>
        public override void LoadChildren()
        {
            Children.Clear();
            if (NodeProvider != null)
            {
                foreach (SharpTreeNode node in NodeProvider.LoadChildren(this))
                {
                    Children.Add(node);
                }
            }
        }



        //public virtual void ResetChildren(bool lazy)
        //{
        //    ItemNode clone = Clone();
        //    ReloadChildren(this, clone);
        //    Children.Clear();
        //    foreach (SharpTreeNode child in clone.Children)
        //    {
        //        Children.Add(child);
        //    }

        //    //this.LazyLoading = lazy;
        //    //if (this.LazyLoading)
        //    //{
        //    //    //this.Children.Add(DummyChild);
        //    //}

        //    //if (this.IsExpanded)
        //    //{
        //    //    this.LoadChildren();
        //    //}
        //}


        //public virtual ItemNode Clone()
        //{
        //    var result = (ItemNode) Activator.CreateInstance(GetType());
        //    foreach (PropertyInfo prop in GetType().GetProperties())
        //    {
        //        if (prop.CanWrite && prop.CanRead)
        //        {
        //            //object value = prop.GetValue(this, null);
        //            //if(value != null)
        //            //{
        //            //    prop.SetValue(result, value, null);
        //            //}
        //        }
        //    }


        //    return result;
        //}


        //private void ReloadChildren(ItemNode source, ItemNode target)
        //{
        //    if (source.IsExpanded)
        //    {
        //        target.EnsureLazyChildren();
        //        if (source.Children.Count == target.Children.Count)
        //        {
        //            for (int i = 0; i < source.Children.Count; i++)
        //            {
        //                var childSource = source.Children[i] as ItemNode;
        //                var childTarget = target.Children[i] as ItemNode;
        //                ReloadChildren(childSource, childTarget);
        //            }
        //        }
        //    }
        //}

        #region INotifyPropertyChanged Members

        public new event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion // INotifyPropertyChanged Members



    }
}