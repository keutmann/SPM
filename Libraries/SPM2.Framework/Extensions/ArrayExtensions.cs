using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Collections.ObjectModel;

namespace SPM2.Framework
{
    public static class ArrayExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> obj)
        {
            return !(obj != null && obj.Count() > 0);
        }


        public static void AddRange<T>(this Collection<T> range, IEnumerable<T> collection)
        {
            if(collection == null)
            {
                return;
            }

            foreach (var item in collection)
            {
                range.Add(item);
            }
        }

        /// <summary>
        /// Returns an array of objects and if the array is null an empty Array is then returned.
        /// This will prevent the "Object is not set to an instance of an object" exception.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>An array</returns>
        public static IEnumerable<T> AsSafeEnumable<T>(this IEnumerable<T> arrayObj)
        {
            IEnumerable<T> result = IsNullOrEmpty(arrayObj) ? new T[0] : arrayObj;
            return result;
        }


 
    }
}
