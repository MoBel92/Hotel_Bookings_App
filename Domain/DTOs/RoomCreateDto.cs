namespace StartMyNewApp.Domain.DTOs
{
    public class RoomCreateDto
    {
        public string RoomType { get; set; } = string.Empty; // Type of the room (e.g., Single, Double, Suite)
        public decimal Price { get; set; } 
        public bool IsAvailable { get; set; } = true; 
        public int HotelId { get; set; } 
    }
}

