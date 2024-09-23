namespace StartMyNewApp.Domain.Commands
{
    public class UpdateUserCommand // Can be replaced with UserUpdateDto
    {
        public int IdUser { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }

    public class UpdateWishlistCommand // Can be replaced with WishlistUpdateDto
    {
        public int WishlistId { get; set; }
        public int UserId { get; set; }
        public int HotelId { get; set; }
        public bool IsActive { get; set; }
    }

    public class UpdateRoomCommand // Can be replaced with RoomUpdateDto
    {
        public int RoomId { get; set; }
        public string RoomType { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public int HotelId { get; set; }
    }

    public class UpdatePaymentCommand // Can be replaced with PaymentUpdateDto
    {
        public int PaymentId { get; set; }
        public int UserId { get; set; }
        public int BookingId { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public string PaymentStatus { get; set; } = string.Empty;
    }

    public class UpdateLocationCommand // Can be replaced with LocationUpdateDto
    {
        public int IdLocation { get; set; }
        public string LocationName { get; set; } = string.Empty;
    }

    public class UpdateHotelArticleCommand // Can be replaced with HotelArticleUpdateDto
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
    }

    public class UpdateCommentCommand // Can be replaced with CommentUpdateDto
    {
        public int IdComment { get; set; }
        public string Body { get; set; } = string.Empty;
        public int HotelID { get; set; }
        public int Rating { get; set; }
    }

    public class UpdateBookingCommand // Can be replaced with BookingUpdateDto
    {
        public int IdBooking { get; set; }
        public int UserId { get; set; }
        public int HotelID { get; set; }
        public int RoomId { get; set; }
        public int NumberOfRooms { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
    }

    public class UpdateAmenityCommand // Can be replaced with AmenityUpdateDto
    {
        public int AmenityId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsAvailable { get; set; }
        public int HotelId { get; set; }
    }
}
