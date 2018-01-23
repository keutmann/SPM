// From: http://sharepointinstaller.codeplex.com/

using System;
using System.Collections.Generic;

namespace SPM2.Framework.Validation
{
    public class ValidatorCollection : BaseValidator
    {
        private readonly IList<BaseValidator> validators = new List<BaseValidator>();

        public ValidatorCollection(String id) : base(id)
        {
        }

        public BaseValidator this[Type type]
        {
            get
            {
                return ((List<BaseValidator>)validators).Find(validator => validator.GetType().Equals(type));
            }
        }

        public BaseValidator this[String id]
        {
            get
            {
                return ((List<BaseValidator>) validators).Find(validator => validator.Id == id);
            }
        }

        public BaseValidator this[int index]
        {
            get
            {
                return validators[index];
            }
        }

        public void AddValidator(BaseValidator validator)
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
