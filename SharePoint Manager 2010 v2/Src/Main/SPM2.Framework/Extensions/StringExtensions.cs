using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPM2.Framework
{
    public static class StringExtensions
    {
        public static string GetString(this string text, string defaultValue)
        {
            string result = text;
            if (String.IsNullOrEmpty(result))
            {
                result = defaultValue;
            }
            return result;
        }

        public static string SetDefault(this string text, string defaultValue)
        {
            
            if (String.IsNullOrEmpty(text))
            {
            }
            return "";
        }
    }
}
