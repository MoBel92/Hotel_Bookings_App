namespace StartMyNewApp.Domain.DTOs
{
    public class UserReadDto
    {
        public int IdUser { get; set; } // ID of the user
        public string Username { get; set; } = string.Empty; // Username
        public string Name { get; set; } = string.Empty; // Full name
        public string Email { get; set; } = string.Empty; // Email address
        public string PhoneNumber { get; set; } = string.Empty; // Phone number

        // You can include related data minimally if required, like:
        public List<string> BookingIds { get; set; } = new List<string>(); // List of booking identifiers (if needed)
        public List<string> WishlistIds { get; set; } = new List<string>(); // List of wishlist identifiers (if needed)
        public List<string> PaymentIds { get; set; } = new List<string>(); // List of payment identifiers (if needed)
    }
}

