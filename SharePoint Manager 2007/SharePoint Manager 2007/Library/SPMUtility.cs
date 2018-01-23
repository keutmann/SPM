using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

using Microsoft.SharePoint;


namespace Keutmann.SharePointManager.Library
{
    public static class SPMUtility
    {
        public static string FormatXml(string xml)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);

            StringWriter sw = new StringWriter();
            XmlTextWriter writer = new XmlTextWriter(sw);
            writer.Formatting = Formatting.Indented;

            xmlDoc.Save(writer);

            return sw.ToString();
        }

        public static SPMObjectType GetSPMObjectType(Type objType)
        {
            SPMObjectType spmOType = SPMObjectType.Unknown;
            try
            {
                spmOType = (SPMObjectType)Enum.Parse(typeof(SPMObjectType), objType.Name, true);
            }
            catch
            {
            }
            return spmOType;
        }

        public static SPMObjectType IdentifyObject(object obj)
        {
            if (obj is SPFolder)
            {
                SPFolder folder = (SPFolder)obj;

                if (folder.UniqueId.Equals(folder.ParentWeb.RootFolder.UniqueId))
                {
                    return SPMObjectType.SPWeb;
                }
                else
                {

                    SPList list = folder.ParentWeb.Lists[folder.ParentListId];
                    if (folder.UniqueId.Equals(list.RootFolder.UniqueId))
                    {
                        if (list is SPDocumentLibrary)
                        {
                            return SPMObjectType.SPDocumentLibrary;
                        }
                        else
                        {
                            return SPMObjectType.SPList;
                        }
                    }
                    else
                    {
                        return SPMObjectType.SPFolder;
                    }
                }
            }
            else if (obj is SPListItem)
            {
                return SPMObjectType.SPListItem;
            }
            else if (obj is SPFile)
            {
                return SPMObjectType.SPFile;
            }

            return SPMObjectType.Unknown;
        }

    }


    public sealed class SPMConfig
    {
        public CultureInfo CultureInfo = new CultureInfo(1033);

        

        #region Singleton

        SPMConfig()
        {
        }

        public static SPMConfig Instance
        {
            get
            {
                return Nested.instance;
            }
        }

        class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {
            }

            internal static readonly SPMConfig instance = new SPMConfig();
        }
        #endregion
    }

}
