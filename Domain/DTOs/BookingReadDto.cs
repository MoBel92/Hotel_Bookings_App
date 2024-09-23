namespace StartMyNewApp.Domain.DTOs
{
    public class BookingReadDto
    {
        public int IdBooking { get; set; } // Unique identifier for the booking
        public DateTime CheckInDate { get; set; } // Check-in date of the booking
        public DateTime CheckOutDate { get; set; } // Check-out date of the booking

        // Optional: include minimal related information if needed
        public string Username { get; set; } = string.Empty; // Username of the user who made the booking
        public string HotelName { get; set; } = string.Empty; // Name of the associated hotel
        public string RoomType { get; set; } = string.Empty; // Type of the room booked
        public List<string> PaymentStatuses { get; set; } = new List<string>(); // List of payment statuses, if relevant
    }
}
