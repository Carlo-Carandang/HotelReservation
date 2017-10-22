namespace HotelReservation.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CustomerModel : DbContext
    {
        public CustomerModel()
            : base("name=CustomerModel")
        {
        }

        public virtual DbSet<CustomerInformation> CustomerInformations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerInformation>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<CustomerInformation>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<CustomerInformation>()
                .Property(e => e.StreetName)
                .IsUnicode(false);

            modelBuilder.Entity<CustomerInformation>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<CustomerInformation>()
                .Property(e => e.ProvState)
                .IsUnicode(false);

            modelBuilder.Entity<CustomerInformation>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<CustomerInformation>()
                .Property(e => e.PostalCode)
                .IsUnicode(false);

            modelBuilder.Entity<CustomerInformation>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<CustomerInformation>()
                .Property(e => e.CreditCardType)
                .IsUnicode(false);

            modelBuilder.Entity<CustomerInformation>()
                .Property(e => e.CreditCardName)
                .IsUnicode(false);
        }
    }
}
