namespace StartMyNewApp.Domain.Models
{
    public class Comment
    {
        public int IdComment { get; set; } // Primary key
        public string Body { get; set; } = string.Empty; // Comment body
        public int HotelID { get; set; } // Foreign key to HotelArticle
        public int UserId { get; set; } // Foreign key to User
        public int Rating { get; set; } // User rating
        public string AdminReply { get; set; } = string.Empty; // Optional admin response to the comment

        // Navigation properties
        public virtual HotelArticle? HotelArticle { get; set; } // Link to the hotel
        public virtual User? User { get; set; } // User who left the comment
    }
}

