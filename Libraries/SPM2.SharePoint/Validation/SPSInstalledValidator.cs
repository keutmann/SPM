// From: http://sharepointinstaller.codeplex.com/

using System;
using System.Security;
using Microsoft.Win32;
using SPM2.Framework.Validation;
using SPM2.Framework.IoC;

namespace SPM2.SharePoint.Validation
{
    // This check should be in a SPS project
    //[Export(typeof(BaseValidator))]
    [IoCIgnore()]
    public class SPSInstalledValidator : BaseValidator
    {
        public const String SPSPath = @"SOFTWARE\Microsoft\Office Server\15.0";

        public SPSInstalledValidator()
            : base()
        {
        }

        //public SPSInstalledValidator(String id)
        //    : base(id)
        //{
        //}

        protected override ValidationResult Validate()
        {
            try
            {
                var key = Registry.LocalMachine.OpenSubKey(SPSPath);
                if (key != null)
                {
                    var version = key.GetValue("BuildVersion") as String;
                    if (version != null)
                    {
                        var buildVersion = new Version(version);
                        if (buildVersion.Major == 15)
                        {
                            return ValidationResult.Success;
                        }
                    }
                }
            }
            catch (SecurityException ex)
            {
                throw new ValidatorExcpetion(String.Format("Registry access denied: {0}", SPSPath), ex);
            }
            return ValidationResult.Error;
        }
    }
}
