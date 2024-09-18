namespace StartMyNewApp.Domain.Commands
{
    public class UpdateUserCommand
    {
        public int IdUser { get; set; } // The ID of the user to be updated
        public string Username { get; set; } = string.Empty; // Initialized to empty string
        public string Name { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; } // Nullable
    }
}

