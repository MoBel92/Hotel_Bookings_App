namespace StartMyNewApp.Domain.DTOs
{
    public class WishlistReadDto
    {
        public int WishlistId { get; set; }
        public DateTime AddedDate { get; set; }
        public bool IsActive { get; set; }

        // Simplified user information
        public string? Username { get; set; } // Username of the user who added the item to the wishlist
        public string? HotelName { get; set; } // Name of the hotel added to the wishlist
    }
}

