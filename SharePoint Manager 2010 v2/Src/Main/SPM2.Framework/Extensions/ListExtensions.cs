using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPM2.Framework
{
    public static class ListExtensions
    {
        public static void AddOrReplace<T>(this List<T> source, T value)
        {
            T obj = source.FirstOrDefault<T>((p) => p.Equals(value));
            if (obj != null)
            {
                source.Remove(obj);
            }
            source.Add(value);
        }
    }
}
