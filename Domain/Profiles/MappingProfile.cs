using AutoMapper;
using StartMyNewApp.Domain.DTOs;
using StartMyNewApp.Domain.Models;

namespace StartMyNewApp.Domain.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // User mappings
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<User, UserReadDto>();

            // HotelArticle mappings
            CreateMap<HotelArticleCreateDto, HotelArticle>();
            CreateMap<HotelArticleUpdateDto, HotelArticle>();
            CreateMap<HotelArticle, HotelArticleReadDto>();

            // Room mappings
            CreateMap<RoomCreateDto, Room>();
            CreateMap<RoomUpdateDto, Room>();
            CreateMap<Room, RoomReadDto>();

            // Payment mappings
            CreateMap<PaymentCreateDto, Payment>();
            CreateMap<PaymentUpdateDto, Payment>();
            CreateMap<Payment, PaymentReadDto>();

            // Booking mappings
            CreateMap<BookingCreateDto, Booking>();
            CreateMap<BookingUpdateDto, Booking>();
            CreateMap<Booking, BookingReadDto>();

            // Wishlist mappings
            CreateMap<WishlistCreateDto, Wishlist>();
            CreateMap<WishlistUpdateDto, Wishlist>();
            CreateMap<Wishlist, WishlistReadDto>();

            // Amenity mappings
            CreateMap<AmenityCreateDto, Amenity>();
            CreateMap<AmenityUpdateDto, Amenity>();
            CreateMap<Amenity, AmenityReadDto>();

            // Comment mappings
            CreateMap<CommentCreateDto, Comment>();
            CreateMap<CommentUpdateDto, Comment>();
            CreateMap<Comment, CommentReadDto>();

            // Message mappings
            CreateMap<MessageCreateDto, Message>();
            CreateMap<MessageUpdateDto, Message>();
            CreateMap<Message, MessageReadDto>();

            // Notification mappings
            CreateMap<NotificationCreateDto, Notification>();
            CreateMap<NotificationUpdateDto, Notification>();
            CreateMap<Notification, NotificationReadDto>();

            // Add any additional mappings as needed
        }
    }
}
