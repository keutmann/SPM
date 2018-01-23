using System;
using System.IO;
using System.Security;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using Microsoft.SharePoint.Utilities;


namespace SPM2.SharePoint
{
    public class SPMPaths
    {

        private string _SharePointDirectory = string.Empty;
        public string SharePointDirectory
        {
            get
            {
                if (_SharePointDirectory.Length == 0)
                {
                    _SharePointDirectory = GetSharePointDirectory();
                }
                return _SharePointDirectory;
            }
        }

        private string _imageDirectory = string.Empty;
        public string ImageDirectory
        {
            get
            {
                if (_imageDirectory.Length == 0)
                {
                    _imageDirectory = Path.Combine(SharePointDirectory, @"TEMPLATE\IMAGES\");
                }
                return _imageDirectory;
            }
        }

        private string _featureDirectory = string.Empty;
        public string FeatureDirectory
        {
            get
            {
                if (_featureDirectory.Length == 0)
                {
                    _featureDirectory = Path.Combine(SharePointDirectory, @"TEMPLATE\FEATURE\");
                }
                return _featureDirectory;
            }
        }

        private string _templateDirectory = string.Empty;
        public string TemplateDirectory
        {
            get
            {
                if (_templateDirectory.Length == 0)
                {
                    _templateDirectory = Path.Combine(SharePointDirectory, @"TEMPLATE");
                }
                return _templateDirectory;
            }
        }

        public string GetSharePointDirectory()
        {
            string setupDir = SPUtility.GetGenericSetupPath("");
            return setupDir;
        }
    }

}
