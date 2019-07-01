using Core.Validators;
using Library.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business.Validators
{
    public class BorrowValidator : BusinessValidator<BorrowedBook>
    {
        //Here we override the inherited method DoValidate from the  BusinessValidator and we execute all the validation methods.
        public override void DoValidate()
        {
            this.ValidateBorrowing(base.BusinessEntity);
        }

        private void ValidateBorrowing(BorrowedBook borrowedBook)
        {
            //base.LogValidationResult("Error message");

            //Business rules Validation
        }
    }
}
