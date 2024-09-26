namespace StartMyNewApp.Domain.DTOs
{
    public class UserReadDto
    {
        public int IdUser { get; set; } // ID of the user
        public string Username { get; set; } = string.Empty; // Username
        public string Name { get; set; } = string.Empty; // Full name
        public string Email { get; set; } = string.Empty; // Email address
        public string PhoneNumber { get; set; } = string.Empty; // Phone number
        public string Role { get; set; } = "User"; // Role: User, Admin, Owner

        // Include lists of related entities minimally if required
        public List<int> BookingIds { get; set; } = new List<int>(); // List of booking identifiers
        public List<int> WishlistIds { get; set; } = new List<int>(); // List of wishlist identifiers
        public List<int> PaymentIds { get; set; } = new List<int>(); // List of payment identifiers
        public List<int> OwnedHotelIds { get; set; } = new List<int>(); // List of owned hotel identifiers (if role is Owner)
    }
}

