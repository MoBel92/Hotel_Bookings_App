namespace StartMyNewApp.Domain.Commands
{
    public class AddUserCommand
    {
        public string Username { get; set; } = string.Empty; // Initialized to empty string
        public string Name { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; } // Nullable
    }
}
