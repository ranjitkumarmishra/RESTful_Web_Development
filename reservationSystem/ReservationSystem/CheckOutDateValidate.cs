using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ReservationSystem
{
    public class CheckOutDateValidate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Invalid Check-Out date");
            }
            DateTime date = DateTime.Parse(value.ToString()); // assuming it's in a parsable string format

            var model = (reservation)validationContext.ObjectInstance;
            if ((null != model.checkInDate) &&
              (date >= DateTime.Parse(model.checkInDate.ToString()))) {
                return ValidationResult.Success;
            }
            return new ValidationResult("Invalid Check-Out date");
        }
    }
}