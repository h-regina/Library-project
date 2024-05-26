using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryShared
{
    public class RangeDateTime : ValidationAttribute
    {
        private readonly DateTime _datemin;
        public RangeDateTime()
        {
            _datemin = DateTime.Parse("1900-01-01");
        }

        protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime date)
            {
                if (date < _datemin || date > DateTime.Today)
                {
                    return new ValidationResult($"The date must be between {_datemin.ToShortDateString()} and today.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
