using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StartMyNewApp.Domain.Models
{
    public class HotelArticle
    {
        public int HotelID { get; set; }

        [Required]
        [MaxLength(255)] // Maximum length constraint for the name
        public string HotelName { get; set; } = string.Empty;

        [Required]
        public string HotelDescription { get; set; } = string.Empty;

        [Range(1, 5)] // Assuming hotel stars should be between 1 and 5
        public int HotelStars { get; set; }

        [Required]
        [MaxLength(255)] // Assuming street names should be limited to a reasonable length
        public string Street { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

        // List of image paths for the hotel (stored as strings in the DB)
        public List<string> ImagePaths { get; set; } = new List<string>();

        // Policies (optional)
        public string Policies { get; set; } = string.Empty;

        public bool IsAvailable { get; set; } = true;

        // Nullable OwnerId, in case the article is not linked to a specific owner
        public int? OwnerId { get; set; }

        // Nullable relationship with the User table (Owner)
        public virtual User? Owner { get; set; }

        // Navigation properties for related data
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
        public virtual ICollection<Wishlist> Wishlists { get; set; } = new List<Wishlist>();
        public virtual ICollection<Amenity> Amenities { get; set; } = new List<Amenity>();
    }
}
