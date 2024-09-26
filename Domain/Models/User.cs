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
        public string Role { get; set; } = "User"; // Role: User, Admin, Owner
        public bool IsVerified { get; set; } = false; // Verification status
        public string Status { get; set; } = "Active"; // Active, Inactive, etc.

        // Navigation properties
        public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        public virtual ICollection<Wishlist> Wishlists { get; set; } = new List<Wishlist>();
        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
        public virtual ICollection<HotelArticle> OwnedHotels { get; set; } = new List<HotelArticle>(); // Hotels owned by the user
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>(); // Comments by the user
        public virtual ICollection<Message> SentMessages { get; set; } = new List<Message>(); // Messages sent by the user
        public virtual ICollection<Message> ReceivedMessages { get; set; } = new List<Message>(); // Messages received by the user
        public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>(); // Notifications related to the user
    }
}
