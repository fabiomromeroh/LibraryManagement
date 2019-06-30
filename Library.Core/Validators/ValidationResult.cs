using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Validators
{
    public class ValidationResult
    {
        public ValidationResult()
        {
            this.ValidationResultsLog = new List<ValidatorResult>();
        }
        public Boolean IsValid { get; set; }
        public List<ValidatorResult> ValidationResultsLog { get; set; }
    }
}
