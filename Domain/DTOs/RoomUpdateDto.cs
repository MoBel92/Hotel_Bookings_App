namespace StartMyNewApp.Domain.DTOs
{
    public class RoomUpdateDto
    {
        public int RoomId { get; set; } 
        public string RoomType { get; set; } = string.Empty; 
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
    }
}

