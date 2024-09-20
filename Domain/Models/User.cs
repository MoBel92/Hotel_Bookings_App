namespace StartMyNewApp.Domain.Models
{
    public class User
    {
        public int IdUser { get; set; } // Primary key
        public string Username { get; set; } = string.Empty; // User name
        public string Name { get; set; } = string.Empty; // Full name
        public string Email { get; set; } = string.Empty; // User email address
        public string Password { get; set; } = string.Empty; // User password (hashed)
        public string PhoneNumber { get; set; } = string.Empty; // User phone number

        // Navigation properties
        public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        public virtual ICollection<Wishlist> Wishlists { get; set; } = new List<Wishlist>();
        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}


