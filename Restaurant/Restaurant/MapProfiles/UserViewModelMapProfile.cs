using AutoMapper;
using BussinesLayer.Dtos;
using Restaurant.Models;

namespace Restaurant.MapProfiles
{
    public class UserViewModelMapProfile : Profile
    {
        public UserViewModelMapProfile()
        {
            CreateMap<UserReserveViewModel, UserReserveDto>();
        }
    }
}
