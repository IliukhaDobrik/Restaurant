using AutoMapper;
using BussinesLayer.Dtos;
using Entities;

namespace BussinesLayer.MapProfiles
{
    public class DishMapProfile : Profile
    {
        public DishMapProfile() 
        {
            CreateMap<Dish, DishRequestDto>();
        }
    }
}
