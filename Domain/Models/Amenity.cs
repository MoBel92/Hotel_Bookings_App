namespace StartMyNewApp.Domain.Models
{
    public class Amenity
    {
        public int AmenityId { get; set; }
        public string Name { get; set; } = string.Empty; 
        public string Description { get; set; } = string.Empty; 
        public bool IsAvailable { get; set; }
        public int HotelId { get; set; } // Foreign key to HotelArticle

        public virtual HotelArticle? HotelArticle { get; set; }
    }
}
