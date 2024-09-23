using AutoMapper;
using StartMyNewApp.Domain.DTOs;
using StartMyNewApp.Domain.Models;

namespace StartMyNewApp.Domain.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add the mapping configurations here
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<User, UserReadDto>();

            // Add other mappings as needed
        }
    }
}
