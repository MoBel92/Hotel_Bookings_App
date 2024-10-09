namespace StartMyNewApp.Domain.Models
{
    public class HotelArticle
    {
        public int HotelID { get; set; } 
        public string HotelName { get; set; } = string.Empty; 
        public string HotelDescription { get; set; } = string.Empty; 
        public int HotelStars { get; set; }
        public string Street { get; set; } = string.Empty; 
        public string City { get; set; } = string.Empty; 
        public string State { get; set; } = string.Empty; 
        public string ZipCode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty; 
        public List<string> Images { get; set; } = new List<string>(); 
        public string Policies { get; set; } = string.Empty; 
        public bool IsAvailable { get; set; } = true; 

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




