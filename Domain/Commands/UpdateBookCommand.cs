namespace StartMyNewApp.Domain.Commands
{
    public class UpdateBookCommand
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }
        public DateTime DateEdition { get; set; }
        public string Category { get; set; }
        public bool Disponibilite { get; set; }

        // Parameterless constructor (for flexibility, especially in web APIs)
        public UpdateBookCommand() { }

        // Constructor that requires all properties (for stricter initialization)
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
