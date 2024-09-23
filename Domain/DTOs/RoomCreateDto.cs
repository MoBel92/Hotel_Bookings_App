namespace StartMyNewApp.Domain.DTOs
{
    public class RoomCreateDto
    {
        public string RoomType { get; set; } = string.Empty; // Type of the room (e.g., Single, Double, Suite)
        public decimal Price { get; set; } // Room price, ensure correct precision in DbContext
        public bool IsAvailable { get; set; } = true; // Default to available
        public int HotelId { get; set; } // Foreign key linking to the associated HotelArticle
    }
}

