// From: http://sharepointinstaller.codeplex.com/

using System;

namespace SPM2.Framework.Validation
{
    public abstract class BaseValidator : IValidator
    {
        //private InstallConfiguration configuration;

        public String Id
        {
            get; 
            private set;
        }

        public ValidationResult Result { get; set; }

        protected BaseValidator()
        {
            Id = this.GetType().Name;
        }

        public ValidationResult RunValidator()
        {
            Result = ValidationResult.Inconclusive;
            if(CanRun)
            {
                Result = Validate();
            }
            return Result;
        }

        protected abstract ValidationResult Validate();

        protected virtual bool CanRun
        {
            get
            {
                return true;
            }
        }

        public String QuestionString
        {
            get; 
            set;
        }

        public String SuccessString
        {
            get; 
            set;
        }

        public String ErrorString
        {
            get; 
            set;
        }

        //public InstallConfiguration Configuration
        //{
        //    get
        //    {
        //        if (configuration == null)
        //            configuration = InstallConfiguration.GetConfiguration();
        //        return configuration;
        //    }
        //}
    }
}
