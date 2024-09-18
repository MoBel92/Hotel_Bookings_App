namespace StartMyNewApp.Domain.Models
{
    public class Booking
    {
        public int IdBooking { get; set; } // Primary key
        public int UserId { get; set; } // Foreign key to User
        public int HotelID { get; set; } // Foreign key to HotelArticle
        public DateTime BookingDate { get; set; } = DateTime.Now; // Date when the booking was made
        public DateTime CheckInDate { get; set; } // Check-in date for the booking
        public DateTime CheckOutDate { get; set; } // Check-out date for the booking
        public int NumberOfGuests { get; set; } // Number of guests for the booking
        public string SpecialRequests { get; set; } = string.Empty; // Any special requests from the user

        // Navigation properties
        public virtual User User { get; set; } // Navigation property for User
        public virtual HotelArticle HotelArticle { get; set; } // Navigation property for HotelArticle
    }
}


