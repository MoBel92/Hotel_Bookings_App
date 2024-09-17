namespace StartMyNewApp.Domain.Commands
{
    public class UpdateReservationCommand
    {
        public int Id { get; set; }
        public string ReservationName { get; set; }

        public UpdateReservationCommand(int id, string reservationName)
        {
            Id = id;
            ReservationName = reservationName;
        }
    }
}
