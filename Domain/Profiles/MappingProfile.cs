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
            CreateMap<HotelArticleCreateDto, HotelArticle>()
                .ForMember(dest => dest.ImagePaths, opt => opt.MapFrom(src => src.ImagePaths)); // Map ImagePaths

            // Conditional update: Update only non-null fields in HotelArticleUpdateDto
            CreateMap<HotelArticleUpdateDto, HotelArticle>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // Mapping HotelArticle to its ReadDto
            CreateMap<HotelArticle, HotelArticleReadDto>()
                .ForMember(dest => dest.OwnerName, opt => opt.MapFrom(src => src.Owner != null ? src.Owner.Name : "Unknown Owner"));

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

            // Additional mappings can be added here as needed
        }
    }
}
