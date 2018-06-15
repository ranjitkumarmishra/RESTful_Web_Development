using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ReservationSystem
{
    public class CreditCardValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,
                           ValidationContext validationContext)
        {

            var model = (creditinfo)validationContext.ObjectInstance;
            String strCardType = model.cardType;
            String strCardNumber = model.cardNumber;
            if (String.IsNullOrEmpty(strCardType) ||
                String.IsNullOrEmpty(strCardNumber))
            {
                return new ValidationResult("Invalid Card Number"); ;
            }
            if (!IsValidCreditCard(strCardType, strCardNumber))
            {
                return new ValidationResult("Invalid Card Number");
            }
            return ValidationResult.Success;
        }

        private bool IsValidCreditCard(string str, string number)
        {
            bool IsValidCreditCard = false;
            string pattern = "";            
            if (str.Equals("VISA"))
            {
                pattern = "^4[0-9]{12}(?:[0-9]{3})?$";
            }
            else if (str.Equals("Master"))
            {
                pattern = "^5[1-5][0-9]{14}$";
            }
            else if (str.Equals("American Express"))
            {
                pattern = "^3[47][0-9]{13}$";
            }

            if (pattern != null)
            {
                Regex regex = new Regex(pattern);
                return IsValidCreditCard = regex.IsMatch(number);
            }
            return IsValidCreditCard;
        }

    }
}