namespace StartMyNewApp.Domain.DTOs
{
    public class AmenityCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsAvailable { get; set; } = true;
        public int HotelId { get; set; }
    }
}
