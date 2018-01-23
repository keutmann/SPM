using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace SPM2.Framework
{
    public static class CollectionExtensions
    {
        public static void InsertRange<T>(this Collection<T> collection, int index, IEnumerable<T> source)
        {
            foreach (var item in source)
	        {
                collection.Insert(index++, item);
	        }
        }
    }
}
