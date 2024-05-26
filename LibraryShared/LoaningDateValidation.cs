using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Shared
{
    public class LoaningDateValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var loaning = (Loaning)validationContext.ObjectInstance;

            if (loaning.LoaningDate.Date < DateTime.Today)
            {
                return new ValidationResult("The loaning date cannot be earlier than today.");
            }

            if (loaning.ReturnDate <= loaning.LoaningDate)
            {
                return new ValidationResult("The return date must be later than the loaning date.");
            }

            return ValidationResult.Success;
        }
    }
}