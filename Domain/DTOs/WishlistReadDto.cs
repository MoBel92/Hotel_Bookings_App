﻿namespace StartMyNewApp.Domain.DTOs
{
    public class WishlistReadDto
    {
        public int WishlistId { get; set; }
        public DateTime AddedDate { get; set; }
        public bool IsActive { get; set; }

        // Simplified user information
        public string? Username { get; set; } 
        public string? HotelName { get; set; } 
    }
}

