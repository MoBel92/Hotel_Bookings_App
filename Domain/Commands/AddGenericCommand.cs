namespace StartMyNewApp.Domain.Commands
{
    // User Add Command - Can be replaced with UserCreateDto
    public class AddUserCommand
    {
        public string Username { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }

    // Wishlist Add Command - Can be replaced with WishlistCreateDto
    public class AddWishlistCommand
    {
        public int UserId { get; set; }
        public int HotelId { get; set; }
        public DateTime AddedDate { get; set; }
        public bool IsActive { get; set; }
    }

    // Room Add Command - Can be replaced with RoomCreateDto
    public class AddRoomCommand
    {
        public string RoomType { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public int HotelId { get; set; }
    }

    // Payment Add Command - Can be replaced with PaymentCreateDto
    public class AddPaymentCommand
    {
        public int UserId { get; set; }
        public int BookingId { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public string PaymentStatus { get; set; } = string.Empty;
    }

    // Location Add Command - Can be replaced with LocationCreateDto
    public class AddLocationCommand
    {
        public string LocationName { get; set; } = string.Empty;
    }

    // HotelArticle Add Command - Can be replaced with HotelArticleCreateDto
    public class AddHotelArticleCommand
    {
        public string HotelName { get; set; } = string.Empty;
        public string HotelDescription { get; set; } = string.Empty;
        public int HotelStars { get; set; }
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public List<string> Images { get; set; } = new List<string>();
    }

    // Comment Add Command - Can be replaced with CommentCreateDto
    public class AddCommentCommand
    {
        public string Body { get; set; } = string.Empty;
        public int HotelID { get; set; }
        public int Rating { get; set; }
    }

    // Booking Add Command - Can be replaced with BookingCreateDto
    public class AddBookingCommand
    {
        public int UserId { get; set; }
        public int HotelID { get; set; }
        public int RoomId { get; set; }
        public int NumberOfRooms { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
    }

    // Amenity Add Command - Can be replaced with AmenityCreateDto
    public class AddAmenityCommand
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsAvailable { get; set; }
        public int HotelId { get; set; }
    }
}
