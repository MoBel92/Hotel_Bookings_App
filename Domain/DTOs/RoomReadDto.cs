namespace StartMyNewApp.Domain.DTOs
{
    public class RoomReadDto
    {
        public int RoomId { get; set; } 
        public string RoomType { get; set; } = string.Empty; 
        public decimal Price { get; set; } 
        public bool IsAvailable { get; set; } 

        // Minimal related data can be included if necessary
        public string HotelName { get; set; } = string.Empty; 
    }
}
