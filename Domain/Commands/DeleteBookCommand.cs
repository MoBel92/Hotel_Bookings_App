namespace StartMyNewApp.Domain.Commands
{
    public class DeleteBookCommand
    {
        public int Id { get; set; }

        // Constructor to initialize the command with the book ID
        public DeleteBookCommand(int id)
        {
            Id = id;
        }
    }
}
