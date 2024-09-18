using Microsoft.EntityFrameworkCore;
using StartMyNewApp.Domain.Models;  // Models are referenced from Domain

namespace DATA.Context  // Ensure this matches your project structure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<HotelArticle> HotelArticles { get; set; } // HotelArticles table
        public DbSet<Comment> Comments { get; set; } // Comments table
        public DbSet<User> Users { get; set; } // Users table
        public DbSet<Location> Locations { get; set; } // Locations table
        public DbSet<Booking> Bookings { get; set; } // Bookings table

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define primary key for Comment entity
            modelBuilder.Entity<Comment>()
                .HasKey(c => c.IdComment);  // Define IdComment as primary key

            // Define primary key for User entity
            modelBuilder.Entity<User>()
                .HasKey(u => u.IdUser);  // Define IdUser as primary key

            // Define primary key for Location entity
            modelBuilder.Entity<Location>()
                .HasKey(l => l.IdLocation);  // Define IdLocation as primary key

            // Define primary key for HotelArticle entity
            modelBuilder.Entity<HotelArticle>()
                .HasKey(h => h.HotelID);  // Define HotelID as primary key

            // Define primary key for Booking entity
            modelBuilder.Entity<Booking>()
                .HasKey(b => b.IdBooking);  // Define IdBooking as primary key

            // Define relationships for Comments
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.HotelArticle)  // Relationship with HotelArticles
                .WithMany() // Adjust if you have a navigation property in HotelArticle for comments
                .HasForeignKey(c => c.HotelID)
                .OnDelete(DeleteBehavior.Cascade);

            // Define relationships for Bookings
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.User)  // Relationship with Users
                .WithMany() // Adjust if you have a navigation property in User for bookings
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.HotelArticle)  // Relationship with HotelArticles
                .WithMany() // Adjust if you have a navigation property in HotelArticle for bookings
                .HasForeignKey(b => b.HotelID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
