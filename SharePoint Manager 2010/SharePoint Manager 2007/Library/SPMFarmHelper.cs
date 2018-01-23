using System;
using System.Data;
using System.Data.Sql;
using System.Text;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System.Data.SqlClient;

namespace Keutmann.SharePointManager.Library
{
    public class SPMFarmHelper
    {
        public SPFarm Farm = null;

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

        public SPMFarmHelper(SPFarm farm)
        {
            this.Farm = farm;
        }

        private SPWebService GetService(string name)
        {
            SPWebService service = null;
            foreach (object obj in Farm.Services)
            {
                if (obj is SPWebService)
                {
                    SPWebService temp = obj as SPWebService;
                    if (string.Compare(temp.TypeName, name, true) == 0)
                    {
                        service = temp;
                        break;
                    }
                }
            }
            return service;
        }

        

    }
}
