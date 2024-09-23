namespace StartMyNewApp.Domain.DTOs
{
    public class HotelArticleReadDto
    {
        public int HotelID { get; set; } // Unique identifier for the hotel
        public string HotelName { get; set; } = string.Empty; // Name of the hotel
        public string HotelDescription { get; set; } = string.Empty; // Description of the hotel
        public int HotelStars { get; set; } // Rating of the hotel (1-5)

        // Address properties
        public string Street { get; set; } = string.Empty; // Street address
        public string City { get; set; } = string.Empty; // City
        public string State { get; set; } = string.Empty; // State or region
        public string ZipCode { get; set; } = string.Empty; // Postal code
        public string Country { get; set; } = string.Empty; // Country

        // Images property
        public List<string> Images { get; set; } = new List<string>(); // List of image URLs or file paths

        // Optional: include minimal related information if needed
        public List<string> Comments { get; set; } = new List<string>(); // Simplified list of comments, if relevant
        public List<string> RoomTypes { get; set; } = new List<string>(); // Simplified list of room types, if relevant
        public List<string> Amenities { get; set; } = new List<string>(); // Simplified list of amenities, if relevant
    }
}

