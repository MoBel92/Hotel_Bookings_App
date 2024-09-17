namespace StartMyNewApp.Domain.Commands
{
    public class DeletePersonCommand
    {
        public int Id { get; set; }

        public DeletePersonCommand(int id)
        {
            Id = id;
        }
    }
}
