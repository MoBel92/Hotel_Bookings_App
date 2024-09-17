namespace StartMyNewApp.Domain.Commands
{
    public class UpdateBookCommand
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty; // Initialize to empty string
        public string ISBN { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public DateTime DateEdition { get; set; } = DateTime.Now; // Default to current date
        public string Category { get; set; } = string.Empty;
        public bool Disponibilite { get; set; } = true; // Default to true

        // Parameterless constructor
        public UpdateBookCommand() { }

        // Constructor with parameters
        public UpdateBookCommand(int id, string title, string isbn, string author, DateTime dateEdition, string category, bool disponibilite)
        {
            Id = id;
            Title = title;
            ISBN = isbn;
            Author = author;
            DateEdition = dateEdition;
            Category = category;
            Disponibilite = disponibilite;
        }
    }
}
