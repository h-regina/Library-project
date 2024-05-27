using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Shared
{
    public class LoaningDateValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime date)
            {
                if (date < DateTime.Today)
                {
                    return new ValidationResult("The loaning date must be today or a future date.");
                }
            }
            return ValidationResult.Success;
        }
    }

    public class ReturnDateValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var currentValue = value as DateTime?;
            var instance = validationContext.ObjectInstance;
            var loaningDateProperty = validationContext.ObjectType.GetProperty("LoaningDate");

            if (loaningDateProperty == null)
            {
                return new ValidationResult($"Unknown property: LoaningDate");
            }

            var loaningDateValue = loaningDateProperty.GetValue(instance) as DateTime?;

            if (currentValue.HasValue && loaningDateValue.HasValue)
            {
                if (currentValue.Value <= loaningDateValue.Value)
                {
                    return new ValidationResult("The return date must be later than the loaning date.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
