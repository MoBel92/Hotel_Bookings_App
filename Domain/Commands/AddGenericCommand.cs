namespace StartMyNewApp.Domain.Commands
{
    // Add Command
    public class AddUserCommand
    {
        public string Username { get; set; } = string.Empty; // User name
        public string Name { get; set; } = string.Empty; // Full name
        public string Email { get; set; } = string.Empty; // User email address
        public string Password { get; set; } = string.Empty; // User password
        public string PhoneNumber { get; set; } = string.Empty; // User phone number
    }

    public class AddWishlistCommand
    {
        public int UserId { get; set; } // Foreign key to Users
        public int HotelId { get; set; } // Foreign key to HotelArticles
        public DateTime AddedDate { get; set; } // Date the hotel was added to the wishlist
        public bool IsActive { get; set; } // Indicates if the wishlist entry is active
    }

    public class AddRoomCommand
    {
        public string RoomType { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public int HotelId { get; set; } // Foreign key to HotelArticles
    }

    public class AddPaymentCommand
    {
        public int UserId { get; set; } // Foreign key to Users
        public int BookingId { get; set; } // Foreign key to Bookings
        public decimal TotalAmount { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public string PaymentStatus { get; set; } = string.Empty;
    }

    public class AddLocationCommand
    {
        public string LocationName { get; set; } = string.Empty; // Name of the location
    }

    public class AddHotelArticleCommand
    {
        public string HotelName { get; set; } = string.Empty; // Name of the hotel
        public string HotelDescription { get; set; } = string.Empty; // Description of the hotel
        public int HotelStars { get; set; } // Rating of the hotel (1-5)
        public string Street { get; set; } = string.Empty; // Street address
        public string City { get; set; } = string.Empty; // City
        public string State { get; set; } = string.Empty; // State or region
        public string ZipCode { get; set; } = string.Empty; // Postal code
        public string Country { get; set; } = string.Empty; // Country
        public List<string> Images { get; set; } = new List<string>(); // List of image URLs or file paths
    }

    public class AddCommentCommand
    {
        public string Body { get; set; } = string.Empty; // Comment body
        public int HotelID { get; set; } // Foreign key to HotelArticle
        public int Rating { get; set; }
    }

    public class AddBookingCommand
    {
        public int UserId { get; set; } // Foreign key to User
        public int HotelID { get; set; } // Foreign key to HotelArticle
        public int RoomId { get; set; } // Foreign key to Rooms
        public int NumberOfRooms { get; set; }
        public DateTime CheckInDate { get; set; } // Check-in date
        public DateTime CheckOutDate { get; set; } // Check-out date
    }

    public class AddAmenityCommand
    {
        public string Name { get; set; } = string.Empty; // Name of the amenity
        public string Description { get; set; } = string.Empty; // Optional description
        public bool IsAvailable { get; set; } // Indicates if the amenity is available
        public int HotelId { get; set; } // Foreign key to HotelArticles
    }

}