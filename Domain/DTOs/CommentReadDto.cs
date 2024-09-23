namespace StartMyNewApp.Domain.DTOs
{
    public class CommentReadDto
    {
        public int IdComment { get; set; } // Unique identifier for the comment
        public string Body { get; set; } = string.Empty; // Body of the comment
        public int Rating { get; set; } // Rating of the comment

        // Optional: include minimal related information if needed
        public string HotelName { get; set; } = string.Empty; // Name of the associated hotel
        public string Username { get; set; } = string.Empty; // Username of the user who made the comment
    }
}
