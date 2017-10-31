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
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,50}$", ErrorMessage = "special characters and numbers are not allowed")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please Enter First Name")]
        [Display(Name = "First Name")]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,50}$", ErrorMessage = "special characters and numbers are not allowed")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please Enter Street Number")]
        [Display(Name = "Street Number")]
        [StringLength(10)]
        public string StreetNumber { get; set; }

        [Required(ErrorMessage = "Please Enter Street Name")]
        [Display(Name = "Street Name")]
        [StringLength(50)]
        public string StreetName { get; set; }

        [Required(ErrorMessage = "Please Enter City")]
        [Display(Name = "City")]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,50}$", ErrorMessage = "special characters and numbers are not allowed")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please Enter Province")]
        [Display(Name = "Province")]
        [StringLength(50)]
        public string Province { get; set; }

        [Required(ErrorMessage = "Please Enter Country")]
        [Display(Name="Country")]
        [StringLength(50)]
        public string Country { get; set; }

        [Required(ErrorMessage = "Please Enter Postal Code")]
        [Display(Name = "Postal Code")]
        [StringLength(10)]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Please Enter Phone Number")]
        [Display(Name = "Phone Number")]
        [StringLength(10, ErrorMessage = "The phone must contain 10 characters", MinimumLength = 10)]
        public string PhoneNumber { get; set; }

        [StringLength(50)]
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
        [StringLength(50)]
        public string CreditCardType { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Credit Card Number")]
        public string CreditCardNumber { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Credit Card Name")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,50}$", ErrorMessage = "special characters and numbers are not allowed")]
        public string CreditCardName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Credit Card Expiration Date")]
        public string ExpirationDate { get; set; }


        public List<Reservation> Reservations { get; set; }

    }
}