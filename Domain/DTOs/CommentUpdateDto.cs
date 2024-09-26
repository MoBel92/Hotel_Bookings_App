namespace StartMyNewApp.Domain.DTOs
{
    public class CommentUpdateDto
    {
        public int IdComment { get; set; } // Primary key of the comment to update
        public string Body { get; set; } = string.Empty; // Updated comment body
        public int Rating { get; set; } // Updated user rating
        public string AdminReply { get; set; } = string.Empty; // Updated admin reply, if applicable
    }
}
