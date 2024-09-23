namespace StartMyNewApp.Domain.DTOs
{
    public class CommentUpdateDto
    {
        public int IdComment { get; set; } // ID of the comment to update
        public string Body { get; set; } = string.Empty; // Updated body of the comment
        public int Rating { get; set; } // Updated rating of the comment
    }
}
