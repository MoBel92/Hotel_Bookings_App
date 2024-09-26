namespace StartMyNewApp.Domain.DTOs
{
    public class CommentReadDto
    {
        public int IdComment { get; set; } // Primary key
        public string Body { get; set; } = string.Empty; // Comment body
        public int HotelID { get; set; } // ID of the related hotel
        public int Rating { get; set; } // User rating
        public string AdminReply { get; set; } = string.Empty; // Admin response if any

        // Minimal related data
        public string UserName { get; set; } = string.Empty; // Name of the user who commented
        public string HotelName { get; set; } = string.Empty; // Name of the hotel commented on
    }
}
