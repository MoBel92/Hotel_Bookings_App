using Microsoft.EntityFrameworkCore;
using StartMyNewApp.Domain.Models;

namespace DATA.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<HotelArticle> HotelArticles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Notification> Notifications { get; set; } // Added DbSet for Notification

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure primary keys
            modelBuilder.Entity<HotelArticle>().HasKey(h => h.HotelID);
            modelBuilder.Entity<Comment>().HasKey(c => c.IdComment);
            modelBuilder.Entity<User>().HasKey(u => u.IdUser);
            modelBuilder.Entity<Location>().HasKey(l => l.IdLocation);
            modelBuilder.Entity<Booking>().HasKey(b => b.IdBooking);
            modelBuilder.Entity<Room>().HasKey(r => r.RoomId);
            modelBuilder.Entity<Payment>().HasKey(p => p.PaymentId);
            modelBuilder.Entity<Wishlist>().HasKey(w => w.WishlistId);
            modelBuilder.Entity<Amenity>().HasKey(a => a.AmenityId);
            modelBuilder.Entity<Message>().HasKey(m => m.MessageId);
            modelBuilder.Entity<Notification>().HasKey(n => n.NotificationId);

            // Define relationships with cascade or restrict deletion as needed
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.HotelArticle)
                .WithMany(h => h.Comments)
                .HasForeignKey(c => c.HotelID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.User)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.HotelArticle)
                .WithMany(h => h.Bookings)
                .HasForeignKey(b => b.HotelID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Room)
                .WithMany(r => r.Bookings)
                .HasForeignKey(b => b.RoomId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Room>()
                .HasOne(r => r.HotelArticle)
                .WithMany(h => h.Rooms)
                .HasForeignKey(r => r.HotelId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.User)
                .WithMany(u => u.Payments)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Booking)
                .WithMany(b => b.Payments)
                .HasForeignKey(p => p.BookingId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Wishlist>()
                .HasOne(w => w.User)
                .WithMany(u => u.Wishlists)
                .HasForeignKey(w => w.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Wishlist>()
                .HasOne(w => w.HotelArticle)
                .WithMany(h => h.Wishlists)
                .HasForeignKey(w => w.HotelId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Amenity>()
                .HasOne(a => a.HotelArticle)
                .WithMany(h => h.Amenities)
                .HasForeignKey(a => a.HotelId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Sender)
                .WithMany(u => u.SentMessages)
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Receiver)
                .WithMany(u => u.ReceivedMessages)
                .HasForeignKey(m => m.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany(u => u.Notifications)
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure decimal precision for specific properties
            modelBuilder.Entity<Payment>()
                .Property(p => p.TotalAmount)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Room>()
                .Property(r => r.Price)
                .HasColumnType("decimal(18, 2)");

            // Add indexes if necessary (e.g., UserId for frequently queried columns)
            modelBuilder.Entity<Booking>().HasIndex(b => b.UserId);
            modelBuilder.Entity<Comment>().HasIndex(c => c.UserId);
        }
    }
}
