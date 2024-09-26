namespace StartMyNewApp.Domain.DTOs
{
    public class HotelArticleReadDto
    {
        public int HotelID { get; set; } // Primary key
        public string HotelName { get; set; } = string.Empty; // Name of the hotel
        public string HotelDescription { get; set; } = string.Empty; // Description of the hotel
        public int HotelStars { get; set; } // Rating of the hotel (1-5)
        public string Street { get; set; } = string.Empty; // Street address
        public string City { get; set; } = string.Empty; // City
        public string State { get; set; } = string.Empty; // State or region
        public string ZipCode { get; set; } = string.Empty; // Postal code
        public string Country { get; set; } = string.Empty; // Country
        public List<string> Images { get; set; } = new List<string>(); // List of image URLs or file paths

        // Owner/Admin properties
        public int OwnerId { get; set; } // ID of the owner
        public string OwnerName { get; set; } = string.Empty; // Owner's name

        // Related data (minimal, as needed)
        public List<int> RoomIds { get; set; } = new List<int>(); // List of room IDs
        public List<int> CommentIds { get; set; } = new List<int>(); // List of comment IDs
        public List<int> BookingIds { get; set; } = new List<int>(); // List of booking IDs
        public List<int> AmenityIds { get; set; } = new List<int>(); // List of amenity IDs
    }
}

