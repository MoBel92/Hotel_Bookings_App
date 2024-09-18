namespace StartMyNewApp.Domain.Commands
{
    public class AddHotelCommand
    {
        public string HotelName { get; set; } = string.Empty; // Initialized to empty string
        public string HotelDescription { get; set; } = string.Empty;
        public string HotelLocation { get; set; } = string.Empty;
        public int HotelStars { get; set; } // Rating out of 5
    }
}
