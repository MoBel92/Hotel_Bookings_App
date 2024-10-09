namespace StartMyNewApp.Domain.DTOs
{
    public class WishlistCreateDto
    {
        public int UserId { get; set; } 
        public int HotelId { get; set; }
        public DateTime AddedDate { get; set; } = DateTime.Now; 
        public bool IsActive { get; set; } = true; 
    }
}
