namespace StartMyNewApp.Domain.DTOs
{
    public class AmenityUpdateDto
    {
        public int AmenityId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsAvailable { get; set; }
    }
}
