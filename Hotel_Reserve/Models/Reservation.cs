namespace Hotel_Reserve.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel;
    using System.Data.Entity.Spatial;

    [Table("Reservation")]
    public partial class Reservation
    {
        public int Id { get; set; }

        [DisplayName("Check In Date")]
        [Column(TypeName = "date")]
        public DateTime CheckInDate { get; set; }

        [DisplayName("Check Out date")]
        [Column(TypeName = "date")]
        public DateTime CheckOutDate { get; set; }

        [DisplayName("Number of Rooms")]
        public int NumberOfRoom { get; set; }

        [DisplayName("Number Of Guests")]
        public int NumberOfGuest { get; set; }

        public int Cid { get; set; }
    }
}
 