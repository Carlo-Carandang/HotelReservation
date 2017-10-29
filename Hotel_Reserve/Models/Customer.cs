using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Reserve.Models
{
    [Table("Customer")]
    public partial class Customer
    {
        public int id { get; set; }

        [Required]
        [DisplayName("Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [DisplayName("First Name")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Street Number")]
        [StringLength(10)]
        public string StreetNumber { get; set; }

        [Required]
        [DisplayName("Street Name")]
        [StringLength(50)]
        public string StreetName { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Required]
        [StringLength(50)]
        public string Province { get; set; }

        [Required]
        [StringLength(50)]
        public string Country { get; set; }

        [Required]
        [DisplayName("Postal Code")]
        [StringLength(10)]
        public string PostalCode { get; set; }

        [Required]
        [DisplayName("Phone Number")]
        [StringLength(10)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DisplayName("Credit Card Type")]
        [StringLength(50)]
        public string CreditCardType { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Credit Card Number")]
        public string CreditCardNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string CreditCardName { get; set; }

        [Required]
        [StringLength(50)]
        public string ExpirationDate { get; set; }


        public List<Reservation> Reservations { get; set; }

    }
}