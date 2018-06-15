namespace ReservationSystem
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<contact> contacts { get; set; }
        public virtual DbSet<creditinfo> creditinfoes { get; set; }
        public virtual DbSet<reservation> reservations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<contact>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<contact>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<contact>()
                .Property(e => e.StreetNumber)
                .IsUnicode(false);

            modelBuilder.Entity<contact>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<contact>()
                .Property(e => e.Province)
                .IsUnicode(false);

            modelBuilder.Entity<contact>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<contact>()
                .Property(e => e.PostalCode)
                .IsUnicode(false);

            modelBuilder.Entity<contact>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<contact>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<contact>()
                .HasMany(e => e.creditinfoes)
                .WithRequired(e => e.contact)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<creditinfo>()
                .Property(e => e.cardType)
                .IsUnicode(false);

            modelBuilder.Entity<creditinfo>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<creditinfo>()
                .Property(e => e.cardNumber)
                .IsUnicode(false);

            modelBuilder.Entity<reservation>()
                .HasMany(e => e.contacts)
                .WithRequired(e => e.reservation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<reservation>()
                .HasMany(e => e.creditinfoes)
                .WithRequired(e => e.reservation)
                .WillCascadeOnDelete(false);
        }
    }
}
