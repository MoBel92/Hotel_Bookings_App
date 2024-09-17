namespace StartMyNewApp.Domain.Commands
{
    public class AddReservationCommand
    {
        public int IdReservation { get; set; }
        public int BookId { get; set; }  // FK to Book
        public int PersonId { get; set; }  // FK to Person
        public DateTime ReservationDate { get; set; }

        // Constructor to initialize the command
        public AddReservationCommand(int idReservation, int bookId, int personId, DateTime reservationDate)
        {
            IdReservation = idReservation;
            BookId = bookId;
            PersonId = personId;
            ReservationDate = reservationDate;
        }
    }
}
