namespace Hotel_Reserve.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("State")]
    public partial class State
    {
        public int Id { get; set; }

        [Column("State")]
        [Required]
        [StringLength(50)]
        public string State1 { get; set; }

        [Required]
        [StringLength(50)]
        public string CountryName { get; set; }

        public virtual Country Country { get; set; }
    }
}
