namespace StartMyNewApp.Domain.DTOs
{
    public class WishlistUpdateDto
    {
        public int WishlistId { get; set; } // ID of the wishlist entry to update
        public bool IsActive { get; set; } // Update the active status of the entry
    }
}

