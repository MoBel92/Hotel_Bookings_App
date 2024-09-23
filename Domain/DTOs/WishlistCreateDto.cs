namespace StartMyNewApp.Domain.DTOs
{
    public class WishlistCreateDto
    {
        public int UserId { get; set; } // User who adds the hotel to the wishlist
        public int HotelId { get; set; } // Hotel that is added to the wishlist
        public DateTime AddedDate { get; set; } = DateTime.Now; // Default to the current date
        public bool IsActive { get; set; } = true; // Default to active
    }
}
