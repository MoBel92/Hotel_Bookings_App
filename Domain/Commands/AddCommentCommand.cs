namespace StartMyNewApp.Domain.Commands
{
    public class AddCommentCommand
    {
        public string Body { get; set; } = string.Empty; // Initialized to empty string
        public int HotelID { get; set; } // Foreign key to HotelArticles

        // Constructor to initialize the command
        public AddCommentCommand(string body, int hotelID)
        {
            Body = body;
            HotelID = hotelID;
        }
    }
}
