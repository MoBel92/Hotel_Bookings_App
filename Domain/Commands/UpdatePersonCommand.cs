namespace StartMyNewApp.Domain.Commands
{
    public class UpdatePersonCommand
    {
        public int IdPersonne { get; set; }
        public string Cin { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaissance { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }

        public UpdatePersonCommand(int idPersonne, string cin, string nom, string prenom, DateTime dateNaissance, string email, string tel)
        {
            IdPersonne = idPersonne;
            Cin = cin;
            Nom = nom;
            Prenom = prenom;
            DateNaissance = dateNaissance;
            Email = email;
            Tel = tel;
        }
    }
}
