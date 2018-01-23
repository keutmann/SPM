using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace SPM2.Framework
{
    public static class HashAlgorithmExtensions
    {
        public static string GetHash(this HashAlgorithm alg, string text)
        {
            string result = null;

            // Convert plain text into a byte array.
            byte[] textBytes = Encoding.UTF8.GetBytes(text);

            byte[] hashBytes = alg.ComputeHash(textBytes);

            // Convert result into a base64-encoded string.
            result = Convert.ToBase64String(hashBytes);

            return result;
        }


        public static string GetHash(string text)
        {
            HashAlgorithm alg = HashAlgorithm.Create();
            return alg.GetHash(text);
        }
    }
}
