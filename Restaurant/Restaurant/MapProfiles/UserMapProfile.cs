using AutoMapper;
using BussinesLayer.Dtos;
using Restaurant.Models;

namespace Restaurant.MapProfiles
{
    public class UserMapProfile : Profile
    {
        public UserMapProfile()
        {
            CreateMap<UserViewModel, UserRequestDto>();
        }
    }
}
