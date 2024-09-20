namespace StartMyNewApp.Domain.Commands
{
    public class UpdateUserCommand
    {
        public int IdUser { get; set; } // The ID of the user to be updated
        public string Username { get; set; } = string.Empty; // Updated user name
        public string Name { get; set; } = string.Empty; // Updated full name
        public string Email { get; set; } = string.Empty; // Updated email address
        public string Password { get; set; } = string.Empty; // Updated password (if changing)
        public string PhoneNumber { get; set; } = string.Empty; // Updated phone number
    }

    public class UpdateWishlistCommand
    {
        public int WishlistId { get; set; }
        public int UserId { get; set; } // Foreign key to Users
        public int HotelId { get; set; } // Foreign key to HotelArticles
        public bool IsActive { get; set; } // Indicates if the wishlist entry is active
    }

    public class UpdateRoomCommand
    {
        public int RoomId { get; set; } // The ID of the room to be updated
        public string RoomType { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public int HotelId { get; set; } // Foreign key to HotelArticles
    }

    public class UpdatePaymentCommand
    {
        public int PaymentId { get; set; }
        public int UserId { get; set; } // Foreign key to Users
        public int BookingId { get; set; } // Foreign key to Bookings
        public decimal TotalAmount { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public string PaymentStatus { get; set; } = string.Empty;
    }

    public class UpdateLocationCommand
    {
        public int IdLocation { get; set; } // The ID of the location to be updated
        public string LocationName { get; set; } = string.Empty;
    }

    public class UpdateHotelArticleCommand
    {
        public int HotelID { get; set; } // The ID of the hotel to be updated
        public string HotelName { get; set; } = string.Empty; // Updated name of the hotel
        public string HotelDescription { get; set; } = string.Empty; // Updated description of the hotel
        public int HotelStars { get; set; } // Updated rating of the hotel (1-5)
        public string Street { get; set; } = string.Empty; // Updated street address
        public string City { get; set; } = string.Empty; // Updated city
        public string State { get; set; } = string.Empty; // Updated state or region
        public string ZipCode { get; set; } = string.Empty; // Updated postal code
        public string Country { get; set; } = string.Empty; // Updated country
        public List<string> Images { get; set; } = new List<string>(); // Updated list of image URLs or file paths
    }

    public class UpdateCommentCommand
    {
        public int IdComment { get; set; } // The ID of the comment to be updated
        public string Body { get; set; } = string.Empty; // Updated content of the comment
        public int HotelID { get; set; } // Foreign key to HotelArticle
        public int Rating { get; set; }
    }

    public class UpdateBookingCommand
    {
        public int IdBooking { get; set; } // The ID of the booking to be updated
        public int UserId { get; set; } // Foreign key to User
        public int HotelID { get; set; } // Foreign key to HotelArticle
        public int RoomId { get; set; } // Foreign key to Rooms
        public int NumberOfRooms { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
    }

    public class UpdateAmenityCommand
    {
        public int AmenityId { get; set; } // The ID of the amenity to be updated
        public string Name { get; set; } = string.Empty; // Updated name of the amenity
        public string Description { get; set; } = string.Empty; // Updated description
        public bool IsAvailable { get; set; } // Updated availability status
        public int HotelId { get; set; } // Foreign key to HotelArticles
    }
}
