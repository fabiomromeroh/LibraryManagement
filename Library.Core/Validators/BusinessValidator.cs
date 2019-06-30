using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Validators
{
    public abstract class BusinessValidator<T> : IValidator
    {
        public BusinessValidator()
        {
            this.validationResult = new ValidationResult { IsValid = true };
        }

        private ValidationResult validationResult { get; set; }
        protected T BusinessEntity { get; private set; }

        public ValidationResult Validate(T businessEntity)
        {
            this.BusinessEntity = businessEntity;
            try
            {
                this.DoValidate();
            }
            catch (ValidationException)
            { }
            return validationResult;
        }

        public virtual void DoValidate()
        {
            throw new NotImplementedException();
        }

        protected void LogValidationResult(String message)
        {
            this.validationResult.IsValid = false;
            this.validationResult.ValidationResultsLog.Add(new ValidatorResult() { Code = 0, Message = message });
        }

        protected void LogValidationResult(String message, Int16 code)
        {
            this.validationResult.IsValid = false;
            this.validationResult.ValidationResultsLog.Add(new ValidatorResult() { Code = code, Message = message });
        }

        protected void LogValidationResultAndStopExecution(String message)
        {
            this.LogValidationResult(message);
            throw new ValidationException();
        }
    }
}
