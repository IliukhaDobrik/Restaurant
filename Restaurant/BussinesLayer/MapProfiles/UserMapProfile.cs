using AutoMapper;
using BussinesLayer.Dtos;
using Entities;

namespace BussinesLayer.MapProfiles
{
    public class UserMapProfile : Profile
    {
        public UserMapProfile()
        {
            CreateMap<UserRequestDto, User>();
            CreateMap<User, UserRequestDto>();
        }
    }
}
