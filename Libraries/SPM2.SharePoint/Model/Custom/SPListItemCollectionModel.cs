using System;
using System.Collections;
using System.Globalization;
using System.Text;
using Microsoft.SharePoint;

namespace SPM2.SharePoint.Model
{

    public class SPListItemCollectionEnumerator : IEnumerator
    {

        private SPList _list;

        private SPQuery _query;

        private SPListItemCollection _items;
        private bool lastBatch;
        private IEnumerator _itemEnumerator;

        public SPListItemCollectionEnumerator(SPList list)
        {
            if (list == null)
            {
                throw new System.ArgumentNullException("list");
            }

            _list = list;
            Reset();
        }

        public object Current
        {
            get
            {
                if (_itemEnumerator == null)
                    return null;

                return _itemEnumerator.Current;
            }
        }

        public bool MoveNext()
        {
            if (_items == null)
            {
                GetItems();
            }

            var moveNext = _itemEnumerator.MoveNext();

            if (!moveNext && !lastBatch)
            {
                GetItems();
                moveNext = _itemEnumerator.MoveNext();
            }

            return moveNext;
        }

        private void GetItems()
        {
            if (_query == null)
            {
                _query = new SPQuery
                            {
                                ViewAttributes = "Scope=\"Recursive\"",
                                RowLimit = 300
                            };
            }

            _items = _list.GetItems(_query);
            _itemEnumerator = _items.GetEnumerator();
            _query.ListItemCollectionPosition = _items.ListItemCollectionPosition;
            lastBatch = (_query.ListItemCollectionPosition == null);
        }

        public void Reset()
        {
            _query = null;
            _items = null;
        }



    }

    public class SPListItemCollectionModel : IEnumerable
    {
        private int _itemCount = 0;
        public int ItemCount {
            get{
                return _itemCount;
            }
        }

        SPListItemCollectionEnumerator _enumerator;

        public SPListItemCollectionModel(SPList list)
        {
            if (list == null)
            {
                throw new System.ArgumentNullException("list");
            }

            _itemCount = list.ItemCount;
            _enumerator = new SPListItemCollectionEnumerator(list);
        }

        public IEnumerator GetEnumerator()
        {
            return _enumerator;
        }




    }
}
