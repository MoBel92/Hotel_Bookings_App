namespace StartMyNewApp.Domain.Commands
{
    public class DeleteUserCommand
    {
        public int Id { get; set; }

        public DeleteUserCommand(int id)
        {
            Id = id;
        }
    }
}
