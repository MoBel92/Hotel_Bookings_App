namespace StartMyNewApp.Domain.Commands
{
    public class AddPersonCommand
    {
        public string Cin { get; set; } = string.Empty; // Initialized to empty string
        public string Nom { get; set; } = string.Empty;
        public string Prenom { get; set; } = string.Empty;
        public DateTime DateNaissance { get; set; } = DateTime.Now; // Default to current date
        public string Email { get; set; } = string.Empty;
        public string Tel { get; set; } = string.Empty;
    }
}
