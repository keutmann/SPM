using System;
using System.IO;
using System.Security;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Administration;


namespace SPM2.SharePoint
{
    public sealed class SharePointContext
    {

        private string _sharePointRoot = string.Empty;
        private string sharePointRoot
        {
            get
            {
                if (_sharePointRoot.Length == 0)
                {
                    _sharePointRoot = SPUtility.GetGenericSetupPath("");
                }
                return _sharePointRoot;
            }
        }

        private string _imagePath = string.Empty;
        private string imagePath
        {
            get
            {
                if (_imagePath.Length == 0)
                {
                    _imagePath = Path.Combine(SharePointRootPath, @"TEMPLATE\IMAGES\");
                }
                return _imagePath;
            }
        }

        private string _templatePath = string.Empty;
        private string templatePath
        {
            get
            {
                if (_templatePath.Length == 0)
                {
                    _templatePath = Path.Combine(SharePointRootPath, @"TEMPLATE");
                }
                return _templatePath;
            }
        }

        private SPFarm _farm = null;
        public SPFarm Farm
        {
          get 
          { 
              if(_farm == null)
              {
                  _farm = SPFarm.Local;
              }
              return _farm; 
          }
          set 
          { 
              _farm = value; 
          }
        }


        private SPWebService _contentWebService = null;
        public SPWebService ContentWebService
        {
            get
            {
                if (_contentWebService == null)
                {
                    _contentWebService = Farm.Services.GetValue<SPWebService>("");
                }
                return _contentWebService;
            }
        }

        private SPWebService _AdministrationWebService = null;
        public SPWebService AdministrationWebService
        {
            get
            {
                if (_AdministrationWebService == null)
                {
                    _AdministrationWebService = Farm.Services.GetValue<SPWebService>("WSS_Administration");
                }
                return _AdministrationWebService;
            }
        }

        

        #region Static methods

        public static string SharePointRootPath
        {
            get
            {
                return Instance.sharePointRoot;
            }
        }

        public static string ImagePath
        {
            get
            {
                return Instance.imagePath;
            }
        }

        public static string TemplatePath
        {
            get
            {
                return Instance.templatePath;
            }
        }

        public static string GetImagePath(string filename)
        {
            return Path.Combine(ImagePath, filename);
        }

        #endregion 

        #region Singleton

        SharePointContext() : this(SPFarm.Local)
        {
        }

        public SharePointContext(SPFarm farm)
        {
            this.Farm = farm;
        }

        public static SharePointContext Instance
        {
            get
            {
                return Nested.instance;
            }
            set
            {
                Nested.instance = value;
            }
        }

        class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {
            }

            internal static SharePointContext instance = new SharePointContext();
        }
        #endregion
    }

}
