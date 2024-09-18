namespace StartMyNewApp.Domain.Commands
{
    public class DeleteBookingCommand
    {
        public int Id { get; set; }

        public DeleteBookingCommand(int id)
        {
            Id = id;
        }
    }
}
