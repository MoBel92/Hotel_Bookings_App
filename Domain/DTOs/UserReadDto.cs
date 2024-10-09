namespace StartMyNewApp.Domain.DTOs
{
    public class UserReadDto
    {
        public int IdUser { get; set; }
        public string Username { get; set; } = string.Empty; 
        public string Name { get; set; } = string.Empty; 
        public string Email { get; set; } = string.Empty; 
        public string PhoneNumber { get; set; } = string.Empty; 
        public string Role { get; set; } = "User"; 

        // Include lists of related entities minimally if required
        public List<int> BookingIds { get; set; } = new List<int>(); 
        public List<int> WishlistIds { get; set; } = new List<int>();
        public List<int> PaymentIds { get; set; } = new List<int>(); 
        public List<int> OwnedHotelIds { get; set; } = new List<int>();
    }
}

