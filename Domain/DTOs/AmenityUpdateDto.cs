namespace StartMyNewApp.Domain.DTOs
{
    public class AmenityUpdateDto
    {
        public int AmenityId { get; set; } // ID of the amenity to update
        public string Name { get; set; } = string.Empty; // Updated name of the amenity
        public string Description { get; set; } = string.Empty; // Updated description of the amenity
        public bool IsAvailable { get; set; } // Update availability status
    }
}
