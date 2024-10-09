namespace StartMyNewApp.Domain.DTOs
{
    public class CommentReadDto
    {
        public int IdComment { get; set; }
        public string Body { get; set; } = string.Empty;
        public int HotelID { get; set; }
        public int Rating { get; set; }
        public string AdminReply { get; set; } = string.Empty;
        // Minimal related data
        public string UserName { get; set; } = string.Empty;
        public string HotelName { get; set; } = string.Empty;
    }
}
