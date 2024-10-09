namespace StartMyNewApp.Domain.DTOs
{
    public class HotelArticleCreateDto
    {
        public string HotelName { get; set; } = string.Empty; 
        public string HotelDescription { get; set; } = string.Empty; 
        public int HotelStars { get; set; } 
        public string Street { get; set; } = string.Empty; 
        public string City { get; set; } = string.Empty; 
        public string State { get; set; } = string.Empty; 
        public string ZipCode { get; set; } = string.Empty; 
        public string Country { get; set; } = string.Empty; 
        public List<string> Images { get; set; } = new List<string>(); 

        // Owner/Admin properties
        public int OwnerId { get; set; } 
    }
}
