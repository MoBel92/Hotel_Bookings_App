namespace StartMyNewApp.Domain.DTOs
{
    public class UserUpdateDto
    {
        public int IdUser { get; set; } // ID of the user to update
        public string Name { get; set; } = string.Empty; // Updated full name
        public string Email { get; set; } = string.Empty; // Updated email address
        public string PhoneNumber { get; set; } = string.Empty; // Updated phone number
        public string Role { get; set; } = "User"; // Role: User, Admin, Owner
        // Optional: Handle role updates securely based on admin privileges
    }
}