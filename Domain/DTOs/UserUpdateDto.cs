namespace StartMyNewApp.Domain.DTOs
{
    public class UserUpdateDto
    {
        public int IdUser { get; set; }
        public string Name { get; set; } = string.Empty; 
        public string Email { get; set; } = string.Empty; 
        public string PhoneNumber { get; set; } = string.Empty;
        public string Role { get; set; } = "User"; // Role: User, Admin, Owner
        // Optional: Handle role updates securely based on admin privileges
    }
}