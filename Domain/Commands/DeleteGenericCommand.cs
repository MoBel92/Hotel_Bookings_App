namespace StartMyNewApp.Domain.Commands
{
    public class DeleteUserCommand
    {
        public int IdUser { get; set; } // The ID of the user to be deleted
        public DeleteUserCommand(int idUser) => IdUser = idUser;
    }

    public class DeleteWishlistCommand
    {
        public int WishlistId { get; set; } // The ID of the wishlist entry to be deleted
        public DeleteWishlistCommand(int wishlistId) => WishlistId = wishlistId;
    }

    public class DeleteRoomCommand
    {
        public int RoomId { get; set; } // The ID of the room to be deleted
        public DeleteRoomCommand(int roomId) => RoomId = roomId;
    }

    public class DeletePaymentCommand
    {
        public int PaymentId { get; set; } // The ID of the payment to be deleted
        public DeletePaymentCommand(int paymentId) => PaymentId = paymentId;
    }

    public class DeleteLocationCommand
    {
        public int IdLocation { get; set; } // The ID of the location to be deleted
        public DeleteLocationCommand(int idLocation) => IdLocation = idLocation;
    }

    public class DeleteHotelArticleCommand
    {
        public int HotelID { get; set; } // The ID of the hotel to be deleted
        public DeleteHotelArticleCommand(int hotelId) => HotelID = hotelId;
    }

    public class DeleteCommentCommand
    {
        public int IdComment { get; set; } // The ID of the comment to be deleted
        public DeleteCommentCommand(int idComment) => IdComment = idComment;
    }

    public class DeleteBookingCommand
    {
        public int IdBooking { get; set; } // The ID of the booking to be deleted
        public DeleteBookingCommand(int idBooking) => IdBooking = idBooking;
    }

    public class DeleteAmenityCommand
    {
        public int AmenityId { get; set; } // The ID of the amenity to be deleted
        public DeleteAmenityCommand(int amenityId) => AmenityId = amenityId;
    }
}
