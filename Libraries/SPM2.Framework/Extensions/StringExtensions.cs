using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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

        public static bool EqualsIgnorecase(this string text, object obj)
        {
            if (text == null) throw new ArgumentNullException("text");
            return text.Equals(obj as string, StringComparison.OrdinalIgnoreCase);
        }

        public static string TrimIndexOf(this string text, string value)
        {
            var result = text;
            if (String.IsNullOrEmpty(result))
                return result;

            var index =result.IndexOf(value);
            if (index >= 0)
                result = result.Substring(index + value.Length);

            return result;
        }

        public static string TrimLastIndexOf(this string text, string value)
        {
            var result = text;
            if (String.IsNullOrEmpty(result))
                return result;

            var index = result.LastIndexOf(value);
            if (index >= 0)
                result = result.Substring(index + value.Length);

            return result;
        }

        public static string TrimEndLastIndexOf(this string text, string value)
        {
            var result = text;
            if (String.IsNullOrEmpty(result))
                return result;

            var index = result.LastIndexOf(value);
            if (index >= 0)
                result = result.Substring(0, index);

            return result;
        }

        /// Like linq take - takes the first x characters    
        public static string Take(this string theString, int count, bool ellipsis = false)    
        {        
            int lengthToTake = Math.Min(count, theString.Length);        
            var cutDownString = theString.Substring(0, lengthToTake);        
            if (ellipsis && lengthToTake < theString.Length)            
                cutDownString += "...";        
            return cutDownString;    
        }    

        public static string Skip(this string theString, int count)    
        {        
            int startIndex = Math.Min(count, theString.Length);        
            var cutDownString = theString.Substring(startIndex - 1);       
            return cutDownString;   
        }    

        public static string Reverse(this string input)    
        {        
            char[] chars = input.ToCharArray();        
            Array.Reverse(chars);        
            return new String(chars);    
        }    
        
        public static bool IsBlankOrEmpty(this string theString)
        {        
            return string.IsNullOrEmpty(theString);    
        }    
        
       
        public static bool Match(this string value, string pattern)   
        {        
            return Regex.IsMatch(value, pattern);    
        }    


    }
}
