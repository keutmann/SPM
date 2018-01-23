// From: http://sharepointinstaller.codeplex.com/

using System;
using System.Windows.Forms;
using System.ComponentModel.Composition;
using System.Collections.Generic;

namespace SPM2.Framework.Validation
{
    public delegate void ValidateEventHandler(BaseValidator validator);

    public delegate void Operation();

    public class ValidationService : IDisposable
    {
        private readonly Timer timer = new Timer();

        private readonly ValidatorCollection validators = new ValidatorCollection(String.Empty);


        
        public event ValidateEventHandler ValidatorSucceed;
        public event ValidateEventHandler ValidatorFailed;
        public event ValidateEventHandler ValidatorSkippped;

        public event Operation ValidationFinished;

        private int index;

        public ValidationService()
        {
            timer.Interval = 100;
            timer.Tick += OnTimerTick;
            index = 0;
            Errors = 0;
        }

        public void Add(BaseValidator validator)
        {
            validators.AddValidator(validator);
        }

        public void Run()
        {
            timer.Start();
        }

        private void OnValidatorSucceed(BaseValidator validator)
        {
            var handler = ValidatorSucceed;
            if(handler != null)
            {
                handler(validator);
            }
        }

        private void OnValidatorFailed(BaseValidator validator)
        {
            Errors++;
            var handler = ValidatorFailed;
            if (handler != null)
            {
                handler(validator);
            }
        }

        private void OnValidatorSkipped(BaseValidator validator)
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

        private void OnTimerTick(object sender, EventArgs e)
        {
            timer.Stop();

            if (index < validators.Count)
            {
                ValidationResult result;
                try
                {
                    result = validators[index].RunValidator();
                }
                catch(ValidatorExcpetion ex)
                {
                    result = ValidationResult.Error;
                    validators[index].ErrorString = ex.Message;
                }
                if (result == ValidationResult.Success)
                {
                    OnValidatorSucceed(validators[index]);                    
                }
                else if(result == ValidationResult.Error)
                {
                    OnValidatorFailed(validators[index]);
                }
                else if (result == ValidationResult.Inconclusive)
                {
                    OnValidatorSkipped(validators[index]);
                }
                index++;
                timer.Start();
                return;
            }

            OnValidationFinished();
        }

        public void Dispose()
        {
            if(timer != null)
                timer.Dispose();
        }

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
    }
}
