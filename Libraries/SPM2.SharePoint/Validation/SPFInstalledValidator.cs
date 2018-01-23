// From: http://sharepointinstaller.codeplex.com/

using System;
using System.Security;
using Microsoft.Win32;
using SPM2.Framework.Validation;
using System.Reflection;
using System.Diagnostics;
using SPM2.Framework.IoC;

namespace SPM2.SharePoint.Validation
{
    //[Export(typeof(BaseValidator))]
    //[ExportMetadata("Order", 50)]

    [IoCIgnore()]
    public class SPFInstalledValidator : BaseValidator, IValidator
    {
        public SPFInstalledValidator()
            : base()
        {
            this.QuestionString = "The application needs to run on a server with Microsoft SharePoint installed.";
            this.SuccessString = "Microsoft SharePoint found.";
            this.ErrorString = "Microsoft SharePoint is missing.";
        }

        //public SPFInstalledValidator(String id) : base(id)
        //{
        //}

        protected override ValidationResult Validate()
        {        
            try
            {
                if(SPMEnvironment.Version.Office > 12)
                    return ValidationResult.Success;
            }
            catch (SecurityException ex)
            {
                Trace.TraceError(ex.Message);
            }
            return ValidationResult.Error;
        }
    }
}
