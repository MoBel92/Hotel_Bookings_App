namespace StartMyNewApp.Domain.Commands
{
    public class DeleteHotelCommand
    {
        public int Id { get; set; }

        // Constructor to initialize the command with the book ID
        public DeleteHotelCommand(int id)
        {
            Id = id;
        }
    }
}
