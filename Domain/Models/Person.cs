namespace StartMyNewApp.Domain.Models
{
    public class Person
    {
        public int IdPersonne { get; set; }
        public string Cin { get; set; } = string.Empty; // Initialize to empty string
        public string Nom { get; set; } = string.Empty;
        public string Prenom { get; set; } = string.Empty;
        public DateTime DateNaissance { get; set; } = DateTime.Now; // Default to current date
        public string Email { get; set; } = string.Empty;
        public string Tel { get; set; } = string.Empty;
        public int FKAdherent { get; set; }
    }
}
