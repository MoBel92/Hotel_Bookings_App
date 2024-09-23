namespace StartMyNewApp.Domain.DTOs
{
    public class RoomUpdateDto
    {
        public int RoomId { get; set; } // ID of the room to update
        public string RoomType { get; set; } = string.Empty; // Updated type of the room
        public decimal Price { get; set; } // Updated room price
        public bool IsAvailable { get; set; } // Update availability status
        // You may include HotelId if room re-assignment is possible, but typically this remains static
    }
}

