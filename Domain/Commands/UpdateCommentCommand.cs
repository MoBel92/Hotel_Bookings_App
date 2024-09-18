namespace StartMyNewApp.Domain.Commands
{
    public class UpdateCommentCommand
    {
        public int IdComment { get; set; } // The ID of the comment to be updated
        public string Body { get; set; } = string.Empty; // Updated content of the comment
        public int HotelID { get; set; } // Foreign key to HotelArticles

        // Constructor to initialize the command
        public UpdateCommentCommand(int idComment, string body, int hotelID)
        {
            IdComment = idComment;
            Body = body;
            HotelID = hotelID;
        }
    }
}
