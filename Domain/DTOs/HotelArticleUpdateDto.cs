using System;
namespace StartMyNewApp.Domain.DTOs
{
    public class HotelArticleUpdateDto
    {
        public int HotelID { get; set; } 
        public string HotelName { get; set; } = string.Empty; 
        public string HotelDescription { get; set; } = string.Empty; 
        public int HotelStars { get; set; } 
        public string Street { get; set; } = string.Empty; 
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty; 
        public string ZipCode { get; set; } = string.Empty; 
        public string Country { get; set; } = string.Empty; 
        public List<string> Images { get; set; } = new List<string>(); 

        // Optionally, you can include fields for updating the owner/admin relationship
        public int OwnerId { get; set; } 
    }
}
