// From: http://sharepointinstaller.codeplex.com/

using System;
using System.ComponentModel;
using System.ServiceProcess;
using System.Diagnostics;
using Microsoft.SharePoint.Administration;
using SPM2.Framework;
using SPM2.Framework.Validation;

namespace SPM2.SharePoint.Validation
{
    public class TimerServiceValidator : BaseValidator, IValidator
    {
        public TimerServiceValidator(String id) : base(id)
        {
        }

        protected override ValidationResult Validate()
        {
            try
            {
                if (SPFarm.Local == null)
                {
                    this.ErrorString = "Insufficient rights to access configuration database.";
                    return ValidationResult.Error;
                }

                foreach (var server in SPFarm.Local.Servers)
                {
                    foreach (var service in server.ServiceInstances)
                    {
                        if (service.TypeName == "Microsoft SharePoint Foundation Timer")
                        {
                            try
                            {
                                var serviceController = new ServiceController("SPTimerV4", server.Name);
                                if (serviceController.Status != ServiceControllerStatus.Running)
                                {
                                    this.ErrorString = String.Format("Microsoft SharePoint Foundation Timer is not running on {0}", server.Name);
                                    Trace.WriteLine(this.ErrorString);
                                    return ValidationResult.Error;
                                }

                            }
                            catch (UnauthorizedAccessException ex)
                            {
                                Trace.Fail(ex.Message, ex.StackTrace);
                                this.ErrorString = String.Format("Failed to access Microsoft SharePoint Foundation Timer on {0}.", server.Name);
                                return ValidationResult.Inconclusive;
                            }
                        }
                    }
                }

                return ValidationResult.Success;
                
            }
            catch (System.ServiceProcess.TimeoutException ex)
            {
                Trace.TraceError(ex.GetMessages());
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
                return new SPFInstalledValidator(String.Empty).RunValidator() == ValidationResult.Success;
            }
        }
    }
}
