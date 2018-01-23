// From: http://sharepointinstaller.codeplex.com/

using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace SPM2.Framework.Validation
{
    public delegate void ValidateEventHandler(IValidator validator);

    public delegate void Operation();

    public class ValidationService : IDisposable
    {
        private readonly ValidatorCollection validators = new ValidatorCollection();
        
        public event ValidateEventHandler ValidatorSucceed;
        public event ValidateEventHandler ValidatorFailed;
        public event ValidateEventHandler ValidatorSkippped;

        public event Operation ValidationFinished;

        public ValidatorCollection Validators
        {
            get
            {
                return validators;
            }
        }

        public int Errors
        {
            get;
            private set;
        }

        public ValidationService()
        {
            Errors = 0;
        }

        public void Add(IValidator validator)
        {
            validators.AddValidator(validator);
        }

        public void AddRange(IEnumerable<IValidator> collection)
        {
            foreach (var item in collection)
            {
                validators.AddValidator(item);
            }
        }



        public void Run()
        {
            //timer.Start();
            ValidationResult result;
            for (var i = 0; i < validators.Count; i++ )
            {
                var validator = validators[i];
                try
                {
                    result = validator.RunValidator();
                }
                catch (ValidatorExcpetion ex)
                {
                    result = ValidationResult.Error;
                    validator.ErrorString = ex.Message;
                }
                if (result == ValidationResult.Success)
                {
                    OnValidatorSucceed(validator);
                }
                else if (result == ValidationResult.Error)
                {
                    OnValidatorFailed(validator);
                    break;
                }
                else if (result == ValidationResult.Inconclusive)
                {
                    OnValidatorSkipped(validator);
                }
            }

            OnValidationFinished();
        }

        private void OnValidatorSucceed(IValidator validator)
        {
            var handler = ValidatorSucceed;
            if(handler != null)
            {
                handler(validator);
            }
        }

        private void OnValidatorFailed(IValidator validator)
        {
            Errors++;
            var handler = ValidatorFailed;
            if (handler != null)
            {
                handler(validator);
            }
        }

        private void OnValidatorSkipped(IValidator validator)
        {
            var handler = ValidatorSkippped;
            if (handler != null)
            {
                handler(validator);
            }
        }

        private void OnValidationFinished()
        {
            var handler = ValidationFinished;
            if (handler != null)
            {
                handler();
            }
        }

        public void Dispose()
        {
        }

    }
}
