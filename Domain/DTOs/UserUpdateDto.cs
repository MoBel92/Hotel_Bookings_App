namespace StartMyNewApp.Domain.DTOs
{
    public class UserUpdateDto
    {
        public int IdUser { get; set; } // ID of the user to update
        public string Name { get; set; } = string.Empty; // Updated full name
        public string Email { get; set; } = string.Empty; // Updated email address
        public string PhoneNumber { get; set; } = string.Empty; // Updated phone number
        // Optionally, you can include fields for updating the password securely if required
    }
}
