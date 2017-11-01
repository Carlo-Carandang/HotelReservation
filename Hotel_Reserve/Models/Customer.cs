 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace Hotel_Reserve.Models
{
    [Table("Customer")]
    public partial class Customer
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Please Enter Last Name")]
        [Display(Name = "Last Name")]
        [RegularExpression(@"^[^;:!@#$%^*+?/\\\\<>0-9]{1,50}$", ErrorMessage = "special characters and numbers are not allowed")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please Enter First Name")]
        [Display(Name = "First Name")]
        [RegularExpression(@"^[^;:!@#$%^*+?/\\\\<>0-9]{1,50}$", ErrorMessage = "special characters and numbers are not allowed")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please Enter Street Number")]
        [Display(Name = "Street Number")]
        [StringLength(5)]
        public string StreetNumber { get; set; }

        [Required(ErrorMessage = "Please Enter Street Name")]
        [Display(Name = "Street Name")]
        public string StreetName { get; set; }

        [Required(ErrorMessage = "Please Enter City")]
        [Display(Name = "City")]
        [RegularExpression(@"^[^;:!@#$%^*+?/\\\\<>0-9]{1,50}$", ErrorMessage = "special characters and numbers are not allowed")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please Enter Province")]
        [Display(Name = "Province")]
        public string Province { get; set; }

        [Required(ErrorMessage = "Please Enter Country")]
        [Display(Name="Country")]
        public string Country { get; set; }

        
        [RegularExpression("^([A-Za-z]\\d[A-Za-z][ -]?\\d[A-Za-z]\\d)|(^[0-9]{5}(?:-[0-9]{4})?)$",ErrorMessage = "Invalid Postal/Zip Code")]
        [Display(Name = "Postal Code")]
        [StringLength(10)]
        [PostalValidation]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Please Enter Phone Number")]
        [Display(Name = "Phone Number")]
        [StringLength(10, ErrorMessage = "The phone must contain 10 characters", MinimumLength = 10)]
        [RegularExpression(@"^([0-9\(\)\/\+ \-]*)$", ErrorMessage = "Invalid Phone number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [Display(Name = "Password")]
        [StringLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Credit Card Type")]
        public string CreditCardType { get; set; }

        [Required]
        [MaxLength(16)]
        [MinLength(15)]
        [RegularExpression("^(5[1-5]\\d{14})|(4\\d{15})|(3[47]\\d{13})$",ErrorMessage ="Invalid Credit Card Number")]
        [Display(Name = "Credit Card Number")]
        [CreditValidation]
        public string CreditCardNumber { get; set; }

        [Required]
        [Display(Name = "Credit Card Name")]
        [RegularExpression(@"^[^;:!@#$%^*+?/\\\\<>0-9]{1,50}$", ErrorMessage = "special characters and numbers are not allowed")]
        public string CreditCardName { get; set; }

        [Required]
        [Display(Name = "Credit Card Expiration Date")]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/(20(1[6-9]|2[0-9]|3[0-1]))$", ErrorMessage = "Only MM/YYYY format from 2016 to 2031")]
        public string ExpirationDate { get; set; }


        public List<Reservation> Reservations { get; set; }

    }
}