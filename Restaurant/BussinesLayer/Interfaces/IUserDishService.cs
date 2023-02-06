using BussinesLayer.Dtos;

namespace BussinesLayer.Interfaces
{
    public interface IUserDishService : IService<UserDishRequestDto>
    {
        //Get all Users dish by userId
        Task<IReadOnlyCollection<DishRequestDto>> GetById(Guid userId);
        Task Add(UserDishRequestDto userDto);
    }
}
