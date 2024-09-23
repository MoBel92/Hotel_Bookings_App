namespace StartMyNewApp.Domain.DTOs
{
    public class BookingUpdateDto
    {
        public int IdBooking { get; set; } // ID of the booking to update
        public int RoomId { get; set; } // Updated room ID, if the room changes
        public DateTime CheckInDate { get; set; } // Updated check-in date
        public DateTime CheckOutDate { get; set; } // Updated check-out date
    }
}
