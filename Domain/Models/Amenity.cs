namespace StartMyNewApp.Domain.Models
{
    public class Amenity
    {
        public int AmenityId { get; set; }
        public string Name { get; set; } = string.Empty; // Default value
        public string Description { get; set; } = string.Empty; // Default value
        public bool IsAvailable { get; set; }
        public int HotelId { get; set; } // Foreign key to HotelArticle

        public virtual HotelArticle? HotelArticle { get; set; } // Make this nullable
    }
}
