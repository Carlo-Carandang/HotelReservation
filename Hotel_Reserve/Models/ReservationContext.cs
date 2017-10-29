namespace Hotel_Reserve.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ReservationContext : DbContext
    {
        public ReservationContext()
            : base("name=ReservationContext")
        {
        }

        public virtual DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
