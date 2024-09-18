namespace StartMyNewApp.Domain.Models
{
    public class User
    {
        public int IdUser { get; set; } // Primary key
        public string Username { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; } // Nullable
    }
}

