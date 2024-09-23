namespace StartMyNewApp.Domain.DTOs
{
    public class LocationReadDto
    {
        public int IdLocation { get; set; } // Unique identifier for the location
        public string LocationName { get; set; } = string.Empty; // Name of the location
    }
}
