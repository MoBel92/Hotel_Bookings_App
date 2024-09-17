namespace StartMyNewApp.Domain.Models
{
    public class Reservation
    {
        public int IdReservation { get; set; }
        public int FKLivre { get; set; }
        public int FKPersonne { get; set; } // Person making the reservation
    }
}
