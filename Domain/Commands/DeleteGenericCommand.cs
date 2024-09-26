namespace StartMyNewApp.Domain.Commands
{
    // Command to delete a user
    public class DeleteUserCommand
    {
        public int IdUser { get; set; }
        public DeleteUserCommand(int idUser) => IdUser = idUser;
    }

    // Command to delete a wishlist entry
    public class DeleteWishlistCommand
    {
        public int WishlistId { get; set; }
        public DeleteWishlistCommand(int wishlistId) => WishlistId = wishlistId;
    }

    // Command to delete a room
    public class DeleteRoomCommand
    {
        public int RoomId { get; set; }
        public DeleteRoomCommand(int roomId) => RoomId = roomId;
    }

    // Command to delete a payment
    public class DeletePaymentCommand
    {
        public int PaymentId { get; set; }
        public DeletePaymentCommand(int paymentId) => PaymentId = paymentId;
    }

    // Command to delete a location
    public class DeleteLocationCommand
    {
        public int IdLocation { get; set; }
        public DeleteLocationCommand(int idLocation) => IdLocation = idLocation;
    }

    // Command to delete a hotel article
    public class DeleteHotelArticleCommand
    {
        public int HotelID { get; set; }
        public DeleteHotelArticleCommand(int hotelId) => HotelID = hotelId;
    }

    // Command to delete a comment
    public class DeleteCommentCommand
    {
        public int IdComment { get; set; }
        public DeleteCommentCommand(int idComment) => IdComment = idComment;
    }

    // Command to delete a booking
    public class DeleteBookingCommand
    {
        public int IdBooking { get; set; }
        public DeleteBookingCommand(int idBooking) => IdBooking = idBooking;
    }

    // Command to delete an amenity
    public class DeleteAmenityCommand
    {
        public int AmenityId { get; set; }
        public DeleteAmenityCommand(int amenityId) => AmenityId = amenityId;
    }

    // Command to delete a message
    public class DeleteMessageCommand
    {
        public int MessageId { get; set; }
        public DeleteMessageCommand(int messageId) => MessageId = messageId;
    }

    // Command to delete a notification
    public class DeleteNotificationCommand
    {
        public int NotificationId { get; set; }
        public DeleteNotificationCommand(int notificationId) => NotificationId = notificationId;
    }
}
