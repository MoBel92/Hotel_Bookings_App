using System;
namespace StartMyNewApp.Domain.DTOs
{
    public class HotelArticleUpdateDto
    {
        public int HotelID { get; set; } // ID of the hotel to update
        public string HotelName { get; set; } = string.Empty; // Updated name of the hotel
        public string HotelDescription { get; set; } = string.Empty; // Updated description of the hotel
        public int HotelStars { get; set; } // Updated rating of the hotel (1-5)

        // Updated address properties
        public string Street { get; set; } = string.Empty; // Updated street address
        public string City { get; set; } = string.Empty; // Updated city
        public string State { get; set; } = string.Empty; // Updated state or region
        public string ZipCode { get; set; } = string.Empty; // Updated postal code
        public string Country { get; set; } = string.Empty; // Updated country

        // Updated images property, if applicable
        public List<string> Images { get; set; } = new List<string>(); // Updated list of image URLs or file paths
    }
}
