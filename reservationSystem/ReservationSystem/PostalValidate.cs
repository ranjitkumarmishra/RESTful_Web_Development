using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ReservationSystem
{
    class PostalValidate : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value,
                            ValidationContext validationContext)
        {
            if(value == null)
            {
                return new ValidationResult("Invalid postal code");
            }
            string str = value.ToString();
            var model = (contact)validationContext.ObjectInstance;
            if (!IsUSorCanadianZipCode(str,model.Country.ToString()))
            {
                return new ValidationResult("Invalid postal code");
            }

            return ValidationResult.Success;
        }

        private bool IsUSorCanadianZipCode(string zipCode, string strCountry)
        {
            bool isValidUsOrCanadianZip = false;
            string pattern = null;
            if (strCountry.Equals("Canada"))
            {
                pattern = @"^[ABCEGHJKLMNPRSTVXY]{1}\d{1}[A-Z]{1} *\d{1}[A-Z]{1}\d{1}$";
            } else // If not canada then country is US
            {
                pattern = @"^\d{5}(-\d{4})?$";
            }            
            Regex regex = new Regex(pattern);
            return isValidUsOrCanadianZip = regex.IsMatch(zipCode);
        }

    } 


}
