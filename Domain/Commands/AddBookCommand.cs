namespace StartMyNewApp.Domain.Commands
{
    public class AddBookCommand
    {
        public string Title { get; set; } = string.Empty; // Initialized to empty string
        public string ISBN { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public DateTime DateEdition { get; set; } = DateTime.Now; // Default to current date
        public string Category { get; set; } = string.Empty;
        public bool Disponibilite { get; set; } = true; // Default to true (if available)
        public int NombreExemplaire { get; set; } = 1; // Default to 1 copy
    }
}
