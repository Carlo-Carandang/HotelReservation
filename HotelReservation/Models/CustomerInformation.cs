namespace HotelReservation.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CustomerInformation")]
    public partial class CustomerInformation
    {
        public int Id { get; set; }

        [Required]
        [StringLength(60)]
        public string LastName { get; set; }

        [Required]
        [StringLength(60)]
        public string FirstName { get; set; }

        public int? StreetNumber { get; set; }

        [StringLength(60)]
        public string StreetName { get; set; }

        [StringLength(60)]
        public string City { get; set; }

        [StringLength(60)]
        public string ProvState { get; set; }

        [StringLength(60)]
        public string Country { get; set; }

        [StringLength(60)]
        public string PostalCode { get; set; }

        [Required]
        [StringLength(60)]
        public String PhoneNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Column(TypeName = "date")]
        public DateTime CheckInDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime CheckOutDate { get; set; }

        public int Room { get; set; }

        public int Guest { get; set; }

        [Required]
        [StringLength(50)]
        public string CreditCardType { get; set; }

        [Required]
        [StringLength(50)]
        public string CreditCardName { get; set; }

        [Required]
        [StringLength(50)]
        public string CreditCardNumber { get; set; }

        public int CreditCardExpiryDate { get; set; }
    }
}
