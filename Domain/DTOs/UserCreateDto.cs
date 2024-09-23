namespace StartMyNewApp.Domain.DTOs
{
    public class UserCreateDto
    {
        public string Username { get; set; } = string.Empty; // Username for the new user
        public string Name { get; set; } = string.Empty; // Full name of the user
        public string Email { get; set; } = string.Empty; // Email address
        public string Password { get; set; } = string.Empty; // Plain text password to be hashed before storing
        public string PhoneNumber { get; set; } = string.Empty; // Phone number
    }
}

