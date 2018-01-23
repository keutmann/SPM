using System;
namespace SPM2.Framework.Validation
{
    public interface IValidator
    {
        string ErrorString { get; set; }
        string Id { get; }
        string QuestionString { get; set; }
        ValidationResult Result { get; set; }
        ValidationResult RunValidator();
        string SuccessString { get; set; }
    }
}
