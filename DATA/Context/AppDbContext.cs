using Microsoft.EntityFrameworkCore;
using StartMyNewApp.Domain.Models;  // Models are referenced from Domain

namespace DATA.Context  // Ensure this matches your project structure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define primary key for Loan entity
            modelBuilder.Entity<Loan>()
                .HasKey(l => l.IdEmprunt);  // Define IdEmprunt as primary key

            // Define primary key for Person entity
            modelBuilder.Entity<Person>()
                .HasKey(p => p.IdPersonne);  // Define IdPersonne as primary key

            // Define primary key for Reservation entity
            modelBuilder.Entity<Reservation>()
                .HasKey(r => r.IdReservation);  // Define IdReservation as primary key

            // Define relationships and foreign keys
            modelBuilder.Entity<Loan>()
                .HasOne<Book>()
                .WithMany()
                .HasForeignKey(l => l.FKLivre)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Loan>()
                .HasOne<Person>()
                .WithMany()
                .HasForeignKey(l => l.FKAdherent)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Reservation>()
                .HasOne<Book>()
                .WithMany()
                .HasForeignKey(r => r.FKLivre)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Reservation>()
                .HasOne<Person>()
                .WithMany()
                .HasForeignKey(r => r.FKPersonne)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
