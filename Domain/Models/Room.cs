namespace StartMyNewApp.Domain.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public string RoomType { get; set; } = string.Empty; // Default value
        public decimal Price { get; set; } // Ensure precision and scale defined in DbContext
        public bool IsAvailable { get; set; }
        public int HotelId { get; set; } // Foreign key to HotelArticle

        public virtual HotelArticle? HotelArticle { get; set; } // Make this nullable
        public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}

