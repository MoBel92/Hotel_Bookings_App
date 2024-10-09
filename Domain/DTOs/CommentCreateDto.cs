namespace StartMyNewApp.Domain.DTOs
{
    public class CommentCreateDto
    {
        public string Body { get; set; } = string.Empty; 
        public int HotelID { get; set; } 
        public int UserId { get; set; } 
        public int Rating { get; set; } 
    }
}
