using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPM2.Framework
{
    public static class DictionaryExtensions
    {
        public static void AddOrReplace<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue value)
        {
            if (dict.ContainsKey(key))
            {
                dict[key] = value;
            }
            else
            {
                dict.Add(key, value);
            }
        }

        public static TValue GetValue<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue defaultValue)
        {
            TValue result = defaultValue;
            if (dict.ContainsKey(key))
            {
                result = dict[key];
            }
            return result;
        }

        public static TValue GetValue<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key)
        {
            return GetValue(dict, key, default(TValue));
        }
    }
}
