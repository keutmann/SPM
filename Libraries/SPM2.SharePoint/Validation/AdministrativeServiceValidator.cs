// From: http://sharepointinstaller.codeplex.com/

using System;
using System.ComponentModel;
using System.ServiceProcess;
using System.Diagnostics;
using Microsoft.SharePoint.Administration;
using SPM2.Framework;
using SPM2.Framework.Validation;
using SPM2.Framework.IoC;

namespace SPM2.SharePoint.Validation
{
    // Is not necessary for SPM to run
    //[Export(typeof(BaseValidator))]
    [IoCIgnore()]
    public class AdministrativeServiceValidator : BaseValidator, IValidator
    {
        public AdministrativeServiceValidator()
            : base()
        {
            this.QuestionString = "Please ensure to run the application with Administrator rights";
            this.SuccessString = "The current user is administrator";
            this.ErrorString = "The current user is not administrator";
        }

        //public AdministrativeServiceValidator(String id) : base(id)
        //{
        //}

        protected override ValidationResult Validate()
        {
            try
            {
                if (SPFarm.Local == null)
                {
                    this.ErrorString = "Insufficient rights to access configuration database.";
                    return ValidationResult.Error;
                }
                
                foreach(var server in SPFarm.Local.Servers)
                {
                    foreach(var service in server.ServiceInstances)
                    {
                        if (service.TypeName == "Microsoft SharePoint Foundation Administration")
                        {
                            try
                            {
                                var serviceController = new ServiceController("SPAdminV4", server.Name);
                                if (serviceController.Status != ServiceControllerStatus.Running)
                                {
                                    Trace.WriteLine(
                                        String.Format(
                                            "Microsoft SharePoint Foundation Administration is not running on {0}",
                                            server.Name));
                                    return ValidationResult.Error;
                                }
                            }
                            catch (UnauthorizedAccessException ex)
                            {
                                Trace.Fail(ex.Message, ex.StackTrace);
                                QuestionString = String.Format("Failed to access Microsoft SharePoint Foundation Administration on {0}.", server.Name);
                                return ValidationResult.Inconclusive;
                            }
                        }   
                    }
                }
                
                return ValidationResult.Success;
            }            
            catch (Win32Exception ex)
            {
                Trace.TraceError(ex.GetMessages());
            }
            catch (InvalidOperationException ex)
            {
                Trace.TraceError(ex.GetMessages());
            }

            return ValidationResult.Inconclusive;
        }

        protected override bool CanRun
        {
            get
            {
                return new SPFInstalledValidator().RunValidator() == ValidationResult.Success;
            }
        }
    }
}
