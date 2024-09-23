namespace StartMyNewApp.Domain.Commands
{
    public class DeleteUserCommand
    {
        public int IdUser { get; set; }
        public DeleteUserCommand(int idUser) => IdUser = idUser;
    }

    public class DeleteWishlistCommand
    {
        public int WishlistId { get; set; }
        public DeleteWishlistCommand(int wishlistId) => WishlistId = wishlistId;
    }

    public class DeleteRoomCommand
    {
        public int RoomId { get; set; }
        public DeleteRoomCommand(int roomId) => RoomId = roomId;
    }

    public class DeletePaymentCommand
    {
        public int PaymentId { get; set; }
        public DeletePaymentCommand(int paymentId) => PaymentId = paymentId;
    }

    public class DeleteLocationCommand
    {
        public int IdLocation { get; set; }
        public DeleteLocationCommand(int idLocation) => IdLocation = idLocation;
    }

    public class DeleteHotelArticleCommand
    {
        public int HotelID { get; set; }
        public DeleteHotelArticleCommand(int hotelId) => HotelID = hotelId;
    }

    public class DeleteCommentCommand
    {
        public int IdComment { get; set; }
        public DeleteCommentCommand(int idComment) => IdComment = idComment;
    }

    public class DeleteBookingCommand
    {
        public int IdBooking { get; set; }
        public DeleteBookingCommand(int idBooking) => IdBooking = idBooking;
    }

    public class DeleteAmenityCommand
    {
        public int AmenityId { get; set; }
        public DeleteAmenityCommand(int amenityId) => AmenityId = amenityId;
    }
}
