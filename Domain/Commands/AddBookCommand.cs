namespace StartMyNewApp.Domain.Commands
{
    public class AddBookCommand
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }
        public DateTime DateEdition { get; set; }
        public string Category { get; set; }
        public bool Disponibilite { get; set; }
        public int NombreExemplaire { get; set; }
    }
}
