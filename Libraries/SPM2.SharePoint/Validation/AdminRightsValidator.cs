// From: http://sharepointinstaller.codeplex.com/

using System;
using Microsoft.SharePoint.Administration;
using SPM2.Framework.Validation;
using SPM2.Framework.IoC;

namespace SPM2.SharePoint.Validation
{
    //[Export(typeof(BaseValidator))]
    //[ExportMetadata("Order", 100)]

    [IoCOrder(100)]
    public class AdminRightsValidator : BaseValidator
    {

        public AdminRightsValidator()
            : base()
        {
            this.QuestionString = "Please ensure to run the application with Administrator rights";
            this.SuccessString = "The current user is administrator";
            this.ErrorString = "The current user is not administrator";
        }

        //public AdminRightsValidator(String id) : base(id)
        //{
        //}

        protected override ValidationResult Validate()
        {
            try
            {
                if (SPFarm.Local.CurrentUserIsAdministrator())
                {
                    return ValidationResult.Success;
                }
                return ValidationResult.Error;
            }

            catch (NullReferenceException)
            {
                throw new ValidatorExcpetion("SharePoint was unable to connect to the database.");
            }

            catch (Exception ex)
            {
                throw new ValidatorExcpetion(ex.Message, ex);
            }
        }

        protected override bool CanRun
        {
            get
            {
                //return new SPFInstalledValidator(String.Empty).RunValidator() == ValidationResult.Success;
                return true;
            }
        }
    }
}
