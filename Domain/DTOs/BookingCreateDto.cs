namespace StartMyNewApp.Domain.DTOs
{
    public class BookingCreateDto
    {
        public int UserId { get; set; } // ID of the user making the booking
        public int HotelID { get; set; } // ID of the associated hotel
        public int RoomId { get; set; } // ID of the room being booked
        public DateTime CheckInDate { get; set; } // Check-in date for the booking
        public DateTime CheckOutDate { get; set; } // Check-out date for the booking
    }
}
