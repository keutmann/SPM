using System;
using System.Text;

namespace SPM2.Framework
{
    public static class UriExtensions
    {

        public static string SchemeAndHost(this Uri uri)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("{0}://{1}", uri.Scheme, uri.DnsSafeHost);
            if (uri.Port != 80)
            {
                sb.AppendFormat(":{0}", uri.Port);
            }

            return sb.ToString();
        }


        public static string PathWithoutFile(this Uri uri)
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < uri.Segments.Length-1; i++)
            {
                sb.Append(uri.Segments[i]);
            }
            return sb.ToString();
        }

        public static string UrlWithoutFile(this Uri uri)
        {
            return uri.SchemeAndHost() + uri.PathWithoutFile();
        }
    }
}
