namespace StartMyNewApp.Domain.Models
{
    public class Comment
    {
        public int IdComment { get; set; } // Primary key
        public string Body { get; set; } = string.Empty; // Comment content
        public int UserId { get; set; } // Foreign key to User
        public int HotelID { get; set; } // Foreign key to HotelArticle
        public virtual User? User { get; set; } // Made nullable
        public virtual HotelArticle? HotelArticle { get; set; } // Made nullable
    }
}

