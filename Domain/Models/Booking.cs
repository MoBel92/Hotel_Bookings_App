namespace StartMyNewApp.Domain.Models
{
    public class Booking
    {
        public int IdBooking { get; set; } // Primary key
        public int UserId { get; set; } // Foreign key to User
        public int HotelID { get; set; } // Foreign key to HotelArticle
        public DateTime BookingDate { get; set; } = DateTime.Now; // Date of the booking
        public DateTime CheckInDate { get; set; } // Check-in date
        public DateTime CheckOutDate { get; set; } // Check-out date

        // Navigation properties
        public virtual User? User { get; set; } // Make virtual and nullable if optional
        public virtual HotelArticle? HotelArticle { get; set; } // Make virtual and nullable if optional
    }
}

