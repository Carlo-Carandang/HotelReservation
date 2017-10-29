namespace Hotel_Reserve.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CountryState : DbContext
    {
        public CountryState()
            : base("name=CountryState")
        {
        }

        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<State> States { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
                .Property(e => e.CountryName)
                .IsUnicode(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.States)
                .WithRequired(e => e.Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<State>()
                .Property(e => e.State1)
                .IsUnicode(false);

            modelBuilder.Entity<State>()
                .Property(e => e.CountryName)
                .IsUnicode(false);
        }
    }
}
