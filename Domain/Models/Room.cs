namespace StartMyNewApp.Domain.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public string RoomType { get; set; } = string.Empty; 
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public int HotelId { get; set; } // Foreign key to HotelArticle

        public virtual HotelArticle? HotelArticle { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}

