﻿namespace StartMyNewApp.Domain.DTOs
{
    public class AmenityReadDto
    {
        public int AmenityId { get; set; } 
        public string Name { get; set; } = string.Empty; 
        public string Description { get; set; } = string.Empty; 
        public bool IsAvailable { get; set; } 

        // Optional: include minimal related information if needed
        public string HotelName { get; set; } = string.Empty; // Name of the associated hotel, if needed for display
    }
}
