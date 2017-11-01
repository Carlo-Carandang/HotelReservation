using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Hotel_Reserve.Models;

namespace Hotel_Reserve
{
    public class CreditValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,
                            ValidationContext validationContext)
        {
            Customer cust = (Customer)validationContext.ObjectInstance;
            string type = cust.CreditCardType;
            if(type!=null)
            {
                string pattern;
                bool res = false;
                type = cust.CreditCardType.ToString();
                string val = value.ToString();
                if (type == "Master Card")
                {
                    pattern = "^5[1-5]\\d{14}$";
                    Regex regex = new Regex(pattern);
                    res = regex.IsMatch(val);
                }
                else if (type == "Visa")
                {
                    pattern = "^4\\d{15}$";
                    Regex regex = new Regex(pattern);
                    res = regex.IsMatch(val);
                }
                else if (type == "American Express")
                {
                    pattern = "^3[47]\\d{13}$";
                    Regex regex = new Regex(pattern);
                    res = regex.IsMatch(val);
                }

                if (res == false)
                {
                    return new ValidationResult("Invalid credit card number");
                }
            }
            return ValidationResult.Success;
        }
    }
}