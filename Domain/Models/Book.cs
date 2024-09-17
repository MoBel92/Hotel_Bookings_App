namespace StartMyNewApp.Domain.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;  // Initialize to empty string
        public string ISBN { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public DateTime DateEdition { get; set; } = DateTime.Now; // Default to current date
        public string Category { get; set; } = string.Empty;
        public bool Disponibilite { get; set; } = true; // Default to true
        // Other properties...
    }
}
