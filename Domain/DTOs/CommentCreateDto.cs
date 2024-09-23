namespace StartMyNewApp.Domain.DTOs
{
    public class CommentCreateDto
    {
        public string Body { get; set; } = string.Empty; // Body of the comment
        public int HotelID { get; set; } // ID of the associated hotel
        public int UserId { get; set; } // ID of the user making the comment
        public int Rating { get; set; } // Rating given in the comment (e.g., 1-5)
    }
}
