using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.ComponentModel.Composition;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace SPM2.Framework.Collections
{


    public class OrderingCollection<T> : AdaptingCollection<T, IOrderMetadata>
    {
        class SortItem
        {
            public string ID { get; set; }
            public Lazy<T, IOrderMetadata> Item { get; set; }
            public bool Used { get; set; }

            public List<SortItem> Children = new List<SortItem>();


            public IEnumerable<Lazy<T, IOrderMetadata>> ToCollection()
            {
                List<Lazy<T, IOrderMetadata>> result = new List<Lazy<T, IOrderMetadata>>();

                foreach (SortItem sortItem in this.Children.OrderBy(p => p.Item.Metadata.Order))
                {
                    result.Add(sortItem.Item);
                    result.AddRange(sortItem.ToCollection());
                }

                return result;
            }
        }

        class IndexDictionary : Dictionary<string, SortItem>
        {
            public IndexDictionary(IEnumerable<Lazy<T, IOrderMetadata>> collection)
            {
                foreach (var item in collection)
                {
                    if (!String.IsNullOrEmpty(item.Metadata.ID))
                    {
                        SortItem sortItem = new SortItem();
                        sortItem.ID = item.Metadata.ID;
                        sortItem.Item = item;
                        this.Add(sortItem.ID, sortItem);
                    }
                }
            }
        }


        public OrderingCollection()
            : base(Order)
        {

        }


        private static IEnumerable<Lazy<T, IOrderMetadata>> Order(IEnumerable<Lazy<T, IOrderMetadata>> collection)
        {
            IndexDictionary index = new IndexDictionary(collection);
            SortItem root = new SortItem();
            
            foreach (Lazy<T, IOrderMetadata> item in collection)
            {
                SortItem sourceItem = null;
                if (!String.IsNullOrEmpty(item.Metadata.ID) && index.ContainsKey(item.Metadata.ID))
                {
                    sourceItem = index[item.Metadata.ID];
                }
                else
                {
                    sourceItem = new SortItem();
                    sourceItem.Item = item;
                }

                
                if(!string.IsNullOrEmpty(item.Metadata.Before) && index.ContainsKey(item.Metadata.Before))
                {
                    SortItem targetItem = index[item.Metadata.Before];
                    if (!targetItem.Used)
                    {
                        sourceItem.Children.Add(targetItem);
                        targetItem.Used = true;
                    }
                }
                else
                    if(!string.IsNullOrEmpty(item.Metadata.After) && index.ContainsKey(item.Metadata.After))
                    {
                        if (!sourceItem.Used)
                        {
                            SortItem targetItem = index[item.Metadata.After];
                            targetItem.Children.Add(sourceItem);
                            sourceItem.Used = true;
                        }
                    }

                if(!sourceItem.Used)
                {
                    root.Children.Add(sourceItem);
                    sourceItem.Used = true;
                }
            }

            return root.ToCollection();
        }


        public IEnumerable<T> Values
        {
            get
            {
                return this.Select(p => p.Value);
            }
        }

    }

    //public class FilteringCollection<T, M> : AdaptingCollection<T, M>
    //{
    //    public FilteringCollection(Func<Lazy<T, M>, bool> filter)
    //        : base(e => e.Where(filter))
    //    {
    //    }
    //}

    //public class OrderingCollection<T, M> : AdaptingCollection<T, M>
    //{
    //    public OrderingCollection(Func<Lazy<T, M>, object> keySelector, bool descending = false)
    //        : base(e => descending ? e.OrderByDescending(keySelector) : e.OrderBy(keySelector))
    //    {
    //    }
    //}

    //public class AdaptingCollection<T> : AdaptingCollection<T, IDictionary<string, object>>
    //{
    //    public AdaptingCollection(Func<IEnumerable<Lazy<T, IDictionary<string, object>>>,
    //                                   IEnumerable<Lazy<T, IDictionary<string, object>>>> adaptor)
    //        : base(adaptor)
    //    {
    //    }
    //}


    public class AdaptingCollection<T, M> : ICollection<Lazy<T, M>>, INotifyCollectionChanged
    {
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        private readonly List<Lazy<T, M>> _allItems = new List<Lazy<T, M>>();
        private readonly Func<IEnumerable<Lazy<T, M>>, IEnumerable<Lazy<T, M>>> _adaptor = null;

        private List<Lazy<T, M>> _adaptedItems = null;
        private List<Lazy<T, M>> AdaptedItems
        {
            get
            {
                if (this._adaptedItems == null)
                {
                    this._adaptedItems = Adapt(this._allItems).ToList();
                }

                return this._adaptedItems;
            }
        }

        public AdaptingCollection()
            : this(null)
        {
        }

        public AdaptingCollection(Func<IEnumerable<Lazy<T, M>>, IEnumerable<Lazy<T, M>>> adaptor)
        {
            this._adaptor = adaptor;
        }

        public Lazy<T, M> this[int index]
        {
            get
            {
                return this.AdaptedItems[index];
            }
            set
            {
                this.AdaptedItems[index] = value;
            }
        }

        public void ReapplyAdaptor()
        {
            if (this._adaptedItems != null)
            {
                this._adaptedItems = null;
                this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            }
        }

        protected virtual IEnumerable<Lazy<T, M>> Adapt(IEnumerable<Lazy<T, M>> collection)
        {
            if (this._adaptor != null)
            {
                return this._adaptor.Invoke(collection);
            }

            return collection;
        }

        protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            NotifyCollectionChangedEventHandler collectionChanged = this.CollectionChanged;

            if (collectionChanged != null)
            {
                collectionChanged.Invoke(this, e);
            }
        }


        #region ICollection Implementation
        // Accessors work directly against adapted collection
        public bool Contains(Lazy<T, M> item)
        {
            return this.AdaptedItems.Contains(item);
        }

        public void CopyTo(Lazy<T, M>[] array, int arrayIndex)
        {
            this.AdaptedItems.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return this.AdaptedItems.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public IEnumerator<Lazy<T, M>> GetEnumerator()
        {
            return this.AdaptedItems.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        // Mutation methods work against complete collection
        // and then force a reset of the adapted collection
        public void Add(Lazy<T, M> item)
        {
            this._allItems.Add(item);
            ReapplyAdaptor();
        }

        public void Clear()
        {
            this._allItems.Clear();
            ReapplyAdaptor();
        }

        public bool Remove(Lazy<T, M> item)
        {
            bool removed = this._allItems.Remove(item);
            ReapplyAdaptor();
            return removed;
        }
        #endregion

    }
}
