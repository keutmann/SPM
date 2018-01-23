using System;
using System.Runtime.Serialization;

namespace SPM2.Framework.Validation
{
    public class ValidatorExcpetion : Exception
    {
        public ValidatorExcpetion() { }

        public ValidatorExcpetion(string message) : base(message) { }

        public ValidatorExcpetion(SerializationInfo info, StreamingContext context)
            : base(info, context) { }

        public ValidatorExcpetion(string message, Exception innerException)
            : base(message, innerException) { }
    }

}
