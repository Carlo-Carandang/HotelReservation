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
    public class PostalValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,
                            ValidationContext validationContext)
        {
            Customer cust = (Customer)validationContext.ObjectInstance;
            string country = cust.Country;
            if (country != null)
            {
                string pattern;
                bool res = false;
                country = country.ToString();
                string val = value.ToString();
                if (country == "USA")
                {
                    pattern = "^[0-9]{5}(?:-[0-9]{4})?$";
                    Regex regex = new Regex(pattern);
                    res = regex.IsMatch(val);
                }
                else if (country == "Canada")
                {
                    pattern = "^[A-Za-z]\\d[A-Za-z][ -]?\\d[A-Za-z]\\d$";
                    Regex regex = new Regex(pattern);
                    res = regex.IsMatch(val);
                }

                if (res == false)
                {
                    return new ValidationResult("Invalid postal/zip number");
                }
            }
            return ValidationResult.Success;
        }
    }
}