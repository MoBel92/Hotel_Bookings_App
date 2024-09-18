namespace StartMyNewApp.Domain.Models
{
    public class HotelArticle
    {
        public int HotelID { get; set; } // Primary key
        public string HotelName { get; set; } = string.Empty; // Name of the hotel
        public string HotelDescription { get; set; } = string.Empty; // Description of the hotel
        public string LocationName { get; set; } = string.Empty; // Location name (no longer a reference to the Location table)
        public int HotelStars { get; set; } // Rating of the hotel
    }
}

