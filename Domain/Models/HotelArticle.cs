using System.Collections.Generic; // Ensure this is included for ICollection

namespace StartMyNewApp.Domain.Models
{
    public class HotelArticle
    {
        public int HotelID { get; set; } // Primary key
        public string HotelName { get; set; } = string.Empty; // Name of the hotel
        public string HotelDescription { get; set; } = string.Empty; // Description of the hotel
        public int HotelStars { get; set; } // Rating of the hotel (1-5)

        // Address properties
        public string Street { get; set; } = string.Empty; // Street address
        public string City { get; set; } = string.Empty; // City
        public string State { get; set; } = string.Empty; // State or region
        public string ZipCode { get; set; } = string.Empty; // Postal code
        public string Country { get; set; } = string.Empty; // Country

        // Images property
        public List<string> Images { get; set; } = new List<string>(); // List of image URLs or file paths

        // Navigation properties
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>(); // Collection of comments
        public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>(); // Collection of bookings
        public virtual ICollection<Room> Rooms { get; set; } = new List<Room>(); // Collection of rooms
        public virtual ICollection<Wishlist> Wishlists { get; set; } = new List<Wishlist>(); // Collection of wishlists
        public virtual ICollection<Amenity> Amenities { get; set; } = new List<Amenity>(); // Collection of amenities
    }
}





