// From: http://sharepointinstaller.codeplex.com/

using System;
using System.Collections;
using System.Collections.Generic;

namespace SPM2.Framework.Validation
{
    public class ValidatorCollection : BaseValidator
    {
        public readonly IList<IValidator> validators = new List<IValidator>();

        public ValidatorCollection() 
        {
        }

        public IValidator this[Type type]
        {
            get
            {
                return ((List<IValidator>)validators).Find(validator => validator.GetType().Equals(type));
            }
        }

        public IValidator this[String id]
        {
            get
            {
                return ((List<IValidator>) validators).Find(validator => validator.Id == id);
            }
        }

        public IValidator this[int index]
        {
            get
            {
                return validators[index];
            }
        }

        public void AddValidator(IValidator validator)
        {
            if(validator != null)
                validators.Add(validator);
        }

        protected override ValidationResult Validate()
        {
            foreach(var validator in validators)
            {
                if (validator.RunValidator() == ValidationResult.Success)
                    continue;
                return ValidationResult.Error;
            }
            return ValidationResult.Success;
        }

        public int Count
        {
            get
            {
                return validators.Count;
            }
        }

    }
}
