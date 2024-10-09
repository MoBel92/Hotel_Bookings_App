﻿namespace StartMyNewApp.Domain.DTOs
{
    public class BookingCreateDto
    {
        public int UserId { get; set; } 
        public int HotelID { get; set; } 
        public int RoomId { get; set; } 
        public DateTime CheckInDate { get; set; } 
        public DateTime CheckOutDate { get; set; }
    }
}
