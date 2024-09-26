namespace StartMyNewApp.Domain.DTOs
{
    public class HotelArticleCreateDto
    {
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
        public int OwnerId { get; set; } // Foreign key to User with Owner/Admin role
    }
}
