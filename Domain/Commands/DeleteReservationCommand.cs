namespace StartMyNewApp.Domain.Commands
{
    public class DeleteReservationCommand
    {
        public int Id { get; set; }

        public DeleteReservationCommand(int id)
        {
            Id = id;
        }
    }
}
