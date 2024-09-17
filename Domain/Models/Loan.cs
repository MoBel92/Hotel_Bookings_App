namespace StartMyNewApp.Domain.Models
{
    public class Loan
    {
        public int IdEmprunt { get; set; }  // Primary key

        public DateTime DateEmprunt { get; set; }
        public DateTime DateRetour { get; set; }
        public int FKLivre { get; set; }  // Foreign key to Book
        public int FKAdherent { get; set; }  // Foreign key to Person
    }
}


