namespace StartMyNewApp.Domain.Models
{
    public class User
    {
        public int IdUser { get; set; }
        public string Username { get; set; } = string.Empty; 
        public string Name { get; set; } = string.Empty; 
        public string Email { get; set; } = string.Empty; 
        public string Password { get; set; } = string.Empty; 
        public string PhoneNumber { get; set; } = string.Empty; 
        public string Role { get; set; } = "User";
        public bool IsVerified { get; set; } = false; 
        public string Status { get; set; } = "Active"; 

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
