﻿namespace StartMyNewApp.Domain.DTOs
{
    public class UserCreateDto
    {
        public string Username { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty; 
        public string Password { get; set; } = string.Empty; 
        public string PhoneNumber { get; set; } = string.Empty; 
        public string Role { get; set; } = "User";
    }
}

