namespace StartMyNewApp.Domain.DTOs
{
    public class RoomReadDto
    {
        public int RoomId { get; set; } // Unique identifier for the room
        public string RoomType { get; set; } = string.Empty; // Type of the room
        public decimal Price { get; set; } // Price of the room
        public bool IsAvailable { get; set; } // Availability status

        // Minimal related data can be included if necessary
        public string HotelName { get; set; } = string.Empty; // Name of the associated hotel, if needed for display
    }
}
