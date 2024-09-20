namespace StartMyNewApp.Domain.Models
{
    public class Booking
    {
        public int IdBooking { get; set; }
        public int UserId { get; set; } // Foreign key to User
        public int HotelID { get; set; } // Foreign key to HotelArticle
        public int RoomId { get; set; } // Foreign key to Room
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public virtual User? User { get; set; } // Make this nullable
        public virtual HotelArticle? HotelArticle { get; set; } // Make this nullable
        public virtual Room? Room { get; set; } // Make this nullable
        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>(); // Collection of payments
    }
}
