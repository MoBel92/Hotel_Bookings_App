namespace StartMyNewApp.Domain.DTOs
{
    public class BookingUpdateDto
    {
        public int IdBooking { get; set; } 
        public int RoomId { get; set; } 
        public DateTime CheckInDate { get; set; } 
        public DateTime CheckOutDate { get; set; } 
    }
}
