namespace StartMyNewApp.Domain.Models
{
    public class Wishlist
    {
        public int WishlistId { get; set; } 
        public int UserId { get; set; } 
        public int HotelId { get; set; } 
        public DateTime AddedDate { get; set; } 
        public bool IsActive { get; set; } 

        // Navigation properties
        public virtual User User { get; set; } = null!; // Non-nullable property with an initializer
        public virtual HotelArticle HotelArticle { get; set; } = null!; // Updated to refer to HotelArticles
    }
}

