namespace StartMyNewApp.Domain.DTOs
{
    public class LocationUpdateDto
    {
        public int IdLocation { get; set; } // ID of the location to update
        public string LocationName { get; set; } = string.Empty; // Updated name of the location
    }
}
