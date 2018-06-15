using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ReservationSystem
{
    public class CheckInDateValidate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value == null)
            {
                return new ValidationResult("Invalid Check-In date");
            }
            DateTime date = DateTime.Parse(value.ToString()); // assuming it's in a parsable string format

            if (date >= DateTime.Now.Date)
            {               
               return ValidationResult.Success;                              
            }
            return new ValidationResult("Invalid Check-In date");
        }

    }
}