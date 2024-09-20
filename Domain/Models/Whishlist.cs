namespace StartMyNewApp.Domain.Models
{
    public class Wishlist
    {
        public int WishlistId { get; set; } // Unique identifier for the wishlist entry
        public int UserId { get; set; } // Foreign key to Users
        public int HotelId { get; set; } // Foreign key to HotelArticles
        public DateTime AddedDate { get; set; } // Date the hotel was added to the wishlist
        public bool IsActive { get; set; } // Indicates if the wishlist entry is active

        // Navigation properties
        public virtual User User { get; set; } = null!; // Non-nullable property with an initializer
        public virtual HotelArticle HotelArticle { get; set; } = null!; // Updated to refer to HotelArticles
    }
}

