namespace StartMyNewApp.Domain.Commands
{
    public class AddPersonCommand
    {
        public string Cin { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaissance { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
    }
}
