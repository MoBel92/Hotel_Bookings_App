namespace StartMyNewApp.Domain.DTOs
{
    public class CommentUpdateDto
    {
        public int IdComment { get; set; } 
        public string Body { get; set; } = string.Empty; 
        public int Rating { get; set; }
        public string AdminReply { get; set; } = string.Empty;
    }
}
