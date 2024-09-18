namespace StartMyNewApp.Domain.Commands
{
    public class UpdateBookingCommand
    {
        public int IdBooking { get; set; } // The ID of the booking to be updated
        public int UserId { get; set; } // Foreign key to User
        public int HotelID { get; set; } // Foreign key to HotelArticles
        public DateTime CheckInDate { get; set; } // Check-in date
        public DateTime CheckOutDate { get; set; } // Check-out date
    }
}
