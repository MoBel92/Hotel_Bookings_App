using System;
namespace StartMyNewApp.Domain.DTOs
{
    public class HotelArticleUpdateDto
    {
        public int HotelID { get; set; } // Primary key
        public string HotelName { get; set; } = string.Empty; // Updated name of the hotel
        public string HotelDescription { get; set; } = string.Empty; // Updated description
        public int HotelStars { get; set; } // Updated rating of the hotel (1-5)
        public string Street { get; set; } = string.Empty; // Updated street address
        public string City { get; set; } = string.Empty; // Updated city
        public string State { get; set; } = string.Empty; // Updated state or region
        public string ZipCode { get; set; } = string.Empty; // Updated postal code
        public string Country { get; set; } = string.Empty; // Updated country
        public List<string> Images { get; set; } = new List<string>(); // Updated list of image URLs or file paths

        // Optionally, you can include fields for updating the owner/admin relationship
        public int OwnerId { get; set; } // Updated owner ID if needed
    }
}
