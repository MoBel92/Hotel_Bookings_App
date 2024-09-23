namespace StartMyNewApp.Domain.DTOs
{
    public class AmenityCreateDto
    {
        public string Name { get; set; } = string.Empty; // Name of the amenity
        public string Description { get; set; } = string.Empty; // Description of the amenity
        public bool IsAvailable { get; set; } = true; // Default to available
        public int HotelId { get; set; } // ID of the associated hotel
    }
}
