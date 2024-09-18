namespace StartMyNewApp.Domain.Models
{
    public class Comment
    {
        public int IdComment { get; set; } // Primary key
        public string Body { get; set; } = string.Empty; // Comment body
        public int HotelID { get; set; } // Foreign key to HotelArticle
        public virtual HotelArticle? HotelArticle { get; set; } // Make virtual and nullable if optional
        public virtual User? User { get; set; } // Make virtual and nullable if optional
    }
}
