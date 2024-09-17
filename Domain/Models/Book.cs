// Domain Project - Book.cs
namespace StartMyNewApp.Domain.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }
        public DateTime DateEdition { get; set; }
        public string Category { get; set; }
        public bool Disponibilite { get; set; }
        // Other properties...
    }
}
