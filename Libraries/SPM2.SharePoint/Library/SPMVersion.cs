using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint.Utilities;
using System.IO;
using Microsoft.Win32;

namespace SPM2.SharePoint
{
    public class SPMVersion
    {
        public const String SpfPath = @"SOFTWARE\Microsoft\Shared Tools\Web Server Extensions";

        public int Year { get; set; }
        public int Office { get; set; }
        public string Number { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }

        public SPMVersion()
        {
            Name = "SharePoint Manager";
            Number = "1.0.12.1106";

            var key = Registry.LocalMachine.OpenSubKey(SpfPath);
            if (key != null)
            {
                var subkey = key.OpenSubKey("12.0");
                if (subkey != null)
                {
                    Year = 2007;
                    Office = 12;
                }

                subkey = key.OpenSubKey("14.0");
                if (subkey != null)
                {
                    Year = 2010;
                    Office = 14;
                }

                subkey = key.OpenSubKey("15.0");
                if (subkey != null)
                {
                    Year = 2013;
                    Office = 15;
                }

            }

            Title = (Year > 0) ? String.Format("{0} {1}", Name, Year) : Name;
        }
    }
}
