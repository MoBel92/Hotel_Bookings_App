namespace StartMyNewApp.Domain.Models
{
    public class Location
    {
        public int IdLocation { get; set; } // Primary key
        public string LocationName { get; set; } = string.Empty; // Name of the location
    }
}
