namespace StartMyNewApp.Domain.Models
{
    public class HotelArticle
    {
        public int HotelID { get; set; } // Primary key
        public string HotelName { get; set; } = string.Empty; // Name of the hotel
        public string HotelDescription { get; set; } = string.Empty; // Description of the hotel
        public int HotelStars { get; set; } // Rating of the hotel (1-5)
        public string Street { get; set; } = string.Empty; // Street address
        public string City { get; set; } = string.Empty; // City
        public string State { get; set; } = string.Empty; // State or region
        public string ZipCode { get; set; } = string.Empty; // Postal code
        public string Country { get; set; } = string.Empty; // Country
        public List<string> Images { get; set; } = new List<string>(); // List of image URLs or file paths
        public string Policies { get; set; } = string.Empty; // Hotel policies, e.g., cancellation policies
        public bool IsAvailable { get; set; } = true; // Availability status

        // Owner/Admin properties
        public int OwnerId { get; set; } // Foreign key to User with Owner/Admin role
        public virtual User Owner { get; set; } = null!; // Owner of the hotel

        // Navigation properties
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
        public virtual ICollection<Wishlist> Wishlists { get; set; } = new List<Wishlist>();
        public virtual ICollection<Amenity> Amenities { get; set; } = new List<Amenity>();
    }
}




