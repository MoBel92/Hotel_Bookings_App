namespace StartMyNewApp.Domain.Commands
{
    public class DeleteLocationCommand
    {
        public int Id { get; set; }

        // Constructor to initialize the command with the book ID
        public DeleteLocationCommand(int id)
        {
            Id = id;
        }
    }
}
