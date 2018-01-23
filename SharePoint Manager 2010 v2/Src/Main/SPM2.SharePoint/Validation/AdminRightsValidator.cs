// From: http://sharepointinstaller.codeplex.com/

using System;
using Microsoft.SharePoint.Administration;
using SPM2.Framework.Validation;

namespace SPM2.SharePoint.Validation
{
    public class AdminRightsValidator : BaseValidator, IValidator
    {
        public AdminRightsValidator(String id) : base(id)
        {
            this.QuestionString = "Please ensure to run the application with Administrator rights";
            this.SuccessString = "The current user is administrator";
            this.ErrorString = "The current user is not administrator";
        }

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
                return new SPFInstalledValidator(String.Empty).RunValidator() == ValidationResult.Success;
            }
        }
    }
}
