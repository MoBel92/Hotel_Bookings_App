namespace StartMyNewApp.Domain.DTOs
{
    public class AmenityReadDto
    {
        public int AmenityId { get; set; } // Unique identifier for the amenity
        public string Name { get; set; } = string.Empty; // Name of the amenity
        public string Description { get; set; } = string.Empty; // Description of the amenity
        public bool IsAvailable { get; set; } // Availability status of the amenity

        // Optional: include minimal related information if needed
        public string HotelName { get; set; } = string.Empty; // Name of the associated hotel, if needed for display
    }
}
